import React, { useState, useRef, useEffect } from 'react';
import * as d3 from 'd3'

const width = 300;
const height = 300;
const hidden = {
  display: 'none',
};

function NodeGraph(props) {
  const { placeData, groupedCctv } = props;
  const [visible, setVisible] = useState(false)
  const ref = useRef();

  const svgElement = d3.select(ref.current);

  useEffect(() => {
    if (Object.keys(groupedCctv).length > 0) {
      setVisible(true)
      svgElement.selectAll("*").remove();
      drawGraph()
    }
    else {
      setVisible(false)
      svgElement.selectAll("*").remove();
    }
  }, [groupedCctv]);

  const drawGraph = () => {
    const data = convertPlaceDataToFDGData(groupedCctv);

    const links = data.links.map(d => Object.create(d));
    const nodes = data.nodes.map(d => Object.create(d));

    const simulation = d3.forceSimulation(nodes)
      .force("link", d3.forceLink(links).id(d => d.id))
      .force("charge", d3.forceManyBody())
      .force("center", d3.forceCenter(width / 2, height / 2));

    const link = svgElement.append("g")
      .attr("stroke", "#fff")
      .attr("stroke-opacity", 0.6)
    .selectAll("line")
    .data(links)
    .join("line")
      .attr("stroke-width", "5px")

    const node = svgElement.append("g")
      .attr("stroke", "#fff")
      .attr("stroke-width", 1.5)
    .selectAll("circle")
    .data(nodes)
    .join("circle")
      .attr("r", 10)
      .attr("fill", "white")
      .call(drag(simulation));

    node.append("title")
      .text(d => d.id)

    simulation.on("tick", () => {
      link
        .attr("x1", d => d.source.x)
        .attr("y1", d => d.source.y)
        .attr("x2", d => d.target.x)
        .attr("y2", d => d.target.y);
    
      node
        .attr("cx", d => d.x)
        .attr("cy", d => d.y);
    });
  };

  const drag = (simulation) => {
    function dragstarted(event) {
      if (!event.active) simulation.alphaTarget(0.3).restart();
      event.subject.fx = event.subject.x;
      event.subject.fy = event.subject.y;
      }
      
      function dragged(event) {
      event.subject.fx = event.x;
      event.subject.fy = event.y;
      }
      
      function dragended(event) {
      if (!event.active) simulation.alphaTarget(0);
      event.subject.fx = null;
      event.subject.fy = null;
      }
      
      return d3.drag()
        .on("start", dragstarted)
        .on("drag", dragged)
        .on("end", dragended);
  }

  const convertPlaceDataToFDGData = (places) => {
    let graphData = {
      nodes: [],
      links: []
    };

    for (let cctv in places) {
      let place = places[cctv];

      graphData.nodes.push({
        id: place.channel,
        name: place.cctvStrtSecnNm,
        direction: place.direction
      });

      for (let linked of place.linked) {
        let linkedPlace = placeData[linked];
        if (linkedPlace && places[linkedPlace.channel]) {
          let linkData = {
            source: place.channel,
            target: linkedPlace.channel,
            edgeCount: 1
          };
          graphData.links.push(linkData);
        }
      }
    }

    return graphData;
  };

  return (
    <svg
      style={{...(visible ? null : hidden)}}
      width={width}
      height={height}
      ref={ref}
    />
  );
}

export default NodeGraph;