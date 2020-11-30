import React, { useState, useRef, useEffect } from 'react';
import axios from 'axios'
import {Img} from 'react-image'
import ReactInterval from 'react-interval'
import videojs from 'video.js'

let vehtypeCount = 1;

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

function CCTVInfo(props) {
  const { onCctvChannelChange, cctvChannel, mapBoundChanged } = props;
  const [player, setPlayer] = useState(null);
  const [undetctveh, setUndetctveh] = useState(true);
  const [undetctvehSrc, setUndetctvehSrc] = useState([]);
  const [refreshCount, setRefreshCount] = useState(1);
  const [selectedUndetctveh, setSelectedUndetctveh] = useState(-1);
  const videoRef = useRef(null);

  const options = {
    fill: true,
    fluid: true,
    preload: 'auto',
    html5: {
      hls: {
        enableLowInitialPlaylist: true,
        smoothQualityChange: true,
        overrideNative: true,
      },
    },
    autoplay: true,
    controls: true,
    skin: 'vjs-default-skin'
  };

  useEffect(() => {
    const player = videojs(videoRef.current, {
      ...options,
      sources: ['']
    });
    setPlayer(player);

    return () => {
      if (player !== null)
        player.dispose();
    };
  }, []);

  useEffect(() => {
    vehtypeCount = 1;
    setUndetctvehSrc([])
    if (cctvChannel != 0) {
      generateRandomUndetectedVehicle([]);

      axios.get(`http://${window.location.hostname}:5000/video/${cctvChannel}`)
        .then(({ data }) => {
          player.src({
            src: data,
            type: 'application/x-mpegURL'
          });
        });
    }
  }, [cctvChannel]);

  useEffect(() => {
    if (cctvChannel != 0) {
      const srcList = undetctvehSrc
      generateRandomUndetectedVehicle(srcList);
    }
  }, [refreshCount])

  const generateRandomUndetectedVehicle = (originList) => {
    let num = Math.floor(Math.random() * 3) + 1;

    const srcList = [];
    for (let outerIndex in originList) {
      for (let innerIndex in originList[outerIndex]) {
        srcList.push(originList[outerIndex][innerIndex])
      }
    }

    for (let i = 0; i < num; i++) {
      srcList.unshift(vehtypeCount++ % 20 + 1);
    }
    
    const result = []
    let oneRow = []
    for (let index in srcList) {
      oneRow.push(srcList[index])
      if (index > 0 && (parseInt(index) + 1) % 4 == 0) {
        result.push(oneRow)
        oneRow = []
      }
    }
    result.push(oneRow)

    setUndetctvehSrc(result);
  }

  const calcUndetectedVehicle = () => {
    const lastRow = []
    for (let i in undetctvehSrc[undetctvehSrc.length - 1]) {
      lastRow.push(undetctvehSrc[undetctvehSrc.length - 1][i])
    }
    return Math.max(0, undetctvehSrc.length - 1) * 4 + lastRow.length
  }

  const learnVehicle = () => {
    if (selectedUndetctveh == -1) {
      console.log("wrong vehicle index")
    }
    else {
      const srcList = []
      const target = selectedUndetctveh
      for (let i in undetctvehSrc) {
        for (let j in undetctvehSrc[i]) {
          if (Math.floor(target / 4) != i || target % 4 != j) {
            srcList.push(undetctvehSrc[i][j])
          }
        }
      }
      const result = []
      let oneRow = []
      for (let index in srcList) {
        oneRow.push(srcList[index])
        if (index > 0 && (parseInt(index) + 1) % 4 == 0) {
          result.push(oneRow)
          oneRow = []
        }
      }
      result.push(oneRow)

      setUndetctvehSrc(result)
    }
  }

  return (
    <div>
      <ReactInterval
        timeout={300000}
        enabled={true}
        callback={() => setRefreshCount(refreshCount + 1)}
      />
      <div style={section}>
        <span>Traffic CCTV video</span>
        <div style={{...(cctvChannel ? null : hidden)}}>
          <div data-vjs-player>
            <video
              ref={videoRef}
              className="video-js">
            </video>
          </div>
        </div>
        <div style={{...(cctvChannel ? hidden : null)}}>
          <span>- Click CCTV icon</span>
        </div>
      </div>
      <div>
        <div style={section}>
          <span>North direction</span>
        </div>
      </div>
      <div>
        <div onClick={() => setUndetctveh(!undetctveh)} style={{...section, ...hoverable}}>
          <span>Undetected Vehicles ({calcUndetectedVehicle()})</span>
        </div>
        <div id="undetctveh" style={{...section, ...(undetctveh ? hidden : null)}}>
          <table>
            <tbody>
              {undetctvehSrc.map((d, i) => (
                <tr key={i}>
                  {d.map((p, j) => (
                    <td className="block">
                      <button id={`vehicleImg${p}`} onClick={() => setSelectedUndetctveh(i * 4 + j)}>
                        <Img src={`src/img/vehicle/${p}.png`}/>
                      </button>
                    </td>
                  ))}
                </tr>
              ))}
            </tbody>
          </table>
          <button id="learn-vehicle" onClick={() => learnVehicle()}>Learn</button>
        </div>
      </div>
    </div>
  );
}

export default CCTVInfo;
