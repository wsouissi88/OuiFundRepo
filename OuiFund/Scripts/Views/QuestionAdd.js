$("#typeQuestId").change(function () {
    if ($("#typeQuestId").val() == 1) { 
        $("#qcm").css('display', 'inherit');
        $("#noted").css('display', 'none');
        $("#redact").css('display', 'none');        
    }
    if ($("#typeQuestId").val() == 2) {
        $("#qcm").css('display', 'none');
        $("#noted").css('display', 'inherit');
        $("#redact").css('display', 'none');        
    }
    if ($("#typeQuestId").val() == 3) {
        $("#qcm").css('display', 'none');
        $("#noted").css('display', 'none');
        $("#redact").css('display', 'inherit');        
    }
});
