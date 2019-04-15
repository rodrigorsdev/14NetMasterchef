$('#formAddCategoria').on('submit', function (e) {

    e.preventDefault();

    var $this = $(this);
    var formData = $this.serialize();

    $.ajax({
        type: 'POST',
        url: '/Categoria/Add',
        data: formData,
        success: function (data) {
            if (data.result == true) {
                reloadCategoriaDropDownList(data.list);
                $('#succesMessageCategoria > div > div').html(data.message);
                $('#succesMessageCategoria').show();
                fadeElement('#succesMessageCategoria');
            } else {
                $('#errorMessageCategoria > div > div').html(data.message);
                $('#errorMessageCategoria').show();
                fadeElement('#errorMessageCategoria');
            }

            $('#formAddCategoria')[0].reset();
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
});



function reloadCategoriaDropDownList(data) {
    $('#Categoria').empty();

    for (var i = 0; i < data.length; i++) {
        $('#Categoria').append('<option value="' + data[i].categoriaId + '" >' + data[i].nome + '</option>');
    }

    $('#Categoria').focus();
}