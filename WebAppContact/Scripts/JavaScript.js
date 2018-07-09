
window.onload = function () {
    $(".radiob").click(function () {
        var email = $("#email").attr('value');
        
        $(".form-control").each(function () {
            if ($(this).val() == email) {
                $(this).val("");
            }
        })
        var myId = $(this).attr('value');
        var prev = $(this).attr('data-prev');
        $(".mob-email[id = "+myId+"]").val(email);

       
        if (prev == 'True') {
            $(this).prop('checked', false)
            $(this).attr('data-prev', 'False')
            $(".mob-email[id = " + myId + "]").val('');
        } else {
            $(".radiob").each(function () {
                $(this).attr('data-prev', 'False');
            })
            $(this).prop('checked', true)
            $(this).attr('data-prev', 'True')
        }
    })


    $(".editName").change(function () {

        var inputs = $(".editName[id = " + $(this).attr('id') + "]");
        var isText = false;

        inputs.each(function () {
            if ($(this).val() != '')
                isText = true;
        });

        if (isText) {
            inputs.each(function () {
                $(this).attr('required', true);
            });
        }
        else {
            inputs.each(function () {
                $(this).attr('required', false);
            })
        }
    })

}