$(document).ready(function () {
    $(function () {
        $(document).on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-register-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const registerAddAjaxModel = jQuery.parseJSON(data);
                console.log(registerAddAjaxModel);
                if (actionUrl!==null) {
                    toastr.success(`${registerAddAjaxModel.RegisterDto.Register.Fullname
                        },Qeydiyyatınız uğurla əlavə edilmişdir.Ən qısa zamanda sizinlə əlaqə saxlanılacaq.`);
                    $("#btnSave").prop('disabled', true);
                    setTimeout(function () {
                        $("#btnSave").prop('disabled', false);
                    }, 15000);
                } else {
                    let summarytext = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summarytext += `*${text}\n`;
                    });
                    toastr.warning(summarytext);
                };
            }).fail(function (error) {
                console.log(error);
            });
        });
    });
});