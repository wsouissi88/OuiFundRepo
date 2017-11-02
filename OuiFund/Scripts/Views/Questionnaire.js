
//$("#startId").click(function () {
//    alert("Value: ");
//});

$("#startId").click(function (e) {
    console.log('dd');
    e.preventDefault();
    $("#start").css('display', 'none');
    $.ajax({
        type: "GET",
        url: "/Question/Questionnaires",
        data: {},
        contentType: 'json',
        success: function (result) {
            $(result).each(function (index, item) {

                $("#titre").append("<h1>" + item + "</h1><br/>");
                $.ajax({
                    type: "GET",
                    url: "/Question/Reponse/",
                    data: { questId: item },
                    success: function (result) {
                        $(result).each(function (index, val) {

                            $("#reponse").append("<input type='radio'> " + val + " </input><br/>");
                        });
                    }
                });
            });
        }
    });
});
