$("#startId").click(function (e) {
    console.log('dd');
    e.preventDefault();
    $("#start").css('display', 'none');
    $("#valid").css('display', 'inherit');
    $.ajax({
        type: "GET",
        url: "/Question/Questionnaires",
        data: {},
        contentType: 'json',
        success: function (result) { 
            for (var j = 0; j < result.length; j++) {
                var x = result[j].split(":");
                $("#questionnaireId").append("<div id=question" + j + "><h2> Question " + j + ": " + x[1] + "</h2><select class='input-lg btn-success' name=selectReponse" + j + "> </select> </div><br/>");

                for (var i = 2; i < x.length; i++) { 
                    $('select[name="selectReponse'+j+'"]').append("<option value='question"+j + i+"'>" + x[i] + "</option>");
                }       
            }
         }
    });
});
