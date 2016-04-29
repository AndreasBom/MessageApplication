'use strict';

(function () {
    var message = [];

    //Append messages to html
    function successCall (data) {
        var diff = data.length - message.length;
        console.log(message.length);

        //If new message arrived
        if (diff !== 0) {
            for (var i = message.length; i < data.length; i++) {
                var textMessage = data[i]["TextMessage"];
                var date = data[i]["DateTime"];
                var correctedDate = new Date(parseInt(date.replace("/Date(", "").replace(")/", ""), 10));
                
                message[i] = {
                    'date': correctedDate.toDateString(),
                    'time': correctedDate.toLocaleTimeString(),
                    'textMessage': textMessage
                };
                
                $('#messages').prepend(message[i].date + ": <br/>" + "kl: " +message[i].time + "<br/>" + message[i].textMessage + "<br/> <br/><hr>");
            }
        }
    };

    //Get messages from server
    var fetchData = function() {
        $.ajax({
            url: "http://localhost:54663/Message/GetMessages",
            success: function(data) {
                successCall(data);
            },
            dataType: "json",
            complete: poll
        });
    };


    //Poll for new messages
    function poll() {
        setTimeout(function () {
            fetchData();
        }, 3000);
    };

    fetchData();
    poll();
})();
