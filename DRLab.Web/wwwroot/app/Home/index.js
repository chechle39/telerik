var ctx = document.getElementById('home__chart1').getContext('2d');
var chart1 = new Chart(ctx, {
                responsive: true,
                maintainAspectRatio: false,
                aspectRatio: 5,
                type: 'bar',
                data: {
                    labels: ['Thứ 2', 'Thứ 3', 'Hôm nay', 'Thứ 5', 'Thứ 6'],
                    datasets: [{
                        label: 'In progress',
                        data: [12, 19, 3],
                        backgroundColor: ['#bbb', '#bbb', '#0071c1', '#0071c1', '#0071c1']
                    },
                    {
                        label: 'Completed',
                        data: [19, 20, 7, 0, 14],
                        backgroundColor: '#e46c0d'
                    }]
                },
                options: {
                    plugins: {
                        datalabels: {
                            formatter: function (value, context) {
                                return context.chart.config.data.datasets.reduce((sum, dataset) => sum + dataset.data[context.dataIndex] || 0, 0);
                            },
                            display: function (context) {
                                return context.datasetIndex === context.chart.config.data.datasets.length - 1;
                            },
                            anchor: 'end',
                            align: 'top',
                            offset: -5,

                        }
                    },
                    scales: {
                        xAxes: [{
                            stacked: true,
                            gridLines: {
                                display: false,
                                drawBorder: false,
                            },
                        }],
                        yAxes: [{
                            stacked: true,
                        }]
                    },
                    legend: {
                        labels: {
                            boxWidth: 10,
                        }
                    }
                }
            });
function chart1GetByWeek() {
    chart1.data = {
        labels: ['4 weeks ago', '3 weeks ago', '2 weeks ago', 'Last week', 'This week'],
        datasets: [{
            label: 'In progress',
            data: [12, 19, 3, 5, 2],
            backgroundColor: ['#bbb', '#bbb', '#0071c1', '#0071c1', '#0071c1']
        },
        {
            label: 'Completed',
            data: [19, 20, 7, 0, 14],
            backgroundColor: '#e46c0d'
        }]
    };
    chart1.update();
}
function chart1GetByDay() {
    chart1.data = {
        labels: ['Thứ 2', 'Thứ 3', 'Hôm nay', 'Thứ 5', 'Thứ 6'],
        datasets: [{
            label: 'In progress',
            data: [7, 19, 13, 23, 5],
            backgroundColor: ['#bbb', '#bbb', '#0071c1', '#0071c1', '#0071c1']
        },
        {
            label: 'Completed',
            data: [12, 25, 3, 4, 17],
            backgroundColor: '#e46c0d'
        }]
    };
    chart1.update();
}

var ctx = document.getElementById('home__chart2').getContext('2d');
var chart2 = new Chart(ctx, {
    aspectRatio: 1.6,
    type: 'horizontalBar',
    data: {
        labels: ['Total', 'Completed', 'In progress', 'Delay'],
        datasets: [{
            data: [12, 19, 3, 5, 3],
            backgroundColor: ['rgb(191, 191, 191)', '#4d75a8', 'rgb(250, 192, 144)', 'rgb(255, 0, 0)'],
        }]
    },

    options: {
        plugins: {
            datalabels: {
                color: '#000'
            }
        },
        scales: {
            xAxes: [{
                stacked: true,
                gridLines: {
                    display: false,
                    drawBorder: false,
                },
                ticks: {
                    display: false
                }
            }],
            yAxes: [{
                stacked: true,
                gridLines: {
                    display: false,
                    drawBorder: false,
                },
                ticks: {
                    fontColor: 'rgb(0, 112, 192)',
                    fontSize: 15,
                }
            }]
        },
        legend: {
            display: false,
        }
    }
});
function chart2GetByMonth() {
    chart2.data = {
        labels: ['Total', 'Completed', 'In progress', 'Delay'],
        datasets: [{
            data: [12, 19, 3, 5, 3],
            backgroundColor: ['rgb(191, 191, 191)', '#4d75a8', 'rgb(250, 192, 144)', 'rgb(255, 0, 0)'],
        }]
    };
    chart2.update();
}
function chart2GetByWeek() {
    chart2.data = {
        labels: ['Total', 'Completed', 'In progress', 'Delay'],
        datasets: [{
            data: [22, 1, 13, 15, 3],
            backgroundColor: ['rgb(191, 191, 191)', '#4d75a8', 'rgb(250, 192, 144)', 'rgb(255, 0, 0)'],
        }]
    };
    chart2.update();
}

