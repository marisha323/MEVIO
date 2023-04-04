
//Ira
//var dateTimeInput = document.querySelector('#date1');
//var dateTimeValue = dateTimeInput.value;
//var dateTime = new Date(dateTimeValue);
//const time1 = dateTime.toLocaleTimeString();
//console.log(time1);

//var dateTimeInput = document.querySelector('#date2');
//var dateTimeValue = dateTimeInput.value;
//var dateTime = new Date(dateTimeValue);
//const time2 = dateTime.toLocaleTimeString();
//console.log(time2);


//const dateBegin = document.getElementById('date1');
//const dateEnd = document.getElementById('date2');

//dateBegin.addEventListener("change", ChangeTimeInputNew);


//dateEnd.addEventListener("change", ChangeTimeInputNew);


//function ChangeTimeInputNew() {
//	const value1 = dateBegin.value;
//	const value2 = dateEnd.value;

//	let date1 = new Date(value1);
//	//console.log(date1.toLocaleTimeString());
//	console.log(date1.getTime());

//	let date2 = new Date(value2);
//	//console.log(date2.toLocaleTimeString());
//	console.log(date2.getSeconds());
//}



//console.log(date1);

//console.log(date2);

//const date1 = document.querySelector('#date1'); //
//const date2 = document.querySelector('#date2');

//var dateTime1 = new Date(date1);
//var dateTime2 = new Date(date2);

//const time1 = dateTime1.getHours();
////console.log(time1);
//const time2 = dateTime2.getHours();
//console.log(time2);


//--------------------------------------------------------

const time1 = document.querySelector('#time1');
const time2 = document.querySelector('#time2');
const timeChangeBlock = document.querySelector(".time-change-block");

//const beginOfDay = 25200000;

var offset = Math.abs(new Date().getTimezoneOffset()) * 60 * 1000;

console.log(offset);

const beginOfDay = 25200000 - offset;
const endOfDay = 75600000;
const totalDay = 57600000;

const timeSpanDivWidth = document.querySelector(".time-span-row").getBoundingClientRect().width;


const milisecByPixel = Math.round(totalDay / timeSpanDivWidth);


time1.value = new Date(beginOfDay).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
time2.value = new Date(beginOfDay + 3600000).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

timeChangeBlock.addEventListener("mousemove", function (e) {

	let left = e.target.style.left;
	left = left.split('p')[0];


	let time1Value = Math.round(left * milisecByPixel + beginOfDay);
	if (time1Value < beginOfDay) time1Value = beginOfDay;
	if (time1Value > endOfDay - 3600000) time1Value = endOfDay - 3600000;
	time1.value = new Date(time1Value).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });


	let timeChangeBlockWidth = timeChangeBlock.getBoundingClientRect().width;
	let time2Value = Math.round(timeChangeBlockWidth * milisecByPixel + time1Value) + 60000;
	if (time2Value > endOfDay) time2Value = endOfDay;
	time2.value = new Date(time2Value).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
});


function ChangeTimeInput() {
	const beginOfDay = 25200000;
	const endOfDay = 79200000;

	const timeString1 = time1.value;
	const [hours1, minutes1] = timeString1.split(":");
	const hoursInMs1 = parseInt(hours1, 10) * 60 * 60 * 1000;
	const minutesInMs1 = parseInt(minutes1, 10) * 60 * 1000;
	let time1Value = hoursInMs1 + minutesInMs1;

	const timeString2 = time2.value;
	const [hours2, minutes2] = timeString2.split(":");
	const hoursInMs2 = parseInt(hours2, 10) * 60 * 60 * 1000;
	const minutesInMs2 = parseInt(minutes2, 10) * 60 * 1000;
	let time2Value = hoursInMs2 + minutesInMs2;



	if (time1Value < beginOfDay) time1Value = beginOfDay;
	if (time1Value > endOfDay) time1Value = endOfDay;
	if (time1Value > time2Value) time1Value = time2Value - 3600000;

	time1Value -= beginOfDay;

	const left = Math.round((time1Value) / milisecByPixel);

	console.log(time1Value);
	console.log(time2Value);

	if (time2Value - beginOfDay > time1Value) {
		const timeDiff = time2Value - time1Value - beginOfDay;
		const width = Math.round(timeDiff / milisecByPixel);

		if (width > timeSpanDivWidth - left) width = timeSpanDivWidth;

		timeChangeBlock.style.width = width + "px";
	}

	if (left < 0) left = 0;

	timeChangeBlock.style.left = left + "px";
}



time1.addEventListener("change", ChangeTimeInput);
time2.addEventListener("change", ChangeTimeInput);






