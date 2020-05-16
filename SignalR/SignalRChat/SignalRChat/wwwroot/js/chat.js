"use strict";
var user = 'no user';
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub?user=" + user).build();
 
connection.on("NotifyActionAdded",
    function(user, action) {

        // TODO: fare chiamata ajax per vedere se ci sono nuove actions da processare
        console.log("User: " + user);
        console.log("Action: " + action);
        
        // remove handler
        //connection.off("NotifyAddAction");
    });

connection.start().catch(function(err) {
    console.error(err);
});
    
document.getElementById("sendButton").addEventListener("click",  function(event) {
        user = document.getElementById("userInput").value;

        var action = document.getElementById("messageInput").value;
        connection.invoke("AddAction", user, action).catch(function(err) {
            return console.error(err.toString());
        });

        event.preventDefault();
});