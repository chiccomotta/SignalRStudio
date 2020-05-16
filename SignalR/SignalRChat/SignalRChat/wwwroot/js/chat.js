//"use strict";
var params = new URLSearchParams(location.search);

var user = params.get("user");
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub?user=" + user).build();
 
connection.on("NotifyActionAdded",
    function(user, action) {

        // TODO: fare chiamata ajax per vedere se ci sono nuove actions da processare
        $("#messagesList").append("<li>" + user + " added action: " + action + "</li>");

        // remove handler
        //connection.off("NotifyAddAction");
    });

connection.start().catch(function(err) {
    console.error(err);
});
    
document.getElementById("sendButton").addEventListener("click", function(event) {
    var action = document.getElementById("messageInput").value;
    connection.invoke("AddAction", user, action).catch(function(err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

document.getElementById("brodcastButton").addEventListener("click", function(event) {
    var action = document.getElementById("messageInput").value;
    connection.invoke("BrodcastAction", action).catch(function(err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

