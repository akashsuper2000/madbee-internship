function carChecked()
{
	var x = document.getElementsByClassName("bike_options").length;
	for(var i=0;i<x;i++){
		document.getElementsByClassName("bike_options")[i].value = "Select bike";
		document.getElementsByClassName("bike_options")[i].style.display = "none";
		document.getElementsByClassName("car_options")[i].style.display = "block";
	}
}
function bikeChecked()
{
	var x = document.getElementsByClassName("bike_options").length;
	for(var i=0;i<x;i++){
		document.getElementsByClassName("car_options")[i].value = "Select car";
		document.getElementsByClassName("car_options")[i].style.display = "none";
		document.getElementsByClassName("bike_options")[i].style.display = "block";
	}
}
function verify()
{
	var x = document.getElementById("mobile").value;
	var y = parseInt(x).toString().length;
	if(y==10 && x.length==10){
		//var query = window.location.search.substring(1);
		//window.open('http://localhost:8080/?');
		return true;
	}
	else{
		alert("Invalid Mobile number");
		document.getElementById("mobile");
		return false;
	}
}

function validateNumbers()
{
	//alert(document.getElementById("mobile").value);

	var val = document.getElementById("mobile").value.split("");
	var inputVal = "";

	val.forEach((itemVal) => {
		//alert(parseInt(itemVal));
		if(parseInt(itemVal).toString() != "NaN" && inputVal.length < 10)
		{
			//alert(itemVal);
			inputVal = inputVal.concat(itemVal.toString());
		}
	});


	document.getElementById("mobile").value = inputVal;

	//document.getElementById("mobile").value = parseInt(document.getElementById("mobile").value);

	
}