$('#formAddIngrediente').on('submit', function (e) {

    e.preventDefault();

    var $this = $(this);
    var formData = $this.serialize();

    $.ajax({
        type: 'POST',
        url: '/Ingrediente/Add',
        data: formData,
        success: function (data) {
            if (data.result == true) {
                reloadCategoriaDropDownList(data.list);
                $('#succesMessageIngrediente > div > div').html(data.message);
                $('#succesMessageIngrediente').show();
                fadeElement('#succesMessageIngrediente');
            } else {
                $('#errorMessageIngrediente > div > div').html(data.message);
                $('#errorMessageIngrediente').show();
                fadeElement('#errorMessageIngrediente');
            }

            $('#formAddIngrediente')[0].reset();
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
});



function reloadCategoriaDropDownList(data) {
    $('#Ingredientes').empty();

    for (var i = 0; i < data.length; i++) {
        $('#Ingredientes').append('<option value="' + data[i].ingredienteId + '" >' + data[i].nome + ' - ' + data[i].unidadeMedida + '</option>');
    }

    $('#Ingredientes').focus();
}