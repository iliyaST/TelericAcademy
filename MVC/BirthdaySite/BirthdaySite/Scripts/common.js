//$(document).ready(function () {  
//    $.connection.hub.start();

//    var chat = $.connection.chat;

//    $(".group-enter").click(function () {

//        var room = $(this).html(); 
//        chat.server.joinRoom(room)
        
//    });

//    $('#input-submit-button').click(function () {

//        var msg = $('#input-message-content').val();
//        var roomToJoin = $('#hidden-group').html().trim(); 

//        chat.client.addMessage = addMessage;
        
//        chat.server.addMessageToRoom(msg, roomToJoin);
//    });  
//});

//function addMessage(message) {
   
//    $div = $("<div>")
//        .addClass("row message-bubble");
//    $p = $("<p>").addClass("text-muted")
//        .appendTo($div);
//    $span = $("<span>").html(message)
//        .appendTo($div);

//    $('.panel-body').children('.container').append($div);  
//}