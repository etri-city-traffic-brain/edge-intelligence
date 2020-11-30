$(document).ready(function() {
  var trafficFlowData = {
    speed: [43, 52, 57, 69, 97, 79, 67, 54, 43, 52, 57, 69, 97, 79, 67, 54, 43, 52, 57, 69, 97, 79, 67, 54],
    volume: [249, 240, 297, 298, 324, 302, 381, 404, 249, 240, 297, 298, 324, 302, 381, 404, 249, 240, 297, 298, 324, 302, 381, 404]
  };
  drawTrafficFlow(trafficFlowData);

  var propagationTreeData = {
    name: 'A',
    children: [
      {
        name: 'B',
        children: [
          {name: 'C'}, {name:'D'},
          {
            name: 'E',
            children: [{name: 'F'}, {name: 'G'}]
          }
        ]
      }
    ]
  };
  drawPropagationTree(propagationTreeData);

  var congestionHeatmapData = [ // [시간(8~23), 요일(0~6), 값]
    [8,0,132],[9,0,104],[10,0,19],[11,0,62],[12,0,12],[13,0,124],[14,0,103],[15,0,47],[16,0,121],[17,0,10],[18,0,88],[19,0,70],[20,0,20],[21,0,43],[22,0,26],[23,0,30],
    [8,1,104],[9,1,110],[10,1,144],[11,1,149],[12,1,2],[13,1,76],[14,1,78],[15,1,40],[16,1,11],[17,1,33],[18,1,94],[19,1,113],[20,1,1],[21,1,146],[22,1,65],[23,1,105],
    [8,2,67],[9,2,74],[10,2,79],[11,2,13],[12,2,90],[13,2,13],[14,2,84],[15,2,129],[16,2,124],[17,2,64],[18,2,115],[19,2,17],[20,2,148],[21,2,147],[22,2,57],[23,2,129],
    [8,3,120],[9,3,43],[10,3,30],[11,3,144],[12,3,129],[13,3,50],[14,3,105],[15,3,42],[16,3,27],[17,3,92],[18,3,80],[19,3,137],[20,3,114],[21,3,75],[22,3,122],[23,3,102],
    [8,4,17],[9,4,67],[10,4,118],[11,4,113],[12,4,86],[13,4,88],[14,4,107],[15,4,119],[16,4,67],[17,4,24],[18,4,7],[19,4,73],[20,4,99],[21,4,99],[22,4,48],[23,4,77],
    [8,5,7],[9,5,104],[10,5,26],[11,5,101],[12,5,132],[13,5,100],[14,5,116],[15,5,67],[16,5,143],[17,5,147],[18,5,35],[19,5,16],[20,5,8],[21,5,82],[22,5,80],[23,5,38],
    [8,6,67],[9,6,23],[10,6,2],[11,6,97],[12,6,39],[13,6,57],[14,6,78],[15,6,47],[16,6,133],[17,6,115],[18,6,119],[19,6,115],[20,6,29],[21,6,138],[22,6,149],[23,6,132]
  ];
  drawCongestionHeatmap(congestionHeatmapData);
});

function drawTrafficFlow(data) {
  Highcharts.chart('traffic-flow', {

    title: {
      text: 'Traffic flow'
    },

    yAxis: [{
      title: {
        text: 'Speed'
      },
      labels: {
        style: {
          fontSize: 14
        }
      }
    }, {
      title: {
        text: 'Volume'
      },
      labels: {
        style: {
          fontSize: 14
        }
      },
      opposite: true
    }],

    credits: {
      enabled: false
    },

    xAxis: {
      categories: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23],
      labels: {
        style: {
          fontSize: 14
        }
      }
    },

    legend: {
      layout: 'vertical',
      align: 'right',
      verticalAlign: 'top',
      floating: true,
      x: -65,
      y: -10
    },

    plotOptions: {
      series: {
        label: {
          connectorAllowed: false
        },
        pointStart: 0
      },
      line: {
        marker: {
          enabled: false
        }
      }
    },

    series: [{
      yAxis: 0,
      name: 'Speed',
      tooltip: {
        valueSuffix: 'km/h'
      },
      data: data.speed
    }, {
      yAxis: 1,
      name: 'Volume',
      tooltip: {
        valueSuffix: ' units'
      },
      data: data.volume
    }],

    responsive: {
      rules: [{
        condition: {
          maxWidth: 500
        },
        chartOptions: {
          legend: {
            layout: 'horizontal',
            align: 'center',
            verticalAlign: 'bottom'
          }
        }
      }]
    }

  });
}

