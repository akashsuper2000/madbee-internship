function status(event){
  var elem = event.target.id;
  var e = elem.slice(0,1);
  var no = elem.slice(1,2);
  var addElem = document.getElementById(elem);
  addElem.parentNode.classList.add('active');
  addElem.parentNode.classList.remove('disabled');
  if(no=='1'){
    document.getElementById(e+'2').parentNode.classList.remove('active');
    document.getElementById(e+'3').parentNode.classList.remove('active');
    document.getElementById(e+'2').parentNode.classList.add('disabled');
    document.getElementById(e+'3').parentNode.classList.add('disabled');
  }
  else if(no=='2'){
    document.getElementById(e+'1').parentNode.classList.remove('active');
    document.getElementById(e+'3').parentNode.classList.remove('active');
    document.getElementById(e+'1').parentNode.classList.add('disabled');
    document.getElementById(e+'3').parentNode.classList.add('disabled');
  }
  else{
    document.getElementById(e+'1').parentNode.classList.remove('active');
    document.getElementById(e+'2').parentNode.classList.remove('active');
    document.getElementById(e+'1').parentNode.classList.add('disabled');
    document.getElementById(e+'2').parentNode.classList.add('disabled');
  }
}