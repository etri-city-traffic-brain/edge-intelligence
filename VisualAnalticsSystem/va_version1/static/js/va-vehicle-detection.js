$(document).ready(function() {
  var cctvRecallData = [];
  for (var i = 0; i < 24; i++) {
    cctvRecallData.push([i, Math.floor(Math.random() * 10)]);
  }
  drawCCTVRecallChart(cctvRecallData);

  var vehicleRecallData = [];
  for (var i = 0; i < 24; i++) {
    vehicleRecallData.push([i, Math.floor(Math.random() * 10)]);
  }
  drawVehicleRecallChart(vehicleRecallData);

  drawUndetectedVehicles([
    {
      represent: "vehicle1.png",
      sublist: [
        "vehicle1.png", "vehicle1.png", "vehicle1.png", "vehicle1.png", "vehicle1.png", "vehicle1.png", "vehicle1.png", "vehicle1.png", "vehicle1.png", "vehicle1.png"
      ]
    }, {
      represent: "vehicle2.png",
      sublist: [
        "vehicle2.png", "vehicle2.png", "vehicle2.png", "vehicle2.png", "vehicle2.png", "vehicle2.png", "vehicle2.png", "vehicle2.png"
      ]
    }, {
      represent: "vehicle3.png",
      sublist: [
        "vehicle3.png", "vehicle3.png", "vehicle3.png", "vehicle3.png", "vehicle3.png", "vehicle3.png", "vehicle3.png", "vehicle3.png"
      ]
    }, {
      represent: "vehicle4.png",
      sublist: [
        "vehicle4.png", "vehicle4.png", "vehicle4.png", "vehicle4.png", "vehicle4.png", "vehicle4.png", "vehicle4.png", "vehicle4.png"
      ]
    },
  ]);
});

function drawCCTVRecallChart(data) {
  Highcharts.chart('recall-chart-cctv', {
    title: {
      text: 'Recall linechart(CCTV)'
    },
    legend: {
      enabled: false
    },
    credits: {
      enabled: false
    },

    xAxis: {
      //categories: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23],
      tickInterval: 5,
      labels: {
        style: {
          fontSize: 14
        }
      }
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
      name: 'Recall(CCTV)',
      data: data,
      color:'#636363'
    }]
  });
}

function drawVehicleRecallChart(data) {
  Highcharts.chart('recall-chart-vehicle', {
    title: {
      text: 'Recall linechart(Vehicle)'
    },
    legend: {
      enabled: false
    },
    credits: {
      enabled: false
    },

    xAxis: {
      //categories: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23],
      tickInterval: 5,
      labels: {
        style: {
          fontSize: 14
        }
      }
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
      name: 'Recall(Vehicle)',
      data: data,
      color:'#636363'
    }]
  });
}

function drawUndetectedVehicles(data) {
  var $section = $('#undetected-vehicles .undetected-vehicles-wrapper');
  for (var group of data) {
    var $list = $('<div>')
      .addClass('vehicle-list')
      .append($('<img>')
        .addClass('vehicle-image')
        .addClass('represent')
        .attr('src', `/static/img/vehicles/${group.represent}`))
      .appendTo($section);
    var $subList = $('<div>')
      .addClass('vehicle-sublist')
      .appendTo($list);

    for (var img of group.sublist) {
      $item = $('<div>')
        .addClass('image-item')
        .appendTo($subList);
      $('<img>')
        .addClass('vehicle-image')
        .attr('src', `/static/img/vehicles/${img}`)
        .appendTo($item);
      $('<div>')
        .addClass('cover')
        .appendTo($item);
      
      $item.on('click', function() {
        $(this).toggleClass('selected');
      })
    }
  }
}
