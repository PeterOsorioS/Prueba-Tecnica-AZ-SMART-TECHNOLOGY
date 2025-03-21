$(document).ready(function () {

    window.DetalleLibro = function (id) {
        $.ajax({
            url: '/Libro/Detalle/' + id,
            type: 'GET',
            success: function (data) {
                $('#ContenedorModalDetalleLibro').html(data);
                $('#modal_detalle_libro').modal('show');
            },
            error: function (xhr, status, error) {
                console.log("Error al cargar el perfil");
            }
        });
    };
    window.Eliminar = function (id) {
        $.confirm({
            title: 'Confirmar eliminación',
            content: '¿Estás seguro de que deseas eliminar el libro?',
            theme: 'Modern',
            type: 'red',
            closeIcon: true,
            icon: 'fa fa-question',
            buttons: {
                confirmar: {
                    text: 'Sí, eliminar',
                    btnClass: 'btn-red',
                    action: function () {
                        $.ajax({
                            url: '/Libro/Eliminar/' + id,
                            type: 'DELETE',
                            success: function (data) {
                                if (data.success == true) {
                                    $.alert({
                                        title: 'Eliminado',
                                        content: data.message,
                                        theme: 'Modern',
                                        type: 'green',
                                        closeIcon: true,
                                        icon: 'fa fa-check',
                                    });
                                    setTimeout(() => {
                                        location.reload();
                                    }, "2000")
                                }
                                else {
                                    $.alert({
                                        title: 'Error',
                                        content: data.message,
                                        theme: 'Modern',
                                        type: 'red',
                                        closeIcon: true,
                                        icon: 'fa  fa-times-circle',
                                    });
                                }
                            },
                            error: function (xhr, status, error) {
                                $.alert({
                                    title: 'Error',
                                    content: 'Hubo un error al eliminar el libro.',
                                    theme: 'light',
                                    type: 'red'
                                });
                            }
                        });
                    }
                },
                cancelar: {
                    text: 'Cancelar',
                    action: function () {
                    }
                }
            }
        });
    };

});