var dt = new Date();

document.getElementById("demo").innerHTML = dt.toLocaleString();

var myVar = setInterval(function () { myTimer() }, 1000);

function myTimer() {

    var d = new Date();

    document.getElementById("demo").innerHTML = d.toLocaleString();

}