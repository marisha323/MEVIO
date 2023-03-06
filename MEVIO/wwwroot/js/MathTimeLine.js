const time1 = document.querySelector('#time1');
const time2 = document.querySelector('#time2');
const timeChangeBlock = document.querySelector('.time-change-block');


function updateBlock() {
   
    const start = new Date(`2023-03-04T${time1.value}`);
    const end = new Date(`2023-03-04T${time2.value}`);
    const diff = (end - start) / 1000 / 60 / 60 * (window.innerWidth / 24);
    //const diff = (end - start) / 1000 / 60 / 60; // �������� ���������� ������ � �������
    timeChangeBlock.style.width = `${diff}px`; // ������� ������ �����, �������������� ������ � �������
   
}


time1.addEventListener('input', updateBlock);
time2.addEventListener('input', updateBlock);
updateBlock();


//// �������� ������ �� �������� time1 � time2
//const time1 = document.querySelector("#time1");
//const time2 = document.querySelector("#time2");

//// �������� ������ �� ������� time-change-block
const timeChangeBlock2 = document.querySelector(".time-change-block");
const Shedule = document.querySelector(".shedule");

// �������� ���������� ������� onmousemove
timeChangeBlock2.addEventListener("mousemove", () => {
    // �������� ������� ��������� time-change-block
    const timeChangeBlockRect = timeChangeBlock2.getBoundingClientRect();
    const timeChangeBlockLeft = timeChangeBlockRect.left;
    const timeChangeBlockWidth = timeChangeBlockRect.width;
   
   
    // ��������� ����� �������� time1 � time2 �� ������ ��������� time-change-block
    const time1Value = new Date((timeChangeBlockLeft / Shedule) * 86400000 ).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }); // 25200000 ����������� ������������� 7 ����� ����
    const time2Value = new Date(((timeChangeBlockLeft + timeChangeBlockWidth) / Shedule) * 86400000).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

    // �������� �������� time1 � time2
    time1.value = time1Value;
    time2.value = time2Value;
});

//timeChangeBlock2.addEventListener("mousemove", () => {
//    // ��������� ��������� ����� 07:00
//    const startTime = new Date(`2023-03-04T07:00`);
//    // ��������� �������� ����� 00:00
//    const endTime = new Date(`2023-03-05T00:00`);
//    // ��������� ����� ���������� ����� ����� ��������� � �������� ��������
//    const totalMinutes = (endTime - startTime) / 1000 / 60;
//    // ��������� ��� ��� ������ ����
//    const hourStep = Shedule / 18;
//    // ��������� ���������� ����� ����� ��������� � ������� ��������
//    const hours = Math.round((timeChangeBlockLeft / hourStep) / 2);
//    // ��������� ����� �������� ��� time1 � time2
//    const time1Value = new Date(startTime.getTime() + (hours * 60 * 60 * 1000)).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
//    const time2Value = new Date(startTime.getTime() + ((hours + 1) * 60 * 60 * 1000)).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
//    time1.value = time1Value;
//    time2.value = time2Value;
//}

//const timeChangeBlock2 = document.querySelector('.time-block');
//const time1 = document.getElementById('time1');
//const time2 = document.getElementById('time2');

//timeChangeBlock2.addEventListener('click', () => {
//    const startTime = timeChangeBlock2.getAttribute('data-start');
//    const endTime = timeChangeBlock2.getAttribute('data-end');
//    time1.value = startTime;
//    time2.value = endTime;
//});


//const timeBlocks = document.querySelectorAll('.time-block');

//timeBlocks.forEach(timeBlock => {
//    timeBlock.addEventListener('click', () => {
//        const start = timeBlock.getAttribute('data-start');
//        const end = timeBlock.getAttribute('data-end');

//        time1.value = start;
//        time2.value = end;
//        time1.addEventListener('input', updateBlock);
//        time2.addEventListener('input', updateBlock);
//        updateBlock();
//    });
//});

//// get the time-change-block element and all the time-block elements
//const timeChangeBlock = document.querySelector('.time-change-block');
//const timeBlocks = document.querySelectorAll('.time-block');

//// add event listener to time-change-block element
//timeChangeBlock.addEventListener('mousedown', (event) => {
//    // get the index of the time-block element that corresponds to the starting time
//    const startIdx = Array.from(timeBlocks).findIndex(block => block === event.target.nextElementSibling);
//    // get the index of the time-block element that corresponds to the ending time
//    const endIdx = Array.from(timeBlocks).findIndex(block => block.querySelector('input').value === '00.00.00');

//    // set the values of the input type time elements
//    document.querySelector('input[type="time"][id="time1"]').value = timeBlocks[startIdx].querySelector('input').value;
//    document.querySelector('input[type="time"][id="time2"]').value = timeBlocks[endIdx].querySelector('input').value;
//});