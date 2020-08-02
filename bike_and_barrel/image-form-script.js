function verify(event){

	//event.preventDefault();


	var file = document.getElementById('img').files;
	var filetype = file[0].type;
	var types = ['image/png', 'image/jpeg', 'image/bmp', 'image/jpg', 'image/gif'];

	//console.log(file);
	//console.log(filetype);

	if(!types.includes(filetype)){
			alert('no');
		return false;
	}
	
	else{

		alert('yes');
		return true;
	}

	
}