function status(event) {
    var elem = event.target.id;
    var e = elem.slice(0, 1);
    var no = elem.slice(1, 2);
    var addElem = document.getElementById(elem);
    addElem.parentNode.classList.add('active');
    if (no == '1') {
        document.getElementById(e + '2').parentNode.classList.remove('active');
        document.getElementById(e + '3').parentNode.classList.remove('active');

    }
    else if (no == '2') {
        document.getElementById(e + '1').parentNode.classList.remove('active');
        document.getElementById(e + '3').parentNode.classList.remove('active');

    }
    else {
        document.getElementById(e + '1').parentNode.classList.remove('active');
        document.getElementById(e + '2').parentNode.classList.remove('active');

    }
}
