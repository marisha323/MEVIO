
var offsetX;
var parentLeft;
var parentWidth;
const changeBlock = document.querySelector(".time-change-block");
var changeBlockWidth;



$(".time-change-block").on("mousedown", function (e) {

    const parentDiv = document.querySelector(".time-blocks");

    parentLeft = Math.ceil(parentDiv.getBoundingClientRect().left);


    parentWidth = parentDiv.getBoundingClientRect().width;

    offsetX = e.offsetX;

    changeBlockWidth = changeBlock.getBoundingClientRect().width



    $(".time-blocks").on("mousemove", function (e) {

        const endX = parentWidth - changeBlockWidth;
        let blockLeft = e.clientX - parentLeft - offsetX;

        if (blockLeft < 0) blockLeft = 0;
        if (blockLeft > endX) blockLeft = endX;

        changeBlock.style.left = `${blockLeft}px`;

    });





});

$(".time-blocks").on("mouseup", function (e) {
    $(".time-span-row").off("mousemove");
});