var ctx = document.getElementById('home__chart3').getContext('2d');
var chart3 = new Chart(ctx, {
    aspectRatio: 1.6,
    type: 'horizontalBar',
    data: {
        labels: ['Total', 'Recorded', 'Accepted', 'Approved', 'Recheck'],
        datasets: [{
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: ['rgb(191, 191, 191)', '#4d75a8', 'rgb(250, 192, 144)', 'rgb(250, 192, 144)', 'rgb(255, 0, 0)'],
        }]
    },

    options: {
        plugins: {
            datalabels: {
                color: '#000'
            }
        },
        scales: {
            xAxes: [{
                stacked: true,
                gridLines: {
                    display: false,
                    drawBorder: false,
                },
                ticks: {
                    display: false
                }
            }],
            yAxes: [{
                stacked: true,
                gridLines: {
                    display: false,
                    drawBorder: false,
                },
                ticks: {
                    fontColor: 'rgb(0, 112, 192)',
                    fontSize: 15,
                }
            }]
        },
        legend: {
            display: false,
        }
    }
});
function chart3GetByMonth() {
    chart3.data = {
        labels: ['Total', 'Recorded', 'Accepted', 'Approved', 'Recheck'],
        datasets: [{
            data: [12, 19, 3, 5, 2],
            backgroundColor: ['rgb(191, 191, 191)', '#4d75a8', 'rgb(250, 192, 144)', 'rgb(250, 192, 144)', 'rgb(255, 0, 0)'],
        }]
    };
    chart3.update();
}
function chart3GetByWeek() {
    chart3.data = {
        labels: ['Total', 'Recorded', 'Accepted', 'Approved', 'Recheck'],
        datasets: [{
            data: [22, 22, 13, 5, 2],
            backgroundColor: ['rgb(191, 191, 191)', '#4d75a8', 'rgb(250, 192, 144)', 'rgb(250, 192, 144)', 'rgb(255, 0, 0)'],
        }]
    };
    chart3.update();
}

var ctx = document.getElementById('home__chart4').getContext('2d');
var chart4 = new Chart(ctx, {
    aspectRatio: 1.6,
    type: 'line',
    data: {
        labels: ['Feb', 'Mar', 'Apr', 'May', 'Jun'],
        datasets: [{
            data: [12, 19, 3, 5, 2],
            backgroundColor: ['#F2D7D5', '#F2D7D5', '#A93226', '#D98880', '#D98880'],
            label: 'Series1',
            backgroundColor: '#4d75a8',
            borderColor: '#4d75a8',
            borderCapStyle: 'square',
            fill: false,
            lineTension: 0,
            pointStyle: 'rect',
        }]
    },
    options: {
        plugins: {
            datalabels: {
                display: false,
            }
        },
        scales: {
            xAxes: [
                {
                    gridLines: {
                        offsetGridLines: true,
                        display: false,
                    },
                    ticks: {
                        fontColor: '#000',
                    },
                    offset: true,
                },
            ],
            yAxes: [
                {
                    gridLines: {
                        display: true,
                        color: '#858585',
                    },
                    ticks: {
                        fontColor: '#000',
                        fontFamily: 'Montserrat',
                        precision: 3,
                        beginAtZero: true,
                    },
                },
            ],
        },
        legend: {
            display: false,
        }
    }
});
function chart4GetByMonth() {
    chart4.data = {
        labels: ['4 Months ago', '3 Months ago', '2 Months ago', 'Last Month', 'This Month'],
            datasets: [{
                data: [12, 19, 3, 5, 2],
                backgroundColor: ['#F2D7D5', '#F2D7D5', '#A93226', '#D98880', '#D98880'],
                label: 'Series1',
                backgroundColor: '#4d75a8',
                borderColor: '#4d75a8',
                borderCapStyle: 'square',
                fill: false,
                lineTension: 0,
                pointStyle: 'rect',
            }]
    };
    chart4.update();
}
function chart4GetByQuarter() {
    chart4.data = {
        labels: ['4 Quarters ago', '3 Quarters ago', '2 Quarters ago', 'Last Quarter', 'This Quarter'],
            datasets: [{
                data: [12, 19, 3, 5, 2],
                backgroundColor: ['#F2D7D5', '#F2D7D5', '#A93226', '#D98880', '#D98880'],
                label: 'Series1',
                backgroundColor: '#4d75a8',
                borderColor: '#4d75a8',
                borderCapStyle: 'square',
                fill: false,
                lineTension: 0,
                pointStyle: 'rect',
            }]
    };
    chart4.update();
}