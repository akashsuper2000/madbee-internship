function red() {
    document.getElementsById('name').style.backgroundColor = 'red';
    document.getElementById('pwd').style.backgroundColor = 'red';

    document.getElementsById('name').style.opacity = 0.5;
    document.getElementById('pwd').style.opacity = 0.5;

    return false;
}