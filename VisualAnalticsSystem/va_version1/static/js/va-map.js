var map;
var timeline;

var cctvData = {};
var placeData = {};
var trafficData = [];
var routeData = {};

var mapboxToken = 'pk.eyJ1Ijoic2J1bXNlbyIsImEiOiJjajE0cXp5ZXYwMGswMnJvNjF3ZWhtOXU1In0.3lbBNI2-kpnz17nR8bpB3A';

$(document).ready(function() {

  mapboxgl.accessToken = mapboxToken;
  map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/light-v10',
    center: [127.030751, 37.513940],
    zoom: 13
  });

  map.on('load', function() {
    map.loadImage('static/img/circle.png', function(error, image) {
      if (error)
        throw error;
        map.addImage('circle', image);
    });

    $.ajax({
      method: 'get',
      url: 'static/place_data.json',
      dataType: 'json',
      cache: false,
      async: false
    }).done(onPlaceDataResponse);

    $.ajax({
      method: 'get',
      url: 'static/cctv_data.json',
      dataType: 'json',
      cache: false
    }).done(onCCTVDataResponse);
  });

  map.on('click', 'cctv', function(e) {
    var channel = e.features[0].properties.channel;
    var directions = ['─', '│', '┼', '┬'];

    $.ajax({
      method: 'get',
      url: 'video/' + channel,
      cache: false
    }).done(function(html) {
      $('#cctv-video')
        .removeClass('empty')
        .html(html);

      // 촬영영역
      var direction = directions[channel % directions.length];
      $('#cctv-direction')
        .removeClass('empty')
        .text(direction);

      // 배경변화비교

      // 교통량 차트
      var trafficChartData = [];
      for (var i = 0; i < 24; i++) {
        trafficChartData.push([i, Math.floor(Math.random() * 30) + 10]);
      }
      drawTrafficChart(trafficChartData);

      // 엔트로피 차트
      var entropyChartData = [];
      for (var i = 0; i < 24; i++) {
        entropyChartData.push([i, Math.floor(Math.random() * 30) + 10]);
      }
      drawEntropyChart(entropyChartData);
    });
  });

  map.on('mouseenter', 'cctv', function() {
    map.getCanvas().style.cursor = 'pointer';
  });

  map.on('mouseleave', 'cctv', function() {
    map.getCanvas().style.cursor = '';
  });

  map.on('click', function(e) {
    console.log(e.lngLat.toArray());
  });
});

function onCCTVDataResponse(data) {
  cctvData = data;

  var geojson = {
    type: 'geojson',
    data: {
      type: 'FeatureCollection',
      features: []
    }
  };

  for (var id in cctvData) {
    var channel = cctvData[id];
    if (channel == undefined)
      continue;
    
    geojson.data.features.push({
      type: 'Feature',
      geometry: {
        type: 'Point',
        coordinates: [channel.x, channel.y]
      },
      properties: {
        channel: channel.channel
      }
    });
  }

  map.addSource('cctv', geojson);
  map.addLayer({
    id: 'cctv',
    type: 'symbol',
    source: 'cctv',
    layout: {
      'icon-image': 'circle',
      'icon-size': .8,
      'icon-allow-overlap': true
    }
  });
}

function onPlaceDataResponse(data) {
  placeData = data;
  $.ajax({
    method: 'get',
    url: 'static/traffic_data.json',
    dataType: 'json',
    cache: false
  }).done(onTrafficDataResponse);
}

function drawRoutes(time) {
  for (var name in placeData) {
    var place = placeData[name];

    var weight = 0.0002;
    for (var destName of place.linked) {
      var dest = placeData[destName];
      var theta = Math.atan2(dest.coordinates[1]-place.coordinates[1], dest.coordinates[0]-place.coordinates[0]);
      var parallel = [weight * Math.cos(theta + Math.PI / 2), weight * Math.sin(theta + Math.PI / 2)];
      //var routeCoords = [place.coordinates, dest.coordinates];
      var routeCoords = [
        [place.coordinates[0]-parallel[0], place.coordinates[1]-parallel[1]],
        [dest.coordinates[0]-parallel[0], dest.coordinates[1]-parallel[1]]
      ];
      var routeName = name + '-' + destName;
      var routeTraffic = routeData[routeName];

      var color = '#888';
      for (tbp of routeTraffic.traffic) {
        if (tbp.time == time) {
          if (tbp.avs < 15) // 정체
            color = 'rgb(192,0,0)';
          else if (tbp.avs < 30) // 서행
            color = 'rgb(254,199,31)';
          else // 원활
            color = 'rgb(0,176,80)';
          break;
        }
      }
      drawRoute(routeName + '-route', routeCoords, color, 3);
    }
  }
}

function drawRoute(id, coordinates, color, width) {
  if (!map.getSource(id)) {
    map.addSource(id, {
      type: 'geojson',
      data: {
        type: 'Feature',
        properties: {},
        geometry: {
          type: 'LineString',
          coordinates: coordinates
        }
      }
    });
  }
  if (!map.getLayer(id)) {
    map.addLayer({
      id: id,
      type: 'line',
      source: id,
      layout: {
        'line-join': 'round',
        'line-cap': 'round'
      },
      paint: {
        'line-color': color,
        'line-width': width
      }
    });
  } else {
    map.setPaintProperty(id, 'line-color', color);
    map.setPaintProperty(id, 'line-width', width);
  }
}

function onTrafficDataResponse(data) {
  trafficData = data;
  for (var traffic of trafficData) {
    routeData[traffic.from + '-' + traffic.to] = traffic;
  }

  var now = new Date().getHours();

  // timeline
  var volume = [];
  for (var i = 0; i < 24; i++)
    volume[i] = 0;
  for (var traffic of trafficData) {
    for (var tpb of traffic.traffic) {
      volume[tpb.time] += tpb.volume;
    }
  }
  drawTimeline(now, volume);

  // routes
  drawRoutes(now);
}

function drawTimeline(now, volume) {
  timeline = Highcharts.chart('timeline', {
    chart: {
      type: 'areaspline',
      marginBottom: 25,
      events: {
        click: function(e) {
          var time = Math.round(e.xAxis[0].value);
          drawRoutes(time);
          timeline.xAxis[0].options.plotLines[0].value = time;
          timeline.xAxis[0].update();
        }
      }
    },
    title: {
      text: ''
    },
    legend: {
      enabled: false
    },
    credits: {
      enabled: false
    },

    xAxis: {
      categories: [
        '0','1','2','3','4','5','6','7','8','9','10','11','12',
        '13','14','15','16','17','18','19','20','21','22','23'
      ],
      /*plotBands: [
      { // Box area, 
        from: 4,
        to: 4,
        color: 'rgba(99, 99, 99, .5)'
      },],*/
      plotLines: [{
        color: 'rgba(99, 99, 99, .5)',
        dashstyle: 'longdashdot',
        value: now,
        width: 3
      }],
      labels: {
        style: {
          fontSize: 14
        }
      }
    },
    yAxis: {
      labels: {
        enabled: false
      },
      title: {
        text: ''
      }
    },
    tooltip: {
      shared: true,
      valueSuffix: ' units'
    },
    credits: {
      enabled: false
    },
    plotOptions: {
      areaspline: {
        marker:{ enabled: false },
        fillOpacity: 0.2,
        lineWidth: 0,
      }
    },
    series: [{
      name: 'Traffic',
      data: volume,
      color:'#636363'
    }]
  });
}