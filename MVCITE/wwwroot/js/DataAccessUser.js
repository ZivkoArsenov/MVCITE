$(document).ready(function () {
    $('#userTable').DataTable({
        language: {
            search: "Pretraga:",
            lengthMenu: "Prikaži _MENU_ unosa",
            info: "Prikazano _START_ do _END_ od ukupno _TOTAL_ unosa",
            paginate: {
                first: "Prva",
                last: "Zadnja",
                next: "Sledeća",
                previous: "Prethodna"
            }
        },
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/DataAccessUser/GetAllData",
            "type": "POST"
        },
        "columns": [
            { "data": "userName" },
            { "data": "guid" },
            { "data": "name" },
            { "data": "description" },
            { "data": "emailAddress" }
        ]
    });
});