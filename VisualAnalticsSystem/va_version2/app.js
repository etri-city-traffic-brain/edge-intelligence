/* global window */
import React, {Component} from 'react';
import {render} from 'react-dom';
import {StaticMap} from 'react-map-gl';
import {AmbientLight, PointLight, LightingEffect, WebMercatorViewport} from '@deck.gl/core';
import DeckGL from '@deck.gl/react';
import {PolygonLayer,IconLayer} from '@deck.gl/layers';
import {TripsLayer} from '@deck.gl/geo-layers';
import axios from 'axios';
import { booleanPointInPolygon, polygon, point } from "@turf/turf"
import MenuController from './src/menuController';

// Mapbox Token
const MAPBOX_TOKEN = 'pk.eyJ1Ijoic2J1bXNlbyIsImEiOiJjajE0cXp5ZXYwMGswMnJvNjF3ZWhtOXU1In0.3lbBNI2-kpnz17nR8bpB3A'; // eslint-disable-line

// Source data CSV
const DATA_URL = {
  BUILDINGS: 'data/gangnam.json', // eslint-disable-line
};

// 이펙트 관련
const ambientLight = new AmbientLight({
  color: [255, 255, 255],
  intensity: 1.0
});
const pointLight = new PointLight({
  color: [255, 255, 255],
  intensity: 2.0,
  position: [-74.05, 40.7, 8000]
});
const lightingEffect = new LightingEffect({ambientLight, pointLight});

const material = {
  ambient: 0.1,
  diffuse: 0.6,
  shininess: 32,
  specularColor: [60, 64, 70]
};

// 테마 데이터
const DEFAULT_THEME = {
  buildingColor: [74, 80, 87], // 건물 색상
  trailColor0: [255, 0, 0], // 교통 궤적 컬러 1
  trailColor1: [23, 184, 190], // 교통 궤적 컬러 2
  material,
  effects: [lightingEffect]
};

// 시작 시 뷰 상태
const INITIAL_VIEW_STATE = {
  longitude: 127.35948967401414, // 경도
  latitude: 36.36160620583498, // 위도
  zoom: 14, // 줌
  pitch: 45, // 기울기(상하)
  bearing: 0 // 기울기(방위)
};

