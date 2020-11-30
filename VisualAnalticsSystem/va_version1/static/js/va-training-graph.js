$(document).ready(function() {
  drawLearningCurve();
});

function drawLearningCurve() {
  Highcharts.chart('learning-curve', {
    chart: {
      type: 'spline'
    },

    title: {
      text: 'Learning curve'
    },
    legend: {
      enabled: false
    },
    credits: {
      enabled: false
    },

    xAxis: {
      lineColor: '#aaa',
      categories: [],
      title: {
        text: ''
      },
      labels: {
        enabled: false
      }
    },

    yAxis: {
      max: 10,
      lineColor: '#aaa',
      title: {
        text: ''
      },
      labels: {
        enabled: false
      }
    },
    tooltip: {
      enabled: false,
      shared: true,
      valueSuffix: ''
    },
    credits: {
      enabled: false
    },
    plotOptions: {
      spline: {
        marker:{
          enabled: false
        },
        fillOpacity: 0.2,
        lineWidth: 2,
      }
    },
    series: [{
      name: 'Learning curve',
      data: [
        [0, 0],
        [3, 1],
        [7, 9],
        [10, 10]
      ],
      color:'#636363'
    }]
  });
}
