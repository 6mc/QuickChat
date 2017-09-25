var express = require('express');
var app = express();
var server = require('http').createServer(app);
var	io	= require('socket.io').listen(server);
 


 app.set('port', process.env.PORT || 3000);


var	clients = [];

io.on("connection", function(socket){



var currentuser;

socket.on("user_connect", function(){


console.log("user connected");


for(var i=0; i< clients.lenght; i++ ){


	socket.emit("user_connected", {name:clients[i].name, position:clients[i].position});
}


//console.log("user name"+ clients[i].name + "is connected");


});


socket.on("PLAY", function(data ){

console.log(data);

currentuser={
	name:data.name,
	position:data.position
}



clients.push(currentuser);
socket.emit("PLAY", currentuser);

socket.broadcast.emit("user_connected",currentuser);

});

socket.on("MOVE", function(data){


currentuser.position=data.position;
socket.emit("MOVE", currentuser);
socket.broadcast.emit("MOVE",currentuser);
console.log(currentuser.name+"MOVEd to"+currentuser.position);

});


socket.on("disconnect", function(){


socket.broadcast.emit("user_disconnected", currentuser);

for (var i = 0 ; i < clients.lenght; i++) {
	if (clients[i].name== currentuser.name) {


		console.log("user"+clients[i].name+"have disconnected");
		clients.splice(i,1);
	}
};

});


});




 server.listen(app.get('port'), function (){


 	console.log("-----server is running");
 });