var trafficChart;
var entropyChart;

$(document).ready(function() {
  drawEntropySummaryChart();
});

// called by va-map.js
function drawTrafficChart(data) {
  trafficChart = Highcharts.chart('cctv-traffic', {
    chart: {
      //type: 'areaspline'
    },
    title: {
      text: 'Traffic Chart'
    },
    legend: {
      enabled: false
    },
    credits: {
      enabled:false
    },

    xAxis: {
      tickInterval: 5,
      labels: {
        style: {
          fontSize: 14
        }
      }
      //categories: xCategories
    },
    yAxis: {
      title: {
        text: ''
      },
      labels: {
        style: {
          fontSize: 14
        }
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
      line: {
        marker:{ enabled: false }
      }
    },
    series: [{
      name: 'Traffic',
      data: data,
      color:'#636363'
    }]
  });
}

// called by va-map.js
function drawEntropyChart(data) {
  entropyChart = Highcharts.chart('cctv-entropy', {
    chart: {
      //type: 'areaspline'
    },
    title: {
      text: 'Entropy Chart'
    },
    legend: {
      enabled: false
    },
    credits: {
      enabled: false
    },

    xAxis: {
      tickInterval: 5,
      labels: {
        style: {
          fontSize: 14
        }
      }
      //categories: xCategories
    },
    yAxis: {
      title: {
        text: ''
      },
      labels: {
        style: {
          fontSize: 14
        }
      }
    },
    tooltip: {
      shared: true,
      valueSuffix: ''
    },
    credits: {
      enabled: false
    },
    plotOptions: {
      line: {
        marker:{ enabled: false }
      }
    },
    series: [{
      name: 'Entropy',
      data: data,
      color:'#636363'
    }]
  });
}

function drawEntropySummaryChart() {
  Highcharts.chart('entropy-summary', {
    chart: {
      type: 'areaspline',
      height: 45
    },

    title: {
      text: null
    },
    
    credits: {
      enabled: false
    },
    
    xAxis: {
      labels: {
        enabled: false
      },
      categories: [],
      lineColor: '#555',
    },
    
    yAxis: {
      max: 0,
      title: {
        text: null
      },
      labels: {
        enabled: false
      },
      visible: false
    },

    plotOptions: {
      series: {
        dataLabels: {
          style: {
            color: '#555',
            fontWeight: 'normal'
          }
        },
        marker: {
          symbol: 'bullet',
          fillColor: '#555'
        }
      }
    },
  
    series: [{
      data: [[0,0]],
      dataLabels: {
        enabled: true,
        format: 'Min'
      }
    }, {
      data: [[10, 0]],
      dataLabels: {
        enabled: true,
        format: 'Max'
      }
    }],

    tooltip: {
      enabled: false
    },
    
    legend: {
      enabled: false
    }
  });
}