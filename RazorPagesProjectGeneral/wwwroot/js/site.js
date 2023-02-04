// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let bead = document.querySelectorAll('.bead');
let playa = document.querySelector('#playa');

let flag = false, imgClone = null;

for (var elem of bead) elem.addEventListener('mousedown', addRemoveCopy);

function addRemoveCopy(e) {
    e.preventDefault();
    flag = true;

    if (this.classList.contains('imgCopy')) {
        // Если нажали на клон с шифтом удалить. Иначе присвоить переменной imgClone - елемент на котором нажата кнопка мыши
        return e.shiftKey ? e.target.remove() : imgClone = e.target;
    }

    imgClone = e.target.cloneNode();
    imgClone.setAttribute('class', 'imgCopy');
    imgClone.addEventListener('mousedown', addRemoveCopy);
    playa.append(imgClone);
}

document.addEventListener('mousemove', function (e) {
    if (!flag || !imgClone) return;
    let box = imgClone.getBoundingClientRect();
    imgClone.style.left = e.pageX - box.width / 2 + 'px';
    imgClone.style.top = e.pageY - box.height / 2 + 'px';
    imgClone.style.right = e.pageX - box.width / 2 + 'px';
    if (imgClone.style.left <= 0 + 'px') {
        imgClone.style.left = 0 + 'px'
    }

    if (imgClone.style.top <= 0 + 'px') {
        imgClone.style.top = 0 + 'px'
    }

});

document.addEventListener('mouseup', function (e) {
    imgClone = null;
    flag = false;
});
$(function () {
    $('#element').draggable({
        containment: '.element-wrp'
    });
});