const trafficData = []

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      time: 0,
      theme: DEFAULT_THEME,
      mapBound: [],
      placeData: {},
      cctvData: [],
      selectedCctv: 0,
      tripData: [],
      encType: 'speed',
      displayTime: 0,
      polygonCount: -1,
      polygonCoord: [{coord: [0,0]}],
      groupedCctv: {},
    };
    this.onTrailColorChange = this.onTrailColorChange.bind(this);
    this.onEncTypeChange = this.onEncTypeChange.bind(this);
    this.onTimeChange = this.onTimeChange.bind(this);
    this._onHover = this._onHover.bind(this);
    this._onClick = this._onClick.bind(this);
    this.setPolygonCoordinate = this.setPolygonCoordinate.bind(this);
    this.calcPolygonBoundary = this.calcPolygonBoundary.bind(this)
    this._onClickPolygonDraw = this._onClickPolygonDraw.bind(this);
    this._onClickPolygonDelete = this._onClickPolygonDelete.bind(this);
  }

  componentDidMount() {
    this._animate();
    this._loadCCTVdata();
    this._loadTripData();
  }

  componentWillUnmount() {
    if (this._animationFrame) {
      window.cancelAnimationFrame(this._animationFrame);
    }
  }

  _loadCCTVdata() {
    axios
      .get("data/place_data.json")
      .then(({data}) => {
        const resultDict = {}
        for (let placeName in data)
        {
          var direction = 1;
          if (data[placeName].direction) direction = data[placeName].direction;
          resultDict[placeName] = {
            cctvStrtSecnNm: data[placeName].name,
            channel: data[placeName].cctv,
            coordinate: data[placeName].coordinates,
            linked: data[placeName].linked,
            direction: direction
          };
        }

        const resultList = [];
        for (let placeName in resultDict) {
          resultList.push({
            cctvStrtSecnNm: resultDict[placeName].cctvStrtSecnNm,
            channel: resultDict[placeName].channel,
            coordinate: resultDict[placeName].coordinate,
            direction: resultDict[placeName].direction
          })
        }
        
        this.setState({placeData: resultDict})
        this.setState({cctvData: resultList});
      });
  }

  GenerateTripLayer(encType, targetTime) {
    const result = []
    for (let dataIndex in trafficData) {
      const targetData = trafficData[dataIndex]
      let traffic_factor = 0;
      
      if (targetTime < targetData.traffic.length) {
        switch (encType) {
          case 'speed':
            traffic_factor = (100 / 50 * targetData.traffic[targetTime].avs);
            break;
          case 'volume':
            traffic_factor = 100 - targetData.traffic[targetTime].volume;
            break;
          // case 'congestion-type':
          //   break;
          default:
            traffic_factor = (100 / 50 * targetData.traffic[targetTime].avs);
            break;
        }
        if (traffic_factor <= 10) traffic_factor = 10
      }

      const time = [];
      let total_time = 1;

      for (let i = 0; i < targetData.path.length; i++) {
        if (i > 0) {
          const lon_length = targetData.path[i - 1][0] - targetData.path[i][0];
          const lat_length = targetData.path[i - 1][1] - targetData.path[i][1];
          const travel_length = Math.sqrt(Math.pow(lon_length, 2) + Math.pow(lat_length, 2));
          const time_value = travel_length * (100000 / traffic_factor);
          total_time += time_value;
        }
        time.push(total_time)
      }

      let repeatCount = Math.floor(2000 / total_time)
      if (repeatCount <= 0) {
        repeatCount = 1
      }
      for (let i = 0; i < repeatCount; i++) {
        const time_calc = []
        for (let index in time) {
          time_calc.push(time[index] + (i * total_time))
        }

        result.push({
          path: targetData.path,
          timestamp: time_calc,
          factor: traffic_factor
        })
      }
    }

    this.setState({tripData: result})
  }

  _loadTripData() {
    const routeData = []
    axios
      .get("data/traffic_data.json")
      .then(({data}) => {
        for (let dataIndex in data) {
          const name = data[dataIndex].from.concat("-", data[dataIndex].to)
          routeData.push({
            name: name,
            traffic: data[dataIndex].traffic
          })
        }

        axios
          .get("data/route_data.json")
          .then(({data}) => {
            for (let junctionName in data) {
              for (let routeIndex in routeData) {
                if (routeData[routeIndex].name == junctionName) {
                  const traffic_info = routeData[routeIndex].traffic;

                  trafficData.push({
                    path: data[junctionName].coordinates,
                    traffic: traffic_info
                  });
                  break;
                }
              }
            }

            this.GenerateTripLayer(this.state.encType, this.state.displayTime)
          });
      });
  }

  _onCctvClick(info) {
    this.onCctvChannelChnage(info.object.channel)
  }

  _animate() {
    const {
      loopLength = 2000, // unit corresponds to the timestamp in source data
      animationSpeed = 15 // unit time per second
    } = this.props;
    const timestamp = Date.now() / 1000;
    const loopTime = loopLength / animationSpeed;

    this.setState({
      time: ((timestamp % loopTime) / loopTime) * loopLength
    });
    this._animationFrame = window.requestAnimationFrame(this._animate.bind(this));
    
  }

  _renderLayers() {
    const {
      buildings = DATA_URL.BUILDINGS
    } = this.props;
    const theme = this.state.theme;

    const ICON_MAPPING = {
      1: {x: 0, y: 0, width: 123, height: 123, mask: false},
      2: {x: 123, y: 0, width: 123, height: 123, mask: false},
      3: {x: 246, y: 0, width: 123, height: 123, mask: false},
      4: {x: 369, y: 0, width: 123, height: 123, mask: false},
      5: {x: 492, y: 0, width: 123, height: 123, mask: false},
      6: {x: 615, y: 0, width: 123, height: 123, mask: false},
      7: {x: 861, y: 0, width: 123, height: 123, mask: false},
      8: {x: 984, y: 0, width: 123, height: 123, mask: false},
    }

    return [
      // CCTV 선택 폴리곤 레이어
      new PolygonLayer({
        id: 'userCctvBoundary',
        data: this.state.polygonCoord,
        getPolygon: d => d.coord,
        filled: true,
        wireframe: true,
        getFillColor: [255, 255, 0, 100],
      }),
      // 교통 궤적 레이어
      new TripsLayer({
        id: 'trips',
        data: this.state.tripData,
        getPath: d => d.path,
        getTimestamps: d => d.timestamp,
        getColor: d => {
          const color_left = [
            255 - theme.trailColor0[0],
            255 - theme.trailColor0[1],
            255 - theme.trailColor0[2]        
          ]

          const color_weight = [
            Math.min(color_left[0] / 100 * d.factor, color_left[0]),
            Math.min(color_left[1] / 100 * d.factor, color_left[1]),
            Math.min(color_left[2] / 100 * d.factor, color_left[2])
          ]

          return [
            theme.trailColor0[0] + color_weight[0],
            theme.trailColor0[1] + color_weight[1],
            theme.trailColor0[2] + color_weight[2]
          ]
        },
        updateTriggers: {
          getColor: [this.state.theme.trailColor0]
        },
        opacity: 0.3,
        widthMinPixels: 2,
        rounded: true,
        trailLength: 50,
        currentTime: this.state.time,

        shadowEnabled: false
      }),
      // 건물 폴리곤 레이어
      new PolygonLayer({
        id: 'buildings',
        data: buildings,
        extruded: true,
        wireframe: false,
        opacity: 0.5,
        getPolygon: f => f.polygon,
        getElevation: f => f.height,
        getFillColor: theme.buildingColor,
        material: theme.material
      }),
      // CCTV 레이어
      new IconLayer({
        id: 'cctv',
        data: this.state.cctvData,
        pickable: true,
        iconAtlas: 'src/img/node/node_icon.png',
        iconMapping: ICON_MAPPING,
        getIcon: d => d.direction,
        sizeScale: 10,
        getSize: d => 5,
        getPosition: d => d.coordinate,
        onClick: (info, event) => { this._onCctvClick(info); }
      })
    ];
  }

  onCctvChannelChnage(value) {
    this.setState({selectedCctv: value});
  }

  // 컨트롤러를 통해 색상을 변경했을 때 (src/controller.js)
  onTrailColorChange(color) {
    const rgb = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(color);
    this.setState(prevState => ({
      theme: {
        ...prevState.theme,
        trailColor0: [
          parseInt(rgb[1], 16),
          parseInt(rgb[2], 16),
          parseInt(rgb[3], 16)
        ]
      }
    }));
  }

  onEncTypeChange(type) {
    this.GenerateTripLayer(type, this.state.displayTime);
    this.setState({encType: type});
  }

  onTimeChange(value) {
    this.GenerateTripLayer(this.state.encType, value);
    this.setState({displayTime: value});
  }

  _onDragEnd(event) {
    console.log(event);
  }

  _onHover(info, event) {
    if (this.state.polygonCount > -1 && info.coordinate != undefined) {
      
      const newCoord = info.coordinate;

      const result = []
      result.push({coord: this.setPolygonCoordinate(newCoord)});

      this.setState({polygonCoord: result});
    }
  }

  _onClick(info, event) {
    if (this.state.polygonCount > -1 && info.coordinate != undefined && info.layer == null) {
      const newCoord = info.coordinate;
      const count = this.state.polygonCount

      const result = []
      result.push({coord: this.setPolygonCoordinate(newCoord)});

      this.setState({polygonCoord: result});

      if (count > 1) {
        const difference = [Math.abs(result[0].coord[count - 1][0] - result[0].coord[count][0]), Math.abs(result[0].coord[count - 1][1] - result[0].coord[count][1])]
        if (difference[0] < 0.001 && difference[1] < 0.001) {
          this.setState({polygonCount: -1});
          this.calcPolygonBoundary();
        }
        else {
          this.setState({polygonCount: count + 1});
        }
      }
      else {
        this.setState({polygonCount: count + 1});
      }
    }
  }

  setPolygonCoordinate(coord) {
    const result = this.state.polygonCoord[0].coord

    result[this.state.polygonCount] = coord;

    return result;
  }

  removePolygon() {
    const coord = [{coord: [0,0]}];
    const place = {};

    this.setState({polygonCoord: coord});
    this.setState({groupedCctv: place});
  }

  calcPolygonBoundary() {
    const data = []
    data.push(this.state.polygonCoord[0]["coord"])
    data[0][data[0].length - 1] = data[0][0]
    if (data[0].length > 2) {
      let polygonData = polygon(data)
      let places = {}
      for (let placeName in this.state.placeData) {
        let place = this.state.placeData[placeName]
        let pointData = point(place.coordinate)
        console.log(place.coordinate)
        if (booleanPointInPolygon(pointData, polygonData)) {
          places[place.channel] = place
        }
      }
      this.setState({groupedCctv: places})
    }
  }

  _onViewStateChange(viewState) {
    // const viewport = new WebMercatorViewport(viewState);

    // const nw = viewport.unproject([0, 0]);
    // const se = viewport.unproject([viewport.width, viewport.height]);
    // console.log("north: ", nw[1], ", south: ", se[1], ", east: ", se[0], ", west: ", nw[0] );
  }

  _onClickPolygonDraw() {
    if (this.state.polygonCount == -1) {
      this.setState({polygonCount: 0})
    }
  }

  _onClickPolygonDelete() {
    this.setState({polygonCount: -1});
    this.removePolygon();
  }

  render() {
    const {
      viewState,
      mapStyle = 'mapbox://styles/mapbox/dark-v9',
    } = this.props;
    const theme = this.state.theme;

    return (
      <div>
        <DeckGL
          layers={this._renderLayers()}
          effects={theme.effects}
          initialViewState={INITIAL_VIEW_STATE}
          viewState={viewState}
          controller={true}
          onHover={this._onHover}
          onClick={this._onClick}
          // onDragEnd={this._onDragEnd}
          // onViewStateChange={this._onViewStateChange}
        >
          <StaticMap
            reuseMaps
            mapStyle={mapStyle}
            preventStyleDiffing={true}
            mapboxApiAccessToken={MAPBOX_TOKEN}
          />
        </DeckGL>
        <MenuController
          placeData={this.state.placeData}
          onCctvChannelChange={this.onCctvChannelChnage}
          cctvChannel={this.state.selectedCctv}
          groupedCctv={this.state.groupedCctv}
          onTrailColorChange={this.onTrailColorChange}
          onEncTypeChange={this.onEncTypeChange}
          onTimeChange={this.onTimeChange}
          mapBound={this.state.mapBound}
          onClickPolygonDraw={this._onClickPolygonDraw}
          onClickPolygonDelete={this._onClickPolygonDelete}
        />
      </div>
    );
  }
}

export function renderToDOM(container) {
  render(<App />, container);
}
