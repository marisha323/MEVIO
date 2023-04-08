
var offsetX;
var parentLeft;
var parentWidth;
var changeBlock = document.querySelector(".time-change-block");
var changeBlockWidth;



$(".time-change-block").on("mousedown", function (e) {

    
    BlockMouseDown(e);


});

$(".time-blocks").on("mouseup", function (e) {
    $(".time-span-row").off("mousemove");
});



function BlockMouseDown(e) {

    changeBlock = document.querySelector(".time-change-block");

    const parentDiv = document.querySelector(".time-blocks");

    
    console.log(e.target);

    parentLeft = Math.ceil(parentDiv.getBoundingClientRect().left);


    parentWidth = parentDiv.getBoundingClientRect().width;

    offsetX = e.offsetX;

    changeBlockWidth = changeBlock.getBoundingClientRect().width;


    $(".time-blocks").on("mousemove", function (e) {

        TimeBlockMouseMove(e);

    });

};


function TimeBlockMouseMove(e) {

    

    const endX = parentWidth - changeBlockWidth;
    let blockLeft = e.clientX - parentLeft - offsetX;

    if (blockLeft < 0) blockLeft = 0;
    if (blockLeft > endX) blockLeft = endX;

    $(".time-change-block").css("left", blockLeft);

    //changeBlock.style.left = `${blockLeft}px`;
};


