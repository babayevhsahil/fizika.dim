$(document).ready(function () {
    //DataTable Start from Here

    $('#dataTables').DataTable({
        dom: "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[5, "desc"]],
        buttons: [
            {
                text: 'Yeni P.Kateqoriya',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            },
            {
                text: 'P.Kateqoriya Yenilə',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/ExamCategory/GetAllCategories/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#dataTables').hide();
                            $('.btnUpdate').show();
                        },
                        success: function (data) {
                            const ExamCategoryListDto = jQuery.parseJSON(data);
                            if (ExamCategoryListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(ExamCategoryListDto.Categories.$values,
                                    function (index, ExamCategory) {
                                        tableBody += `
                                                <tr name=${ExamCategory.Id}>
                                                        <td>${ExamCategory.Id}</td>
                                                        <td>${ExamCategory.Name}</td>
                                                        <td class="center"><span class="status active">${ExamCategory.IsActive ? "Bəli" : "Xeyr"}</span></td>
                                                        <td class="center"><span class="status active">${ExamCategory.IsDeleted ? "Bəli" : "Xeyr"}</span></td>
                                                        <td class="center">${ExamCategory.CreatedDate}</td>
                                                        <td class="center">${ExamCategory.CreatedByName}</td>
                                                        <td class="center">${ExamCategory.ModifiedDate}</td>
                                                        <td class="center">${ExamCategory.ModifiedByName}</td>
                                                        <td>${ExamCategory.Note}</td>
                                                        <td class="text-center">
                                                             <button class="btn btn-primary btn-sm btn-update" data-id="${ExamCategory.Id}"><span class="fas fa-edit"></span> Edit</button>
                                                             <button class="btn btn-danger btn-sm btn-delete" data-id="${ExamCategory.Id}"><span class="fas fa-minus-circle"></span> Sil</button>
                                                        </td>
                                                    </tr>
                                                 `
                                    });
                                $('#dataTables > tbody').replaceWith(tableBody);
                                $('.btnUpdate').hide();
                                $('#dataTables').fadeIn(1500);
                            } else {
                                toastr.error(`${ExamCategoryListDto.Message}`, "Xeta Bas verdi");
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

    //AJAX Get/ Getting the _ExamCategoryAddPartial Starts From Here

    $(function () {
        const url = '/Admin/ExamCategory/Add/';
        const placeholderDiv = $('#modalPlaceHolder');
        $("#btnAdd").click(function () {
            $.get(url).done(function (data) {
                placeholderDiv.html(data);
                placeholderDiv.find(".modal").modal("show");
            });
        });

        //AJAX Get/ Getting the _ExamCategoryAddPartial Ends  Here
        placeholderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-projectcategory-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const ExamCategoryAddAjaxModel = jQuery.parseJSON(data);
                const newFormBody = $('.modal-body', ExamCategoryAddAjaxModel.ExamCategoryPartial);
                placeholderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeholderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                             <tr class="odd" name="${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.Id}">
                                <td>${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.Id}</td>
                                <td>${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.Name}</td>
                                <td class="center">${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.IsActive ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center"><span class="status active">${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.IsDeleted ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center">${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.CreatedDate}</td>
                                <td class="center">${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.CreatedByName}</td>
                                <td class="center">${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.ModifiedDate}</td>
                                <td class="center">${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.ModifiedByName}</td>
                                <td class="text-center">
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.Id}"><span class="fas fa-edit"></span> Edit</button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${ExamCategoryAddAjaxModel.ExamCategoryDto.ExamCategory.Id}"><span class="fas fa-minus-circle"></span> Sil</button>
                                </td>
                            </tr>`;
                    const newTableRowObject = $(newTableRow);
                    newTableRowObject.hide();
                    $('#dataTables').append(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${ExamCategoryAddAjaxModel.ExamCategoryDto.Message}`, 'Uğurlu Əməliyyat');
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
        //Ajax POST / Posting the FormData as ExamCategoryAddDto starts from here


    //AJAX Get/ Getting the _ExamCategoryUpdatePaartial Starts From Here 

    $(function () {
        const url = '/Admin/ExamCategory/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            $.get(url, { ExamCategoryId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error('Xeta');
            });
        });


        placeHolderDiv.on('click', "#btnSave", function (event) {
            event.preventDefault();
            const form = $('#form-projectcategory-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize(); //ExamCategoryUpdateDto cevirir
            $.post(actionUrl, dataToSend, function (data) {
                console.log(data);
                const ExamCategoryUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(ExamCategoryUpdateAjaxModel);
                const newFormBody = $('.modal-body', ExamCategoryUpdateAjaxModel.ExamCategoryUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                             <tr class="odd" name="${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.Id}">
                                <td>${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.Id}</td>
                                <td>${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.Name}</td>
                                <td class="center">${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.IsActive ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center"><span class="status active">${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.IsDeleted ? "Bəli" : "Xeyr"}</span></td>
                                <td class="center">${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.CreatedDate}</td>
                                <td class="center">${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.CreatedByName}</td>
                                <td class="center">${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.ModifiedDate}</td>
                                <td class="center">${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.ModifiedByName}</td>
                                <td class="text-center">
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.Id}"><span class="fas fa-edit"></span> Edit</button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.Id}"><span class="fas fa-minus-circle"></span> Sil</button>
                                </td>
                            </tr>`;
                    const newTableRowObject = $(newTableRow);
                    const categoryTableRow = $(`[name="${ExamCategoryUpdateAjaxModel.ExamCategoryDto.ExamCategory.Id}"]`);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${ExamCategoryUpdateAjaxModel.ExamCategoryDto.Message}`, "Uğurlu Əməliyyat!")
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
    
    //AJAX Get/ Getting the _ExamCategoryAddPartial End From Here 

    //Ajax POST / Deleting a Category starts from here

    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const ExamCategoryName = tableRow.find('td:eq(1)').text();
        Swal.fire({
            title: 'Silmək istədiyinizdən əminsiniz?',
            text: `${ExamCategoryName} adlı kateqoriya silinəcəkdir!`,
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
                    data: { ExamCategoryId: id },
                    url: '/Admin/ExamCategory/Delete/',
                    success: function (data) {
                        const ExamCategoryDto = jQuery.parseJSON(data);
                        if (ExamCategoryDto.ResultStatus === 0) {
                            Swal.fire(
                                'Kateqoriya silindi!',
                                `${ExamCategoryDto.ExamCategory.Name} adlı kateqoriya uğurla silindi`,
                                'success'
                            );
                            tableRow.fadeOut(3500);
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Xəta Baş Verdi...',
                                text: `${ExamCategoryDto.Message}`,
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