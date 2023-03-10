var X;
var clientX;

function SetClientX(value){
    if(clientX==null)
        clientX=value;
}

$(".time-change-block").on("mousedown",function(e){

    SetClientX(e.clientX);
    
    
    
    $(".time-change-block").css("left",e.clientX-clientX);

    $("#bodyDiv").on("mousemove", function (e) {

        const blockWidth=$(".time-change-block").css("width").split('p')[0];
        const parentWidth=$(".time-blocks").css("width").split('p')[0];
        const End=Math.floor(parentWidth-blockWidth);

        X=e.clientX-clientX;
        
        $(".time-change-block").css("left",X);

        if(X>=End){
            X=End;
            console.log(X);
            $(".time-change-block").css("left",X);
        }

        if(X<=0){
            X=0;
            $(".time-change-block").css("left",X);
        }

        
    });
});

$(".time-change-block").on("mouseup",function(e){
    $("#bodyDiv").off("mousemove");
});

$("#bodyDiv").on("mouseup", function (e) {
    $("#bodyDiv").off("mousemove");
});