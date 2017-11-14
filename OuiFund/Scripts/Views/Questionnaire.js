$("#startId").click(function (e) {
    e.preventDefault();
    $("#start").css('display', 'none');
    $("#valid").css('display', 'inherit');
    $.ajax({
        type: "GET",
        url: "/Question/QuestionnairesQCM",
        data: {},
        contentType: 'json',
        success: function (result) { 
            var num = 1;
            for (var j = 0; j < result.length; j++) {
                var x = result[j].split(":");
                $("#questionnaireId").append("<div class=Question id=" + x[0] + "><h3>Question " + num + ":</h3><h2>" + x[1] + "</h2><select class='input-lg btn-success' name=selectReponse" + x[0] + "> </select> </div><br/>");
                num++;
                for (var i = 2; i < x.length; i++) { 
                    $('select[name="selectReponse' + x[0]+'"]').append("<option value='question"+j + i+"'>" + x[i] + "</option>");
                }       
            }
         }
    });
});
$("#notedId").click(function (e) {
    e.preventDefault();
    $("#start").css('display', 'none');
    $("#valid").css('display', 'inherit');
    $.ajax({
        type: "GET",
        url: "/Question/QuestionnairesNoted",
        data: {},
        contentType: 'json',
        success: function (result) {
            var num = 1;
            for (var j = 0; j < result.length; j++) {
                var x = result[j].split(":");
                $("#questionnaireId").append("<div class=Question id=" + x[0] + "><h3>Question " + num + " :</h3><h2>" + x[1] + "</h2><input type='number' min='0' max='10' value='5' id=" + x[0] +"> </input> </div><br/>");
                num ++;
            }
        }
    });
});
$("#redactId").click(function (e) {
    e.preventDefault();
    $("#start").css('display', 'none');
    $("#valid").css('display', 'inherit');
    $.ajax({
        type: "GET",
        url: "/Question/QuestionnairesRedact",
        data: {},
        contentType: 'json',
        success: function (result) {
            var num = 1;
            for (var j = 0; j < result.length; j++) {
                var x = result[j].split(":");
                $("#questionnaireId").append("<div class=Question id=" + x[0] + "><h3>Question " + num + ":</h3><h2>" + x[1] + "</h2><textarea rows='7' cols='100' id=" + x[0] + "> </textarea> </div><br/>");
                num ++;
            }
        }
    });
});

$("#valid").click(function () {

    console.log(
        $("#questionnaireId #Question11 select[name='selectReponse11']").find(":selected").text());
});

