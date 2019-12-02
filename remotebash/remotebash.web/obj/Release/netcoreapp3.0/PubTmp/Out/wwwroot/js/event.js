$(document).ready(function(){

    $('#input-cmd').keypress(function(event){
        let keycode = (event.keyCode ? event.keyCode : event.which);
        if(keycode == '13'){
            let command = $(this).val();
            if(command.trim().length > 0){
                sendRequestExecuteCommand(command);
                $(this).val("");
            } 
        }
    });

    function addCommandToReturnContainer(data){
        const cmdReturn = $("#container-return");
        cmdReturn.append("<div class='title-return-cmd'>remotebash: "+data.command+"</div>");
        cmdReturn.append("<div class='return-cmd'>"+data.result+"</div>");
    }

    function sendRequestExecuteCommand(command){
        let cmd = {
            command: command,
			userId: idUser,
			idComputer: idPc
        };

        console.log(cmd);

        $.ajax({
            url: "http://3.94.151.158:8082/register/command",
            type: 'post',
            headers: {
                'Content-Type':'application/json'
            },
            data: JSON.stringify(cmd),
        })
        .done(function(data){
            console.log(cmd);
            console.log(data);
            addCommandToReturnContainer(data);  
        })
        .fail(function(jqXHR, textStatus, msg){
            console.log(jqXHR);
            console.log(textStatus);
            console.log(msg);
        });
    }


});