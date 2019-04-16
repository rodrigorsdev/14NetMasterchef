var i = 0;

$('#form').submit(function (e) {

    alert('submit');

    e.preventDefault();

    $('.ingredienteRow').each(function () {
        var id = $(this).find('.ingredienteId').html();
        var quantidade = $(this).find('.ingredienteQuantidade').html();
        var exists = $('#' + id).length;

        if (exists === 0) {
            $('<input>').attr({
                type: 'hidden',
                id: id,
                name: 'Ingredientes[' + i + '].IngredienteId',
                value: id
            }).appendTo('#form');

            $('<input>').attr({
                type: 'hidden',
                id: id + quantidade,
                name: 'Ingredientes[' + i + '].Quantidade',
                value: quantidade
            }).appendTo('#form');
        }

        i++;
    });

    this.submit();
});

$('#buttonSelectIngrediente').click(function () {

    var quantidade = $('#IngredienteQuantidade').val();

    if (quantidade) {

        var resultado = $('.ingredienteId').filter(function () {
            return $(this).text() === $('#Ingredientes').val();
        });

        if (resultado !== undefined && resultado.length === 0) {

            var header = $('.tableHeader');

            if (!header[0]) {

                var headerHtml = '<thead>' +
                    '<tr class="tableHeader">' +
                    '<th>Ingrediente</th>' +
                    '<th>Quantidade</th>' +
                    '<th>Un. Medida</th>' +
                    '<th></th>' +
                    '</tr>' +
                    '</thead>';

                $('.tableIngrediente').first().append(headerHtml);
            }

            var dropText = $('#Ingredientes :selected').text().split('-');

            var newRow = '<tr class="ingredienteRow">' +
                '<td class="ingredienteId" hidden="hidden">' + $('#Ingredientes').val() + '</td>' +
                '<td class="ingredienteNome">' + dropText[0] + '</td>' +
                '<td class="ingredienteQuantidade">' + quantidade + '</td>' +
                '<td class="ingredienteUnidadeMedida">' + dropText[1] + '</td>' +
                '<td><a href="#" class="btn btn-danger btn-sm removeIngrediente">X</a></td>' +
                '</tr>';

            $('.tableIngrediente tr:last').after(newRow);

            $('#IngredienteQuantidade').val('');

            $('.removeIngrediente').click(function () {

                $(this).closest('tr').remove();

                if ($('.tableIngrediente tr').length === 1) {
                    $('.tableIngrediente').empty();
                }
            });
        }
    }
});