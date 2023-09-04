$(document).ready(function () {
    //DataTable Start from Here

    $('#dataTables').DataTable({
        dom: "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[5, "desc"]],
        buttons: [
            {
                text: 'Yeni Video',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            },
            {
                text: 'Videolari Yenilə',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Team/GetAllCategories/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#dataTables').hide();
                            $('.btnUpdate').show();
                        },
                        success: function (data) {
                            const videoListDto = jQuery.parseJSON(data);
                            if (videoListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(videoListDto.Videos.$values,
                                    function (index, Team) {
                                        tableBody += `
                                                <tr name=${Team.Id}>
                                                        <td>${Team.Id}</td>
                                                        <td>${Team.Title}</td>
                                                        <td>${Team.Thumbnail}</td>
                                                        <td class="center"><span class="status active">${Team.IsActive ? "Bəli" : "Xeyr"}</span></td>
                                                        <td class="center"><span class="status active">${Team.IsDeleted ? "Bəli" : "Xeyr"}</span></td>
                                                        <td class="center">${Team.CreatedDate}</td>
                                                        <td class="center">${Team.CreatedByName}</td>
                                                        <td class="text-center">
                                                             <button class="btn btn-primary btn-sm btn-update" data-id="${Team.Id}"><span class="fas fa-edit"></span> Edit</button>
                                                             <button class="btn btn-danger btn-sm btn-delete" data-id="${Team.Id}"><span class="fas fa-minus-circle"></span> Sil</button>
                                                        </td>
                                                    </tr>
                                                 `
                                    });
                                $('#dataTables > tbody').replaceWith(tableBody);
                                $('.btnUpdate').hide();
                                $('#dataTables').fadeIn(1500);
                            } else {
                                toastr.error(`${videoListDto.Message}`, "Xeta Bas verdi");
                            }
                        },
                        error: function (err) {
                            $('.btnUpdate').hide();
                            $('#dataTables').fadeIn(1000);
                            toastr.error(`${err.responseText}`, "Xeta!");
                        }
                    });
                }
            }

        ],
        "language": {
            "sEmptyTable": "Cədvəldə heç bir məlumat yoxdur",
            "sInfo": " _TOTAL_ Nəticədən _START_ - _END_ Arası Nəticələr",
            "lengthMenu": "Səhifədə _MENU_ Nəticə Göstər",
            "sZeroRecords": "Nəticə Tapılmadı.",
            "sInfoEmpty": "Nəticə Yoxdur",
            "sInfoFiltered": "( _MAX_ Nəticə İçindən Tapılanlar)",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Yüklənir...",
            "sProcessing": "Gözləyin...",
            "sSearch": "Axtarış:",
            "sZeroRecords": "Nəticə Tapılmadı.",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Axırıncı",
                "sNext": "Sonraki",
                "sPrevious": "Öncəki"
            },

            "oAria": {
                "sSortAscending": ": sütunu artma sırası üzərə aktiv etmək",
                "sSortDescending": ": sütunu azalma sırası üzərə aktiv etmək"
            }

        },
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "Paginate": true,
        "bLengthChange": true,
        "bFilter": true,
        "bSort": false,
        "bInfo": true,
        "bAutoWidth": false,
        "placeholder": " ",
    });
    //DataTables End from Here

    //AJAX Get/ Getting the _TeamAddPartial Starts From Here

    $(function () {
        const url = '/Admin/Video/Add/';
        const placeholderDiv = $('#modalPlaceHolder');
        $("#btnAdd").click(function () {
            $.get(url).done(function (data) {
                placeholderDiv.html(data);
                placeholderDiv.find(".modal").modal("show");
            });
        });

        //AJAX Get/ Getting the _TeamAddPartial Ends  Here
        placeholderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-video-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const VideoAddAjaxModel = jQuery.parseJSON(data);
                const newFormBody = $('.modal-body', VideoAddAjaxModel.VideoAddPartial);
                placeholderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeholderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                             <tr class="odd" name="${VideoAddAjaxModel.VideoDto.Video.Id}">
                                <td>${VideoAddAjaxModel.VideoDto.Video.Id}</td>
                                <td>${VideoAddAjaxModel.VideoDto.Video.Title}</td>
                                <td>${VideoAddAjaxModel.VideoDto.Video.Thumbnail}</td>
                                <td class="center">${VideoAddAjaxModel.VideoDto.Video.IsActive ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center"><span class="status active">${VideoAddAjaxModel.VideoDto.Video.IsDeleted ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center">${VideoAddAjaxModel.VideoDto.Video.CreatedDate}</td>
                                <td class="center">${VideoAddAjaxModel.VideoDto.Video.CreatedByName}</td>
                                <td class="text-center">
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${TeamAddAjaxModel.VideoDto.Video.Id}"><span class="fas fa-edit"></span> Edit</button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${TeamAddAjaxModel.VideoDto.Video.Id}"><span class="fas fa-minus-circle"></span> Sil</button>
                                </td>
                            </tr>`;
                    const newTableRowObject = $(newTableRow);
                    newTableRowObject.hide();
                    $('#dataTables').append(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${VideoAddAjaxModel.VideoDto.Message}`, 'Uğurlu Əməliyyat');
                } else {
                    let summarytext = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summarytext += `*${text}\n`;
                    });
                    toastr.warning(summarytext);
                }
            });
        });

    });
        //Ajax POST / Posting the FormData as TeamAddDto starts from here


    //AJAX Get/ Getting the _TeamUpdatePaartial Starts From Here 

    $(function () {
        const url = '/Admin/Video/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            $.get(url, { videoId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error('Xeta');
            });
        });


        placeHolderDiv.on('click', "#btnSave", function (event) {
            event.preventDefault();
            const form = $('#form-video-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize(); //TeamUpdateDto cevirir
            $.post(actionUrl, dataToSend, function (data) {
                console.log(data);
                const VideoUpdateAjaxModel = jQuery.parseJSON(data);
                const newFormBody = $('.modal-body', VideoUpdateAjaxModel.VideoUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                             <tr class="odd" name="${VideoUpdateAjaxModel.VideoDto.Video.Id}">
                                <td>${VideoUpdateAjaxModel.VideoDto.Video.Id}</td>
                                <td>${VideoUpdateAjaxModel.VideoDto.Video.Title}</td>
                                <td>${VideoUpdateAjaxModel.VideoDto.Video.Thumbnail}</td>
                                <td class="center">${VideoUpdateAjaxModel.VideoDto.Video.IsActive ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center"><span class="status active">${VideoUpdateAjaxModel.VideoDto.Video.IsDeleted ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center">${VideoUpdateAjaxModel.VideoDto.Video.CreatedDate}</td>
                                <td class="center">${VideoUpdateAjaxModel.VideoDto.Video.CreatedByName}</td>
                                <td class="text-center">
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${VideoUpdateAjaxModel.VideoDto.Video.Id}"><span class="fas fa-edit"></span> Edit</button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${VideoUpdateAjaxModel.VideoDto.Video.Id}"><span class="fas fa-minus-circle"></span> Sil</button>
                                </td>
                            </tr>`;
                    const newTableRowObject = $(newTableRow);
                    const categoryTableRow = $(`[name="${VideoUpdateAjaxModel.VideoDto.Video.Id}"]`);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${VideoUpdateAjaxModel.VideoDto.Message}`, "Uğurlu Əməliyyat!")
                } else {
                    let summarytext = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summarytext = `*${text}\n`;
                    });
                    toastr.warning(summarytext);
                };
            }).fail(function (response) {
                console.log(response);
            });
        });

    });
    
    //AJAX Get/ Getting the _TeamAddPartial End From Here 

    //Ajax POST / Deleting a Category starts from here

    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const teamName = tableRow.find('td:eq(1)').text();
        Swal.fire({
            title: 'Silmək istədiyinizdən əminsiniz?',
            text: `${teamName} adlı video silinəcəkdir!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Bəli, silmək istəyirəm.',
            cancelButtonText: 'Xeyr, silmək istəmirəm.'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { videoId: id },
                    url: '/Admin/Video/Delete/',
                    success: function (data) {
                        const StudentDto = jQuery.parseJSON(data);
                        if (StudentDto.ResultStatus === 0) {
                            Swal.fire(
                                'Telebe silindi!',
                                `${StudentDto.Video.Title} adlı video uğurla silindi`,
                                'success'
                            );
                            tableRow.fadeOut(3500);
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Xəta Baş Verdi...',
                                text: `${StudentDto.Message}`,
                            });
                        };
                    },
                    error: function (err) {
                        toastr.error(`${err.responseText}`, "Xeta");
                    }
                });
            };
        });
    });
    //Ajax POST / Deleting a Category ends from here


})