$("#typeQuestId").change(function () {
    if ($("#typeQuestId").val() == 0) {
        $("#qcm").css('display', 'inherit');
    }
    else if ($("#typeQuestId").val() == 1) {
        $("#noted").css('display', 'inherit');
    }
    else if ($("#typeQuestId").val() == 2) {
        $("#react").css('display', 'inherit');
    }
});
