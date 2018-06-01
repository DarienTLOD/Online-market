import 'chart.js'

var ctx = document.getElementById("myChart").getContext('2d');
var myChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: ["Wood", "Iron", "Oil"],
        datasets: [{
            data: [42, 13, 23],
            backgroundColor: [
                'rgba(130, 82, 1, 0.5)',
                'rgba(203, 205, 205, 0.5)',
                'rgba(27, 27, 27, 0.5)'
            ],
            borderColor: [
                'rgba(255, 255, 255, 1)',
                'rgba(255, 255, 255, 1)',
                'rgba(255, 255, 255, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        responsive: false,
        maintainAspectRatio: false
    }
});