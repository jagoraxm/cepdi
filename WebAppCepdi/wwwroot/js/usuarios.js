$(document).ready(function () {
    // Función para cargar los usuarios en el grid
    function loadUsuarios() {
        $.ajax({
            url: 'http://localhost:5212/api/Usuarios',
            type: 'GET',
            success: function (data) {
                const tableBody = $('#usuarioTable tbody');
                tableBody.empty(); // Limpiar la tabla antes de llenarla
                data.forEach((usuario) => {
                    const row = `
                        <tr>
                            <td>${usuario.idUsuario}</td>
                            <td>${usuario.nombre}</td>
                            <td>${usuario.fechaCreacion}</td>
                            <td>${usuario.usuario}</td>
                            <td>${usuario.password}</td>
                            <td>${usuario.idPerfil}</td>
                            <td>${usuario.estatus}</td>
                            <td>
                                <button class="btn btn-sm btn-warning edit btn-edit" data-id="${usuario.idUsuario}">Edit</button>
                                <button class="btn btn-sm btn-danger delete btn-delete" data-id="${usuario.idUsuario}">Delete</button>
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
    $('#btnAddUsuario').click(function () {
        $('#usuarioForm')[0].reset(); // Limpiar el formulario
        $('#usuarioModalLabel').text('Agregar Usuario');
        $('#usuarioModal').modal('show');
    });

    // Guardar o actualizar usuario
    $('#saveUsuario').click(function () {
        var usuario = {};
        if($('#usuarioModalLabel').text() === 'Agregar Usuario') {
            usuario = {
                nombre: $('#usuarioNombre').val(),
                fechaCreacion: $('#usuarioFechaCreacion').val(),
                usuario: $('#usuarioUsuario').val(),
                password: $('#usuarioPassword').val(),
                idPerfil: $('#usuarioIdPerfil').val(),
                estatus: $('#usuarioEstatus').val(),
            };
        } else {
            usuario = {
                idUsuario: $('#usuarioId').val(),
                nombre: $('#usuarioNombre').val(),
                fechaCreacion: $('#usuarioFechaCreacion').val(),
                usuario: $('#usuarioUsuario').val(),
                password: $('#usuarioPassword').val(),
                idPerfil: $('#usuarioIdPerfil').val(),
                estatus: $('#usuarioEstatus').val(),
            };
        }

        const url = $('#usuarioModalLabel').text() === 'Agregar Usuario'
            ? 'http://localhost:5212/api/Usuarios'
            : `http://localhost:5212/api/Usuarios/${usuario.idUsuario}`;

        const method = $('#usuarioModalLabel').text() === 'Agregar Usuario' ? 'POST' : 'PUT';

        $.ajax({
            url: url,
            type: method,
            contentType: 'application/json',
            data: JSON.stringify(usuario),
            success: function () {
                $('#usuarioModal').modal('hide');
                loadUsuarios(); // Recargar la tabla
            },
            error: function (error) {
                console.error('Error al guardar el usuario:', error);
            },
        });
    });

    // Llenar el modal para editar un medicamento
    $('#usuarioTable').on('click', '.btn-edit', function () {
        const id = $(this).data('id');
        $.ajax({
            url: `http://localhost:5212/api/Usuarios/${id}`,
            type: 'GET',
            success: function (usuario) {
                $('#usuarioId').val(id);
                $('#usuarioNombre').val(usuario.nombre);
                $('#usuarioFechaCreacion').val(usuario.fechaCreacion);
                $('#usuarioUsuario').val(usuario.usuario);
                $('#usuarioPassword').val(usuario.password);
                $('#usuarioIdPerfil').val(usuario.idPerfil);
                $('#usuarioEstatus').val(usuario.estatus);
                $('#usuarioModalLabel').text('Editar Usuario');
                $('#usuarioModal').modal('show');
            },
            error: function (error) {
                console.error('Error al cargar el usuario:', error);
            },
        });
    });

    // Eliminar medicamento
    $('#usuarioTable').on('click', '.btn-delete', function () {
        const id = $(this).data('id');
        if (confirm('¿Estás seguro de eliminar este usuario?')) {
            $.ajax({
                url: `http://localhost:5212/api/Usuarios/${id}`,
                type: 'DELETE',
                success: function () {
                    loadUsuarios(); // Recargar la tabla
                },
                error: function (error) {
                    console.error('Error al eliminar el usuario:', error);
                },
            });
        }
    });

    // Cargar medicamentos al inicio
    loadUsuarios();
});
