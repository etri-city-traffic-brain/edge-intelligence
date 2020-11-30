import React, { useState, useRef, useEffect } from 'react';
import Slider from '@material-ui/core/Slider'
import CCTVInfo from './CCTVInfo';
import NodeGraph from './NodeGraph'
//import styles from './controller.module.css';

const wrapper = {
  position: 'fixed',
  color: 'white',
};
const section = {
  margin: '10px',
  backgroundColor: 'rgba(0, 0, 0, .5)',
  border: '1px solid rgba(0, 0, 0, .2)',
  padding: '5px 10px',
};
const hoverable = {
  cursor: 'pointer',
};
const hidden = {
  display: 'none',
};
const palette = {
  display: 'inline-block',
  width: '30px',
  backgroundColor: 'black',
  border: '1px solid black',
  cursor: 'pointer',
};
const gradient = {
  width: '200px',
};
const colorinput = {
  width: 0,
  height: 0,
  padding: 0,
  verticalAlign: 'top',
  visibility: 'hidden',
  border: 'none',
};

function menuController(props) {
  const {
    placeData,
    onCctvChannelChange,
    cctvChannel,
    groupedCctv,
    onTrailColorChange,
    onEncTypeChange,
    onTimeChange,
    mapBound,
    onClickPolygonDraw,
    onClickPolygonDelete
  } = props;
  const [visenc, setVisenc] = useState(true);
  const [sliderValue, setSliderValue] = useState(0);

  const openVisualEncoding = () => {
    setVisenc(!visenc)
  };

  const onTimeChanged = (event, newValue) => {
    setSliderValue(newValue)
    onTimeChange(newValue + 12)
  };

  const onColorSelected = (e) => {
    const target = document.querySelector(`[for=${e.target.id}]`);
    if (target.classList.contains('gradient')) {
      target.style.background = `linear-gradient(90deg, white -10%, ${e.target.value} 100%)`;
    } else {
      target.style.backgroundColor = e.target.value;
    }
    onTrailColorChange(e.target.value);
  };

  const onEncTypeChanged = (e) => {
    const enctype = e.target.value;
    onEncTypeChange(enctype)

    const value = e.target.parentElement.querySelector('input[type=color]').value;
    onTrailColorChange(value);
  };

  return (
    <div style={wrapper}>
      <div>
        <div style={section}>
          <span>Time</span>
          <div className="slidecontainer">
            <Slider
              valueLabelDisplay="auto"
              step={1}
              marks
              min={-12}
              max={11}
              value={sliderValue}
              onChange={onTimeChanged}
            />
          </div>
        </div>
      </div>
      <div>
        <div style={section}>
          <div>User boundary tool</div>
          <button onClick={() => onClickPolygonDraw()}>draw</button>
          <button onClick={() => onClickPolygonDelete()}>delete</button>
          <div>
            <NodeGraph
              placeData={placeData}
              groupedCctv={groupedCctv}
            />
          </div>
        </div>
      </div>
      <div>
        <div onClick={openVisualEncoding} style={{...section, ...hoverable}}>
          <span>Visual encoding</span>
        </div>
        <div id="visenc" style={{...section, ...(visenc ? hidden : null)}}>
          <div>
            <input name="enctype" type="radio" value="speed" onChange={onEncTypeChanged} />
            <span>Speed</span>
            <label htmlFor="color-speed" className="gradient" style={{...palette, ...gradient}}>&nbsp;</label>
            <input id="color-speed" type="color" onChange={onColorSelected} style={colorinput} />
          </div>
          <div>
            <input name="enctype" type="radio" value="volume" onChange={onEncTypeChanged} />
            <span>Volume</span>
            <label htmlFor="color-volume" className="gradient" style={{...palette, ...gradient}}>&nbsp;</label>
            <input id="color-volume" type="color" onChange={onColorSelected} style={colorinput} />
          </div>
          <div>
            <input name="enctype" type="radio" value="congestion-type" onChange={onEncTypeChanged} />
            <span>Congestion Type</span>
            <div style={{marginLeft: '10px'}}>
              <span>Type 1</span>
              <label htmlFor="color-type1" style={palette}>&nbsp;</label>
              <input id="color-type1" type="color" onChange={onColorSelected} style={colorinput} />
              <span>Type 2</span>
              <label htmlFor="color-type2" style={palette}>&nbsp;</label>
              <input id="color-type2" type="color" onChange={onColorSelected} style={colorinput} />
              <span>Type 3</span>
              <label htmlFor="color-type3" style={palette}>&nbsp;</label>
              <input id="color-type3" type="color" onChange={onColorSelected} style={colorinput} />
              <span>Type 4</span>
              <label htmlFor="color-type4" style={palette}>&nbsp;</label>
              <input id="color-type4" type="color" onChange={onColorSelected} style={colorinput} />
            </div>
          </div>
        </div>
      </div>
      <div>
        <div style={section}>
          <span>Video sampling</span>
          <span></span>
        </div>
      </div>
      <CCTVInfo
        placeData={placeData}
        onCctvChannelChange={onCctvChannelChange}
        cctvChannel={cctvChannel}
        section={section}
        hoverable={hoverable}
        hidden={hidden}
      />
    </div>
  );
}

export default menuController;