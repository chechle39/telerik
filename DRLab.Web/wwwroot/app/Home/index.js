var ctx = document.getElementById('home__chart1').getContext('2d');
            var myChart = new Chart(ctx, {
                responsive: true,
                maintainAspectRatio: false,
                aspectRatio: 5,
                type: 'bar',
                data: {
                    labels: ['Red', 'Blue', 'Yellow', 'Green', 'Orange'],
                    datasets: [{
                        label: '# of Votes',
                        data: [12, 19, 3, 5, 2, 3],
                        backgroundColor: ['#F2D7D5', '#F2D7D5', '#A93226', '#D98880', '#D98880'],
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });

var ctx = document.getElementById('home__chart2').getContext('2d');
var myChart = new Chart(ctx, {
    responsive: true,
    maintainAspectRatio: false,
    aspectRatio: 1.6,
    type: 'bar',
    data: {
        labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
        datasets: [{
                label: '# of Votes',
                data: [12, 19, 3, 5, 2, 3],
                backgroundColor: '#0071c1'
            },
            {
                label: '# of Votes',
                data: [19, 20, 7, 0, 14, 30],
                backgroundColor: '#e46c0d'
            }]
    },
    options: {
        scales: {
            xAxes: [{
                stacked: true,
                ticks: {
                    beginAtZero: true
                }
            }],
            yAxes: [{
                stacked: true
            }]
        }
    }
});

var ctx = document.getElementById('home__chart3').getContext('2d');
var myChart = new Chart(ctx, {
    aspectRatio: 1.6,
    type: 'horizontalBar',
    data: {
        labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
        datasets: [{
            label: '# of Votes',
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: '#4d75a8',
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});

var ctx = document.getElementById('home__chart4').getContext('2d');
var myChart = new Chart(ctx, {
    aspectRatio: 1.6,
    type: 'bar',
    data: {
        labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple'],
        datasets: [{
            label: '# of Votes',
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: ['#F2D7D5', '#F2D7D5', '#A93226', '#D98880', '#D98880'],
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});