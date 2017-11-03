$("#typeQuestId").change(function () {
    if ($("#typeQuestId").val() == 0) {        
        $("#noted").css('display', 'none');
        $("#redact").css('display', 'none');
        $("#qcm").css('display', 'inherit');
    }
    if ($("#typeQuestId").val() == 1) {
        $("#qcm").css('display', 'inherit');
        $("#redact").css('display', 'inherit');
        $("#noted").css('display', 'inherit');
    }
    if ($("#typeQuestId").val() == 2) {
        $("#qcm").css('display', 'none');
        $("#noted").css('display', 'none');
        $("#redact").css('display', 'inherit');        
    }
});
