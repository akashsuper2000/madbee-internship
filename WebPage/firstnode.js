var http = require('http');
var url = require('url');
var express = require('express');
var bodyParser = require('body-parser');
var app = express();

app.use(bodyParser.urlencoded({extended: true}));

function onreq(req,res){
	
	console.log(req.body);

	var q = req.body.car;
	var p = '';
	if(q=='Select car'){
		p = 'Bike chosen: '+req.body.bike;
	}
	else{
		p = 'Car chosen: '+q;
	}
	res.send('Your Name: '+req.body.name+'\n'+p+'\nYour mobile number: '+req.body.mobile);
}

app.post('/myaction', onreq);

app.listen(8080,function(){
	console.log('Running');
});