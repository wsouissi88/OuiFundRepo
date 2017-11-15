$("#startId").click(function (e) {
    e.preventDefault();
    $("#start").css('display', 'none');
    $("#valid").css('display', 'inherit');
    $("#questionnaireId").addClass('qcm');
    $.ajax({
        type: "GET",
        url: "/Question/QuestionnairesQCM",
        data: {},
        contentType: 'json',
        success: function (result) {
            console.log(result);
            var num = 1;
            for (var j = 0; j < result.length; j++) {
                var x = result[j].split(":");
                $("#questionnaireId").append("<div class=Question id=" + x[0] + "><h3>Question " + num + ":</h3><h2>" + x[1] + "</h2><select class='input-lg btn-success' name=selectReponse" + x[0] + "> </select> </div><br/>");
                num++;
                console.log(x);
                for (var i = 2; i < x.length; i++) {
                    var r = x[i].split("?");
                    console.log(r);
                    $('select[name="selectReponse' + x[0]+'"]').append("<option value='"+r[0]+"'>" + r[1] + "</option>");
                }       
            }
         }
    });
});
$("#notedId").click(function (e) {
    e.preventDefault();
    $("#start").css('display', 'none');
    $("#valid").css('display', 'inherit');
    $("#questionnaireId").addClass('noted');
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
    $("#questionnaireId").addClass('redact');
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
    var list = new Array();
    if ($("#questionnaireId").hasClass('qcm')) {
        $(".Question").each(function (index) {
            var idQuest = $(this).attr('id');
            var idRepon = $("select[name='selectReponse" + idQuest + "']").find(":selected").val();
            list.push(idQuest + ":" + idRepon);
        });
        console.log(list);
        $.ajax({
            type: "GET",
            url: "/Question/saveResult",
            data: {lst:list},
            contentType: 'application/json; charset=utf-8',
            contentType: 'json',
            traditional: true,
            success: function (result) {
                for (var j = 0; j < result.length; j++) {
                    var x = result[j].split(":");
                    console.log(x[0]);
                }
            }
        });
    }
    
    //if ($("#questionnaireId").hasClass('qcm')){
    //    $(".Question").each(function (index) {
    //        var id = $(this).attr('id');
    //        console.log(id);
    //        console.log($("select[name='selectReponse" + id + "']").find(":selected").text());
    //    });
    //}
    //if ($("#questionnaireId").hasClass('noted')) {
    //    $(".Question").each(function (index) {
    //        console.log($(this).attr('id'));
    //        console.log($(this).find("input").val());
    //    });
    //}
    //if ($("#questionnaireId").hasClass('redact')) {
    //    $(".Question").each(function (index) {
    //        console.log($(this).attr('id'));
    //        console.log($(this).find("textarea").val());
    //    });
    //}
});

