document.querySelector("#addMembers").addEventListener("click", function (e) {

    document.getElementById("mainBox").style.display = "block";


});

console.log("kfig");
<script src="~/js/jquery-3.6.1.min.js" asp-append-version="true"></script>

$('#addMembers').click(function () {
    $("#mainBox").css("display", "block");
});

var dateBegin = document.getElementById("time1");
var dateEnd = document.getElementById("time2");

var date1 = document.getElementById("date1").value;
var date2 = document.getElementById("date2").value;

function updateDates() {
    var checkbox = document.getElementById("CheckAllDay");


    if (checkbox.checked) {
        date2.value = date1;
    } else {
        date2.value = "@ViewBag.DateEnd";
    }
}
function myFunction() {
    toggleElements('element-time');
    updateDates();
}

var dateInput = document.getElementById("date1");
dateInput.value = "@ViewBag?.Date";
var dateEnd = document.getElementById("date2");
dateEnd.value = "@ViewBag?.DateEnd";


function toggleElements(className) {
    var elements = document.getElementsByClassName(className);
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].style.display === "none") {
            elements[i].style.display = "block";
        } else {
            elements[i].style.display = "none";
        }
    }
}
