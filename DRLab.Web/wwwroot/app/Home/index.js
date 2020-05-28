
/**
 *  Chart1 Section
 * */
var ctx = document.getElementById('home__chart1').getContext('2d');
var chart1 = new Chart(ctx, {
                responsive: true,
                maintainAspectRatio: false,
                aspectRatio: 5,
                type: 'bar',
                data: {
                    labels: [moment().subtract(2, 'days').format("dddd"), moment().subtract(1, 'days').format("dddd"), 'Hôm nay', moment().add(1, 'days').format("dddd"), moment().add(2, 'days').format("dddd")],
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
                    onClick: function () {
                        if (this.active[0]) {
                            let start, end;
                            switch (this.active[0]._model.label) {
                                case "This week":
                                    start = moment().startOf('isoWeek');
                                    end = moment().endOf('isoWeek');
                                    break;
                                case "Last week":
                                    start = moment().subtract(1, 'weeks').startOf('isoWeek');
                                    end = moment().subtract(1, 'weeks').endOf('isoWeek');
                                    break;
                                case "2 weeks ago":
                                    start = moment().subtract(2, 'weeks').startOf('isoWeek');
                                    end = moment().subtract(2, 'weeks').endOf('isoWeek');
                                    break;
                                case "3 weeks ago":
                                    start = moment().subtract(3, 'weeks').startOf('isoWeek');
                                    end = moment().subtract(3, 'weeks').endOf('isoWeek');
                                    break;
                                case "4 weeks ago":
                                    start = moment().subtract(4, 'weeks').startOf('isoWeek');
                                    end = moment().subtract(4, 'weeks').endOf('isoWeek');
                                    break;
                                default:
                                    switch (this.active[0].$datalabels[0].$context.dataIndex) {
                                        case 0:
                                            start = moment().subtract(2, 'days');
                                            end = moment().subtract(2, 'days');
                                            break;
                                        case 1:
                                            start = moment().subtract(1, 'days');
                                            end = moment().subtract(1, 'days');
                                            break;
                                        case 2:
                                            start = moment();
                                            end = moment();
                                            break;
                                        case 3:
                                            start = moment().add(1, 'days');
                                            end = moment().add(1, 'days');
                                            break;
                                        case 4:
                                            start = moment().add(2, 'days');
                                            end = moment().add(2, 'days');
                                            break;
                                    }
                            }
                            const DATEFORMAT = "DD/MM/YYYY";
                            window.location = `/ManagementRequest?start=${start.format(DATEFORMAT)}&end=${end.format(DATEFORMAT)}`;
                        }
                    },
                    hover: {
                        onHover: function (e, element) {
                            const point = this.getElementAtEvent(e);
                            if (point.length) e.target.style.cursor = 'pointer';
                            else e.target.style.cursor = 'default';
                        },
                    },
                    events: ['mousemove', 'click'],
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
                    },
                    tooltips: {
                        intersect: false,
                        callbacks: {
                            label: function (tooltipItems, data) {
                                return tooltipItems.yLabel;
                            },
                        },
                        custom: function (tooltipModel) {
                            //// Tooltip Element
                            //var tooltipEl = document.getElementById('chartjs-tooltip');

                            //// Create element on first render
                            //if (!tooltipEl) {
                            //    tooltipEl = document.createElement('div');
                            //    tooltipEl.id = 'chartjs-tooltip';
                            //    tooltipEl.innerHTML = '<table></table>';
                            //    document.body.appendChild(tooltipEl);
                            //}

                            //// Hide if no tooltip
                            //if (tooltipModel.opacity === 0) {
                            //    tooltipModel.style.opacity = 0;
                            //    return;
                            //}

                            

                            //// `this` will be the overall tooltip
                            //var position = this._chart.canvas.getBoundingClientRect();
                            //console.log(position);
                            //console.log(tooltipModel);
                            //// Display, position, and set styles for font
                            //tooltipEl.style.opacity = 1;
                            //tooltipEl.style.position = 'absolute';
                            //tooltipEl.style.background = "red";
                            //tooltipEl.style.left = position.left + window.pageXOffset + tooltipModel.x + 'px';
                            //tooltipEl.style.top = position.top + window.pageYOffset + tooltipModel.y + 'px';
                            //tooltipEl.style.width = tooltipModel.width + 'px';
                            //tooltipEl.style.height = tooltipModel.height + 'px';
                            //tooltipEl.style.fontFamily = tooltipModel._bodyFontFamily;
                            //tooltipEl.style.fontSize = tooltipModel.bodyFontSize + 'px';
                            //tooltipEl.style.fontStyle = tooltipModel._bodyFontStyle;
                            //tooltipEl.style.padding = tooltipModel.yPadding + 'px ' + tooltipModel.xPadding + 'px';
                            //tooltipEl.style.cursor = 'pointer';
                        },
                    },
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

/**
 *  Chart2 Section
 * */
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

/**
 *  Chart3 Section
 * */
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

/**
 *  Chart4 Section
 * */
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
var dialog = $('#dialogSerchRequest');


dialog.kendoDialog({
    width: "422px",
    title: "Select Request",
    closable: true,
    modal: false,
    content: "",
    visible: false,
    actions: [
        { text: 'Cancel' },
        {
            text: 'Done', primary: true,
            action: okSearch,

        }
    ],
    //   close: onClose
});
function okSearch() {
    console.log("okSearch");
    var rqNo = $("#requestNo").val();
    
    if (rqNo === "") {
        var kendoWindow = $("<div />").kendoWindow({
            title: "Confirm",
            resizable: false,
            modal: true
        });

        kendoWindow.data("kendoWindow")
            .content($("#delete-confirmation").html())
            .center().open();

        kendoWindow
            .find(".delete-confirm,.delete-cancel")
            .click(function () {
                console.log('xxx');

                kendoWindow.data("kendoWindow").close();
               
            })
            .end()
        return false;
    } else {
        window.location = `/RecordResult?requestNo=${rqNo}`;
    }
    

}
$("#onClick").on('click', function () {
    var dialog = $('#dialogSerchRequest');
    dialog.data("kendoDialog").open();
});
