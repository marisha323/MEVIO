var link = document.getElementById("customStyle");
//link.href = "/css/year.css";
//link.href = "~/css/month.css";
//link.href = "/css/week.css";
//link.href = "/css/day.css";
// Get the HTML link element that references the CSS file 
//var link = document.querySelector("link[href='~/css/month.css']");
// Set the href property to the new CSS file path
//link.href = "/css/month.css";

$("#yearGrid").hide();
//$("#monthGrid").hide();
$("#weekGrid").hide();
$("#dayGrid").hide();


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
////////////////////////////////////////////////////////////////
//Year Animation   

window.scroll({
    top: 0,
    left: 0,
    behavior: 'smooth'
});








var grids = document.querySelectorAll(".calGrid");

function YearButtonClick() {
    document.body.style.overflowY = 'hidden';
    grids.forEach(grid => {
        if (grid.classList.contains("activeGrid")) {
            grid.classList.add("shrink");
            setTimeout(() => {
                grid.classList.add("go");
            }, 100);
            grid.classList.remove("activeGrid");

            grid.classList.remove("appearGrid");
            grid.classList.remove("hidden");
            grid.classList.remove("showw");
        }
        setTimeout(() => {
            grid.classList.remove("go");
            grid.classList.remove("shrink");
        }, 500);
    });
    yearGrid = document.getElementById("yearGrid");
    yearGrid.classList.add("activeGrid");

    yearGrid.classList.add("appearGrid");
    yearGrid.classList.add("hidden");

    setTimeout(() => {
        // link.hide("style/year.css");
        $("#monthGrid").hide();
        $("#weekGrid").hide();
        $("#dayGrid").hide();
    }, 300);
    setTimeout(() => {
        link.href = "/css/year.css";
        $("#yearGrid").show();
        setTimeout(() => {
            yearGrid.classList.add("showw");
        }, 200);
    }, 200);
    window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });

    document.body.style.overflowY = 'auto';
}
////////////////////////////////////////////////////////////////
//Month Animation



function WeekButtonClick() {
    $(".week-switcher:visible").hide();

    const currentWeek = document.getElementById("currentWeek");
    const id = currentWeek.value;
    
    $(`#week_${id}`).show();

    grids.forEach(grid => {
        if (grid.classList.contains("activeGrid")) {
            grid.classList.add("shrink");
            setTimeout(() => {
                grid.classList.add("go");
            }, 100);
            grid.classList.remove("activeGrid");

            grid.classList.remove("appearGrid");
            grid.classList.remove("hidden");
            grid.classList.remove("showw");
        }
        setTimeout(() => {
            grid.classList.remove("go");
            grid.classList.remove("shrink");
        }, 500);
    });
    weekGrid = document.getElementById("weekGrid");
    weekGrid.classList.add("activeGrid");

    weekGrid.classList.add("appearGrid");
    weekGrid.classList.add("hidden");

    setTimeout(() => {
        //link.hide("style/year.css");
        $("#yearGrid").hide();
        $("#monthGrid").hide();
        //$("#weekGrid").hide();
        $("#dayGrid").hide();
    }, 300);

    setTimeout(() => {
        link.href = "/css/week.css";
        $("#weekGrid").show();
        setTimeout(() => {
            weekGrid.classList.add("showw");
            document.body.style.overflowY = 'visible';
        }, 200);
    }, 200);
    window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });
}



function DayButtonClick() {

    $(".calendar-button").removeClass("active");
    $("#daybtn").addClass("active");

    const selectedDay = document.getElementById("selectedDay");
    const currentDay = document.getElementById("currentDayInput");
    selectedDay.value = currentDay.value;

    grids.forEach(grid => {
        if (grid.classList.contains("activeGrid")) {
            grid.classList.add("shrink");
            setTimeout(() => {
                grid.classList.add("go");
            }, 100);
            grid.classList.remove("activeGrid");

            grid.classList.remove("appearGrid");
            grid.classList.remove("hidden");
            grid.classList.remove("showw");
        }
        setTimeout(() => {
            grid.classList.remove("go");
            grid.classList.remove("shrink");
        }, 500);
    });
    dayGrid = document.getElementById("dayGrid");
    dayGrid.classList.add("activeGrid");

    dayGrid.classList.add("appearGrid");
    dayGrid.classList.add("hidden");

    $(dayGrid).show();

    setTimeout(() => {
        //link.hide("style/year.css");
        $("#yearGrid").hide();
        $("#monthGrid").hide();
        $("#weekGrid").hide();
        //$("#dayGrid").hide();
    }, 300);

    setTimeout(() => {
        link.href = "/css/day.css";
        $("#dayGrid").show();
        setTimeout(() => {
            dayGrid.classList.add("showw");
            document.body.style.overflowY = 'visible';
        }, 200);
    }, 200);
    window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });
}




const calendarButtons = document.querySelectorAll('.calendar-button');

calendarButtons.forEach(button => {
    button.addEventListener('click', () => {
        rightMenu.classList.remove("trans");
        container.classList.remove("eventShow");
    });
});
function closeMenu() {

    $(".right-task-menu").removeClass("trans");
}
