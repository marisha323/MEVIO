var X;
var clientX;

function SetClientX(value) {
  if (clientX == null) clientX = value;
}

$(".time-change-block").on("mousedown", function (e) {
  SetClientX(e.clientX);

  $(".time-change-block").css("left", e.clientX - clientX);

  $(".time-blocks").on("mousemove", function (e) {
    const right = $(".time-change-block").css("right").split("p")[0];
    const blockWidth = $(".time-change-block").css("width").split("p")[0];
    const parentWidth = $(".time-blocks").css("width").split("p")[0];
    const End = Math.floor(parentWidth - blockWidth);
    console.log(parentWidth);

    X = e.clientX - clientX;

    $(".time-change-block").css("left", X);

    if (X >= End) {
      X = End;
      console.log(X);
      $(".time-change-block").css("left", X);
    }

    if (X <= 0) {
      X = 0;
      $(".time-change-block").css("left", X);
    }
  });
});

$(".time-change-block").on("mouseup", function (e) {
  $(".time-blocks").off("mousemove");
  //$(".time-change-block").css("left",X);
});
