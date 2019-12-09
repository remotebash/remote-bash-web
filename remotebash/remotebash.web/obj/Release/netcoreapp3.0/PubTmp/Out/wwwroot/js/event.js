$(document).ready(function(){
    let commandToExecute = "";
    $('#input-cmd').keypress(function(event){
        let keycode = (event.keyCode ? event.keyCode : event.which);
        if(keycode == '13'){
            let command = $(this).val();
            if(command.trim().length > 0){
                sendRequestExecuteCommand(command);
		commandToExecute = command;
                $(this).val("");
            } 
        }
    });

    function addCommandToReturnContainer(data){
        const cmdReturn = $("#container-return");
	if(data.command == undefined){
	   cmdReturn.append("<div class='title-return-cmd'>remotebash: "+commandToExecute+"</div>");
           cmdReturn.append("<div class='return-cmd'>"+data.replace("\"","").replace(/(?:\\[rn])+/g, "").replace("\"","")+"</div>");
	}
	else{
	   cmdReturn.append("<div class='title-return-cmd'>remotebash: "+data.command+"</div>");
           cmdReturn.append("<div class='return-cmd'>"+data.result+"</div>");
	}
    }

    function sendRequestExecuteCommand(command){
        let cmd = {
            command: command,
			userId: idUser,
			idComputer: idPc,
			idLaboratory: idLab
        };

        console.log(cmd);

        $.ajax({
            url: urlRest,
            type: 'post',
            headers: {
                'Content-Type':'application/json'
            },
            data: JSON.stringify(cmd),
        })
        .done(function(data){
            addCommandToReturnContainer(data);  
        })
        .fail(function(jqXHR, textStatus, msg){
            console.log(textStatus);
        });
    }


});