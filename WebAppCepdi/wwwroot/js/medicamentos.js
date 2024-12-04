$(document).ready(function () {
    // Función para cargar los medicamentos en el grid
    function loadMedicamentos() {
        $.ajax({
            url: 'http://localhost:5212/api/Medicamentos',
            type: 'GET',
            success: function (data) {
                const tableBody = $('#medicamentoTable tbody');
                tableBody.empty(); // Limpiar la tabla antes de llenarla
                data.forEach((medicamento) => {
                    const row = `
                        <tr>
                            <td>${medicamento.idMedicamento}</td>
                            <td>${medicamento.nombre}</td>
                            <td>${medicamento.concentracion}</td>
                            <td>${medicamento.idformafarmaceutica}</td>
                            <td>${medicamento.precio}</td>
                            <td>${medicamento.stock}</td>
                            <td>${medicamento.presentacion}</td>
                            <td>${medicamento.bhabilitado}</td>
                            <td>
                                <button class="btn btn-sm btn-warning edit btn-edit" data-id="${medicamento.idMedicamento}">Edit</button>
                                <button class="btn btn-sm btn-danger delete btn-delete" data-id="${medicamento.idMedicamento}">Delete</button>
                            </td>
                        </tr>`;
                    tableBody.append(row);
                });
            },
            error: function (error) {
                console.error('Error al cargar los medicamentos:', error);
            },
        });
    }

    // Abrir el modal para agregar un medicamento
    $('#btnAddMedicamento').click(function () {
        $('#medicamentoForm')[0].reset(); // Limpiar el formulario
        $('#medicamentoModalLabel').text('Agregar Medicamento');
        $('#medicamentoModal').modal('show');
    });

    // Guardar o actualizar medicamento
    $('#saveMedicamento').click(function () {
        var medicamento = {};
        if($('#medicamentoModalLabel').text() === 'Agregar Medicamento') {
            medicamento = {
                nombre: $('#medicamentoNombre').val(),
                concentracion: $('#medicamentoConcentracion').val(),
                idformafarmaceutica: $('#medicamentoIdForma').val(),
                precio: parseFloat($('#medicamentoPrecio').val()),
                stock: $('#medicamentoStock').val(),
                presentacion: $('#medicamentoPresentacion').val(),
                bhabilitado: $('#medicamentoBhabilitado').val(), // Convertir a booleano
            };
        } else {
            medicamento = {
                idMedicamento: $('#medicamentoId').val(),
                nombre: $('#medicamentoNombre').val(),
                concentracion: $('#medicamentoConcentracion').val(),
                idformafarmaceutica: $('#medicamentoIdForma').val(),
                precio: parseFloat($('#medicamentoPrecio').val()),
                stock: $('#medicamentoStock').val(),
                presentacion: $('#medicamentoPresentacion').val(),
                bhabilitado: $('#medicamentoBhabilitado').val(), // Convertir a booleano
            };
        }

        const url = $('#medicamentoModalLabel').text() === 'Agregar Medicamento'
            ? 'http://localhost:5212/api/Medicamentos'
            : `http://localhost:5212/api/Medicamentos/${medicamento.idMedicamento}`;

        const method = $('#medicamentoModalLabel').text() === 'Agregar Medicamento' ? 'POST' : 'PUT';

        $.ajax({
            url: url,
            type: method,
            contentType: 'application/json',
            data: JSON.stringify(medicamento),
            success: function () {
                $('#medicamentoModal').modal('hide');
                loadMedicamentos(); // Recargar la tabla
            },
            error: function (error) {
                console.error('Error al guardar el medicamento:', error);
            },
        });
    });

    // Llenar el modal para editar un medicamento
    $('#medicamentoTable').on('click', '.btn-edit', function () {
        const id = $(this).data('id');
        $.ajax({
            url: `http://localhost:5212/api/Medicamentos/${id}`,
            type: 'GET',
            success: function (medicamento) {
                $('#medicamentoId').val(id);
                $('#medicamentoNombre').val(medicamento.nombre);
                $('#medicamentoConcentracion').val(medicamento.concentracion);
                $('#medicamentoIdForma').val(medicamento.idformafarmaceutica);
                $('#medicamentoPrecio').val(medicamento.precio);
                $('#medicamentoStock').val(medicamento.stock);
                $('#medicamentoPresentacion').val(medicamento.presentacion);
                $('#medicamentoBhabilitado').val(medicamento.bhabilitado);
                $('#medicamentoModalLabel').text('Editar Medicamento');
                $('#medicamentoModal').modal('show');
            },
            error: function (error) {
                console.error('Error al cargar el medicamento:', error);
            },
        });
    });

    // Eliminar medicamento
    $('#medicamentoTable').on('click', '.btn-delete', function () {
        const id = $(this).data('id');
        if (confirm('¿Estás seguro de eliminar este medicamento?')) {
            $.ajax({
                url: `http://localhost:5212/api/Medicamentos/${id}`,
                type: 'DELETE',
                success: function () {
                    loadMedicamentos(); // Recargar la tabla
                },
                error: function (error) {
                    console.error('Error al eliminar el medicamento:', error);
                },
            });
        }
    });

    // Cargar medicamentos al inicio
    loadMedicamentos();
});