function drawPropagationTree(data) {
  var treeData = data;

  /*var margin = {top: 20, right: 120, bottom: 20, left: 120},
    width = 960 - margin.right - margin.left,
    height = 500 - margin.top - margin.bottom;*/
  var section = d3.select('#propagation-tree').html('').classed('empty', false);
  var header = section.append("div").attr("class", "header").text("Propagation Tree");

  var width = parseInt(section.style('width')) - parseInt(section.style('border-left-width')) - parseInt(section.style('border-right-width'));
  var height = parseInt(section.style('height')) - parseInt(section.style('border-top-width')) - parseInt(section.style('border-bottom-width'))
    - parseInt(header.style('height')) - parseInt(header.style('margin-top')) - parseInt(header.style('margin-bottom'));
  var margin = {top: 10, right: 70, bottom: 10, left: 70};


  // append the svg object to the body of the page
  // appends a 'group' element to 'svg'
  // moves the 'group' element to the top left margin
  var svg = section.append("svg")
    .attr("width", width)
    .attr("height", height)
    .append("g")
    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

  svg
    .append("svg:defs")
    .selectAll("marker")
    .data(["end"]) // Different link/path types can be defined here
    .enter()
    .append("svg:marker") // This section adds in the arrows
    .attr("id", String)
    .attr("viewBox", "0 -5 10 10")
    .attr("refX", 1)
    .attr("refY", 0)
    .attr("markerWidth", 5)
    .attr("markerHeight", 5)
    .attr("orient", "auto-start-reverse")
    .style("fill", "#555")
    .append("svg:path")
    .attr("d", "M0,-5L10,0L0,5");

  var i = 0,
    duration = 0,
    root;

  // declares a tree layout and assigns the size
  var treemap = d3.tree().size([height, width]);

  // Assigns parent, children, height, depth
  root = d3.hierarchy(treeData, function(d) {
    return d.children;
  });
  root.x0 = height / 2;
  root.y0 = 0;

  // Collapse after the second level
  //root.children.forEach(collapse);

  update(root);

  // Collapse the node and all it's children
  function collapse(d) {
    if (d.children) {
      d._children = d.children;
      d._children.forEach(collapse);
      d.children = null;
    }
  }

  function update(source) {
    // Assigns the x and y position for the nodes
    var treeData = treemap(root);

    // Compute the new tree layout.
    var nodes = treeData.descendants(),
      links = treeData.descendants().slice(1);

    // Normalize for fixed-depth.
    nodes.forEach(function(d) {
      d.y = d.depth * 50;
    });

    // ****************** Nodes section ***************************

    // Update the nodes...
    var node = svg.selectAll("g.node").data(nodes, function(d) {
      return d.id || (d.id = ++i);
    });

    // Enter any new modes at the parent's previous position.
    var nodeEnter = node
      .enter()
      .append("g")
      .attr("class", "node")
      .attr("transform", function(d) {
        return "translate(" + source.y0 + "," + source.x0 + ")";
      })
      .on("click", click);

    // Add Circle for the nodes
    nodeEnter
      .filter(function(d) {
        return !d.data.type || d.data.type !== "data";
      })
      .append("circle")
      .attr("class", "node")
      .attr("r", 1e-6)
      .style("fill", function(d) {
        return d._children ? "#ddd" : "#fff";
      });

    nodeEnter
      .filter(function(d) {
        return d.data.type && d.data.type === "data";
      })
      .append("rect")
      .attr("class", "node")
      .attr("width", 30)
      .attr("height", 20)
      .attr("y", -10)
      .attr("x", -10)
      .style("fill", function(d) {
        return d._children ? "#ddd" : "#fff";
      });

    // Add labels for the nodes
    nodeEnter
      .append("text")
      .attr("dy", ".35em")
      .attr("dx", "-.35em")
      /*.attr("x", function(d) {
        return d.children || d._children ? 13 : 13;
      })*/
      .attr("text-anchor", function(d) {
        return d.children || d._children ? "start" : "start";
      })
      .text(function(d) {
        return d.data.name;
      });

    // UPDATE
    var nodeUpdate = nodeEnter.merge(node);

    // Transition to the proper position for the node
    nodeUpdate
      .transition()
      .duration(duration)
      .attr("transform", function(d) {
        return "translate(" + d.y + "," + d.x + ")";
      });

    // Update the node attributes and style
    nodeUpdate
      .select("circle.node")
      .attr("r", 10)
      .style("fill", function(d) {
        return d._children ? "#ddd" : "#fff";
      })
      .attr("cursor", "pointer");

    // Remove any exiting nodes
    var nodeExit = node
      .exit()
      .transition()
      .duration(duration)
      .attr("transform", function(d) {
        return "translate(" + source.y + "," + source.x + ")";
      })
      .remove();

    // On exit reduce the node circles size to 0
    nodeExit.select("circle").attr("r", 1e-6);

    // On exit reduce the opacity of text labels
    nodeExit.select("text").style("fill-opacity", 1e-6);

    // ****************** links section ***************************

    // Update the links...
    var link = svg.selectAll("g.link").data(links, function(d) {
      return d.id;
    });

    // Enter any new links at the parent's previous position.
    var linkEnter = link
      .enter()
      .insert("g", "g")
      .attr("class", "link");

    linkEnter
      .append("text")
      .attr("class", "linkLabels")
      .text(function(d, i) {
        if (d.parent && d.parent.children.length > 1) {
          if (!d.parent.index) d.parent.index = 0;
          return d.data.linkname;
        }
      })
      .attr("opacity", 0)
      .attr("dy", "-1em");

    linkEnter
      .append("path")
      .attr("d", function(d) {
        var o = {
          x: source.x0,
          y: source.y0
        };
        return diagonal(o, o);
      })
      .on("mouseover", function() {
        d3.select(this.parentNode)
          .select("text")
          .attr("opacity", 1);
      })
      .on("mouseleave", function() {
        d3.select(this.parentNode)
          .select("text")
          .attr("opacity", 0);
      })
      .attr("stroke-linecap", "round")
      .attr("marker-start", "url(#end)");

    // UPDATE
    var linkUpdate = linkEnter.merge(link);

    // Transition back to the parent element position
    linkUpdate
      .select("path")
      .transition()
      .duration(duration)
      .attr("d", function(d) {
        var o = {
          x: d.x,
          y: d.y - 20
        };
        return diagonal(o, d.parent);
      });

    linkUpdate
      .select("text")
      .transition()
      .duration(duration)
      .attr("transform", function(d) {
        if (d.parent) {
          return (
            "translate(" +
            (d.parent.y + d.y) / 2 +
            "," +
            (d.parent.x + d.x) / 2 +
            ")"
          );
        }
      });

    // Remove any exiting links
    link.exit().each(function(d) {
      d.parent.index = 0;
    });

    var linkExit = link
      .exit()
      .transition()
      .duration(duration);

    linkExit.select("path").attr("d", function(d) {
      var o = {
        x: source.x,
        y: source.y
      };
      return diagonal(o, o);
    });

    linkExit.select("text").style("opacity", 0);

    linkExit.remove();

    // Store the old positions for transition.
    nodes.forEach(function(d) {
      d.x0 = d.x;
      d.y0 = d.y;
    });

    // Creates a curved (diagonal) path from parent to the child nodes
    function diagonal(s, d) {
      path = `M ${s.y} ${s.x}
              C ${(s.y + d.y) / 2} ${s.x},
                  ${(s.y + d.y) / 2} ${d.x},
                  ${d.y} ${d.x}`;
      return path;
    }

    // Toggle children on click.
    function click(d) {
      if (d.children) {
        d._children = d.children;
        d.children = null;
      } else {
        d.children = d._children;
        d._children = null;
      }
      update(d);
    }
  }
}

