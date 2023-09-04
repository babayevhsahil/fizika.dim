$(document).ready(function () {
    $(function () {
        $(document).on('click','#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-comment-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const commentAddAjaxModel = jQuery.parseJSON(data);
                console.log(commentAddAjaxModel);
                const newFormBody = $('.form-card', commentAddAjaxModel.CommentAddPartial);
                console.log(newFormBody);
                const cardBody = $('.form-card');
                cardBody.replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                console.log(isValid);
                console.log(commentAddAjaxModel.CommentDto.Comment.CreatedByName);
                if (isValid===false) {
                    const newSingleComment = `<li class="comment" id="li-comment-2">
                                            <div class="com-image">
                                                <img alt="author" src="~/FrontEnd/assets/images/seller/01.gif" class="avatar"
                                                     height="70" width="70">
                                            </div>
                                            <div class="com-content">
                                                <div class="com-title">
                                                    <div class="com-title-meta">
                                                        <h4>
                                                            <a href="#" rel="external nofollow" class="url">
                                                                ${commentAddAjaxModel.CommentDto.Comment.CreatedByName}
                                                            </a>
                                                        </h4>
                                                        <span>  ${commentAddAjaxModel.CommentDto.Comment.CreatedDate}  at  pm </span>
                                                    </div>
                                                    <span class="reply">
                                                        <a rel="nofollow" class="comment-reply-link" href="#">
                                                            <i class="icofont-reply-all"></i>
                                                            Cavabla
                                                        </a>
                                                    </span>
                                                </div>
                                                <p>
                                                    ${commentAddAjaxModel.CommentDto.Comment.Text}
                                                </p>
                                            </div>
                                        </li>`;
                    const newSingleCommentObject = $(newSingleComment);
                    newSingleCommentObject.hide();
                    $('#comments').append(newSingleCommentObject);
                    newSingleCommentObject.fadeIn(3000);
                    toastr.success(`${commentAddAjaxModel.CommentDto.Comment.CreatedByName
                        },şərhiniz uğurla əlavə edilmişdir.Nümunəsi qarşınıza gələcək, lakin təsdiq edildikdən sonra görünəcək.`);
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