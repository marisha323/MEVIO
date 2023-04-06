var link = document.getElementById("customStyle");
//link.href = "/css/year.css";
//link.href = "~/css/month.css";
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

const divs = document.querySelectorAll('.month-div');

divs.forEach(div => {
    div.addEventListener('click', () => {

        divs.forEach(div1 => {
            if (div != div1) {
                div1.style.visibility = "hidden";
            }
        });

        setTimeout(() => {
            const screenWidth = window.innerWidth;
            const screenHeight = window.innerHeight;

            const middleX = screenWidth / 2;
            const middleY = screenHeight / 2;

            const divRect = div.getBoundingClientRect();
            const divWidth = divRect.width;
            const divHeight = divRect.height;
            const divOffsetTop = divRect.top + window.pageYOffset;
            const divOffsetLeft = divRect.left + window.pageXOffset;

            const currentScale = getComputedStyle(div).transform.match(/matrix\(([^)]+)\)/)[1].split(', ')[0];
            if (currentScale === '3') {
                div.style.transform = `translate(${middleX - (divWidth / 2) - divOffsetLeft}px, ${middleY - (divHeight / 2) - divOffsetTop}px) scale(1.0)`;
                setTimeout(function () {
                    divs.forEach(div1 => {
                        if (div != div1) {
                            div1.style.visibility = "visible";
                        }
                    });
                }, 500);
            } else {
                div.style.transform = `translate(${middleX - (divWidth / 2) - divOffsetLeft}px, ${middleY - (divHeight / 2) - divOffsetTop}px) scale(3)`;
            }
        }, 400);

        setTimeout(() => {
            const screenWidth = window.innerWidth;
            const screenHeight = window.innerHeight;

            const middleX = screenWidth / 2;
            const middleY = screenHeight / 2;

            const divRect = div.getBoundingClientRect();
            const divWidth = divRect.width;
            const divHeight = divRect.height;
            const divOffsetTop = divRect.top + window.pageYOffset;
            const divOffsetLeft = divRect.left + window.pageXOffset;

            const currentScale = getComputedStyle(div).transform.match(/matrix\(([^)]+)\)/)[1].split(', ')[0];

            if (currentScale === '3')
            {
                div.style.transform = `translate(${middleX - (divWidth / 2) - divOffsetLeft}px, ${middleY - (divHeight / 2) - divOffsetTop}px) scale(1.0)`;

                div.style.removeProperty('transform');

                setTimeout(function () {
                    divs.forEach(div1 => {
                        if (div != div1) {
                            div1.style.visibility = "visible";
                        }
                    });
                }, 500);

            }
            else if (currentScale === '1')
            {
                div.style.transform = `translate(${middleX - (divWidth / 2) - divOffsetLeft}px, ${middleY - (divHeight / 2) - divOffsetTop}px) scale(3)`;
            }
        }, 1000);

        setTimeout(function () {
            div.style.removeProperty('transform');
        }, 1000);
        const link = document.getElementById("customStyle");

        //div.classList.toggle('goAnimation');
        setTimeout(() => {
            // link.hide("style/year.css");
            $("#yearGrid").hide();
        }, 1000);

        setTimeout(() => {
            link.href = "/css/month.css";
            $("#monthGrid").show();
        }, 1000);

        let yearbtn = document.getElementById("yearbtn");
        yearbtn.classList.remove("active");

        let monthbtn = document.getElementById("monthbtn");
        monthbtn.classList.add("active");

        let yearGrid = document.getElementById("yearGrid");
        yearGrid.classList.add("shrink");
        yearGrid.classList.add("go");
        yearGrid.classList.remove("activeGrid");
        yearGrid.classList.remove("appearGrid");
        yearGrid.classList.remove("hidden");
        yearGrid.classList.remove("showw");
        yearGrid.classList.remove("go");
        yearGrid.classList.remove("shrink");

        let monthGrid = document.getElementById("monthGrid");
        monthGrid.classList.add("activeGrid")
        monthGrid.classList.add("appearGrid");
        monthGrid.classList.add("hidden");
        monthGrid.classList.add("showw");

    });

    div.classList.add("month-div-hover");
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

function MonthButtonClick() {
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
    monthGrid = document.getElementById("monthGrid");
    monthGrid.classList.add("activeGrid");

    monthGrid.classList.add("appearGrid");
    monthGrid.classList.add("hidden");

    setTimeout(() => {
        // link.hide("style/year.css");
        $("#yearGrid").hide();
        $("#weekGrid").hide();
        $("#dayGrid").hide();
    }, 300);

    setTimeout(() => {
        link.href = "/css/month.css";
        $("#monthGrid").show();
        setTimeout(() => {
            monthGrid.classList.add("showw");
        }, 200);
    }, 200);
    window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });

    document.body.style.overflowY = 'auto';
}


function WeekButtonClick() {
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

//Adding event to every month-day button to run an animation
//add day event or see event onclick
const monthDays = document.querySelectorAll('.month-day'); // Get all elements with the class 'month-day'
//menu
const rightMenu = document.getElementById("rightMenu");
//eventMini
const container = document.querySelector(".contener");

monthDays.forEach(day => {
    day.addEventListener('click', () => {

        const events = day.querySelectorAll('.event');

        // if(events.length > 0){
        //     const container = document.querySelector(".contener");
        //     events.forEach(event=>{
        //         event.addEventListener('click', ()=>{
        //             container.classList.toggle("eventShow");
        //         });
        //     });
        // }
        if (events.length == 0) {
            $(".right-task-menu").addClass("trans");
            //Sahsa закоментил и добавил JQuery
            //if (!container.classList.contains("eventShow")) {
            //    if (!rightMenu.classList.contains("trans")) {
            //        rightMenu.style.display = "block";
            //        setTimeout(() => {
            //            document.body.style.overflowY = "visible";
            //            rightMenu.classList.add("trans");
            //        }, 300)
            //    }
            //}
        }
        // You can replace the console.log statement with your desired functionality
    });
});
//const events = document.querySelectorAll('.event'); // Get all elements with the class 'event'
////Adding events for every <p> child that is inside the event div
//events.forEach(event => {
//    const paragraph = event.querySelector('p'); // Get the paragraph element inside the event
//    paragraph.addEventListener('click', () => {

//        if (!rightMenu.classList.contains("trans")) {

//            if (!container.classList.contains("eventShow")) {
//                container.classList.add("eventShow");
//            }
//            else {
//                container.classList.remove("eventShow");
//            }
//        }
//    });
//});
//if clicked on some kind of other calendar button while in the
//menu or some shit this happens
const calendarButtons = document.querySelectorAll('.calendar-button');

calendarButtons.forEach(button => {
    button.addEventListener('click', () => {
        rightMenu.classList.remove("trans");
        container.classList.remove("eventShow");
    });
});
function closeMenu() {
    //Sasha commented and add JQuery
    //rightMenu.classList.remove("trans");
    //document.body.style.overflowY = "hidden";
    //setTimeout(() => {
    //    rightMenu.style.display = "none";
    //}, 400);

    $(".right-task-menu").removeClass("trans");
}
///////////////////////////////////////

////////////////////////////////////////////////////////////////
                    //Animation stuff