function getPointCategoryName(point, dimension) {
  var series = point.series,
    isY = dimension === 'y',
    axis = series[isY ? 'yAxis' : 'xAxis'];
  return axis.categories[point[isY ? 'y' : 'x']];
}

function drawCongestionHeatmap(data) {
  Highcharts.chart('congestion-heatmap', {

    chart: {
      type: 'heatmap',
      marginTop: 40,
      marginBottom: 40,
      plotBorderWidth: 1
    },

    title: {
      text: 'Cause of congestion'
    },
    
    credits: {
      enabled: false
    },

    xAxis: {
      //categories: [8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23],
      tickInterval: 1,
      labels: {
        style: {
          fontSize: 14
        }
      }
    },

    yAxis: {
      categories: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
      title: null,
      reversed: true,
      labels: {
        step: 1,
        style: {
          fontSize: 14
        }
      }
    },

    colorAxis: {
      /*min: 0,
      minColor: '#FFFFFF',
      maxColor: Highcharts.getOptions().colors[0],*/
      dataClasses: [{
        from: 0,
        to: 50,
        color: 'rgb(192,0,0)'
      }, {
        from: 50,
        to: 100,
        color: 'rgb(254,199,31)'
      }, {
        from: 100,
        to: 150,
        color: 'rgb(0,176,80)'
      }]
    },

    legend: {
      align: 'right',
      layout: 'vertical',
      margin: 0,
      verticalAlign: 'top',
      y: 23,
      symbolHeight: 10
    },

    tooltip: {
      formatter: function () {
        var yText = getPointCategoryName(this.point, 'y');
        return '<b>' + this.point.x + ', ' + yText + '</b><br>' +
          this.point.value + '</b> units';
      }
    },

    series: [{
      name: 'Traffic per day',
      borderWidth: 1,
      data: data,
      dataLabels: {
        enabled: false,
        color: '#000000'
      }
    }],

    responsive: {
      rules: [{
        condition: {
          maxWidth: 500
        },
        chartOptions: {
          yAxis: {
            labels: {
              formatter: function () {
                return this.value.charAt(0);
              }
            }
          }
        }
      }]
    }

  });
}