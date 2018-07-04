
window.onload = function () {
    $(".radiob").click(function () {
        var email = $("#email").attr('value');
        
        $(".form-control").each(function () {
            $(this).val("");
        })
        var myId = $(this).attr('value');
        var prev = $(this).attr('data-prev');
        $("#" + myId).val(email);

       

        if (prev == 'True') {
            $(this).prop('checked', false)
            $(this).attr('data-prev', 'False')
            $("#" + myId).val("");
        } else {
            $(this).attr('data-prev', 'True')
        }
    })
}