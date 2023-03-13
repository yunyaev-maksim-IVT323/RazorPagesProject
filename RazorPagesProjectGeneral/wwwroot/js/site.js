// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let bead = document.querySelectorAll('.bead'); // переменная хранит список элементов с классом bead
let playa = document.querySelector('#playa'); // переменная хранит элемент playa

/*for (let i = 0; i < localStorage.length; i++) {
    let key = localStorage.key(i);
    localStorage.getItem(key);
};*/



let flag = false, imgClone = null;

// Для каждого элемента в bead регистрируется обработчик события "нажатие" и запускает функцию
for (var elem of bead)
    elem.addEventListener('mousedown', addRemoveCopy)   

function addRemoveCopy(e) {
    e.preventDefault(); // Отменяет действие браузера по умолчанию
    flag = true;

    if (this.classList.contains('imgCopy')) {
        // Если нажали на клон с шифтом удалить. Иначе присвоить переменной imgClone - ссылку на объект инициатор события (элемент на котором нажата кнопка мыши)
        return e.shiftKey ? e.target.remove() : imgClone = e.target;
    }

    imgClone = e.target.cloneNode();  //Клонируем элемент и получаем его точную копию
    imgClone.setAttribute('class', 'imgCopy'); // Изменяем значение атрибута клона, присваиваем ему новый класс
    imgClone.addEventListener('mousedown', addRemoveCopy); // Регистрируем обработчик события "нажатие" и вызываем функцию заново

    playa.append(imgClone); // Вставляем клон в нижнюю зону (зону построения)
}



document.addEventListener('mousemove', function (e) {
    if (!flag || !imgClone) return;
    let box = imgClone.getBoundingClientRect();

    let info = document.getElementById("info");

    imgClone.style.left = e.pageX - box.width / 2 + 'px';
    imgClone.style.top = e.pageY - box.height / 2 + 'px';
    imgClone.style.x = box.x;
    imgClone.style.y = box.y;
    if (imgClone.style.left <= 0 + 'px') {
        imgClone.style.left = 0 + 'px'
    }

    if (imgClone.style.top <= 0 + 'px') {
        imgClone.style.top = 0 + 'px'
    }

    //saveElement(imgClone);
    info.innerHTML = "Top: " + imgClone.style.top +
        "<br>Left: " + imgClone.style.left +
        "<br>X: " + imgClone.style.x + 
        "<br>Y: " + imgClone.style.y;
});

document.addEventListener('mouseup', function (e) {
    imgClone = null;
    flag = false;
});


function saveCoord() {
    let place = '';
    //var place = document.getElementById("qqq");
    let vivod = document.getElementById("vivod");
    let clons = document.querySelectorAll('.imgCopy'); // Список всех клонов на странице
    let mas = [];
    for (var i = 0; i < clons.length; i++) {
        mas[i] = [clons[i].x, clons[i].y];
        place += '<div>' + "X: " + mas[i][0] + ' '+ "Y: " + mas[i][1] + '</div>';
        //place += '<div>' + clons[i].x + ' ' + clons[i].y + '</div>';
        vivod.innerHTML = place;
    }

    for (var i = 0; i < clons.length; i++) {
        localStorage.setItem('clon' + i, clons[i]); // сохраняем в локальное хранилище
    }
    //for (var i = 0; i < clons.length; i++) {
    //    if (localStorage.getItem('clon' + i)) clons[i].innerHTML = localStorage.getItem('clon' + i);
    //};
}

function getSave() {
    for (let i = 0; i < localStorage.length; i++) {
        let key = localStorage.key(i);
        playa.innerHTML += localStorage.getItem(key);
    };

}


