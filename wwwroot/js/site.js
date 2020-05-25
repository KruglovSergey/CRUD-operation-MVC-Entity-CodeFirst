// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var selectChange = function (val) {
    if (val == 1 || val == 0) {
        $('#TitleText')[0].innerText = 'Наименование'
    } else {
        $('#TitleText')[0].innerText = 'Ф.И.О.'
        $.ajax({
            url: "/Entities/GetUL"
        }).done(function (data) {
            if (Array.isArray(data) && data.length > 0) {
                $('#EntityID').append('< select name = "EntityID" id = "EntityIDSelect" class= "form-control" ><option value="">Выберите елеиент</option></select >')
                data.map((el) => {
                    addOption('#EntityIDSelect', el.title, el.id);
                });
            }
        });
    }
}

var addOption = function (target, text, value) {
    $(target).append(`<option value="${value}"> 
                                       ${text} 
                                  </option>`);
} 
