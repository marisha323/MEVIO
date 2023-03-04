var link = document.getElementById("customStyle");
link.href = "/css/year.css";
//link.href = "/css/month.css";
//link.href = "/css/week.css";
//link.href = "/css/day.css";
// Get the HTML link element that references the CSS file 
//var link = document.querySelector("link[href='~/css/month.css']");
// Set the href property to the new CSS file path
//link.href = "/css/month.css";

//$("#yearGrid").hide();
$("#monthGrid").hide();
$("#weekGrid").hide();
$("#dayGrid").hide();

function YearButtonClick() {
    


    

}




function MonthButtonClick() {
    
}


$(".calendar-button").on("click", function () {
    $(".calendar-button").removeClass("active");
    $(this).closest(".calendar-button").addClass("active");
})



$(".select-month").on("click", ClickMonth);
$(".select-years").on("click", ClickYears);




function ClickYears() {


    let arrow = $(this).closest(".select-years").find(".arrow");
    let years = $(".options-years");

    if ($(arrow).hasClass("rotate")) {
        $(arrow).removeClass("rotate");
        $(years).slideUp("fast");
    }
    else {
        $(arrow).addClass("rotate");
        $(years).slideDown("fast");
    }
}


function ClickMonth() {
    let arrow = $(this).closest(".select-month").find(".arrow");
    let monthes = $(".options-month");

    if ($(arrow).hasClass("rotate")) {
        $(arrow).removeClass("rotate");
        $(monthes).slideUp("fast");

    }
    else {
        $(arrow).addClass("rotate");
        $(monthes).slideDown("fast");
    }

}