$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    const dataTable = $("#tbl").DataTable({
        responsive: true,
        ordering: 'desc',
        "language": {
            "url": "//cdn.datatables.net/plug-ins/2.1.0/i18n/es-MX.json"
        },
        "width": "100%"
    });
}


