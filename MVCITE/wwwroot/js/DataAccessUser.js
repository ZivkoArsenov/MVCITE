//$(document).ready(function () {
    
//    $('#userTable').DataTable({
//        language: {
//            search: "Pretraga:",
//            lengthMenu: "Prikaži _MENU_ unosa",
//            info: "Prikazano _START_ do _END_ od ukupno _TOTAL_ unosa",
//            paginate: {
//                first: "Prva",
//                last: "Zadnja",
//                next: "Sledeća",
//                previous: "Prethodna"
//            }
//        },
//        "processing": true,
//        "serverSide": true,
//        "ajax": {
//            "url": "/DataAccessUser/GetAllData",
//            "type": "POST"
//        },
//        "columns": [        
//            { "data": "userName" },
//            { "data": "guid" },
//            { "data": "name" },
//            { "data": "description" },
//            { "data": "emailAddress" }
//        ]
//    });
//});

$(document).ready(function () {
    LoadListing();
});

function LoadListing() {
    var testdata = [];
    $.ajax({
        type: "POST",
        url: "/DataAccessUser/GetAllData",
        async: false,
        success: function (data) {
            $.each(data, function (key, value) {
                console.log(value);      
                var newbtn = "<a onclick='FunNew()' class='btn btn-success'><i class='bi-person-plus-fill'></i></a>";
                var editbtn = "<a onclick='FunEdit(this)' class='btn btn-primary'><i class='bi-pen-fill'></i></a>";
                var removebtn = "<a onclick='FunRemove(this)' class='btn btn-danger'><i class='bi-person-dash-fill'></i></a>";//'<i class="bi-person-dash-fill"></i>';//<a onclick='FunRemove(this)' class='btn btn-danger'>Obrisi</a>";
                var hdn = "<input type='hidden' value=" + value.id + " />";
                var action = newbtn + " | " + editbtn + " | " + removebtn + hdn;
                testdata.push([value.userName, value.guid, value.name, value.description, value.emailAddress, action])
            })
        },
        failure: function (err) {

        }
    });
    new DataTable('#userTable', {
        data: testdata,
        paging: true,
        scrollY: 400,
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
        searching: true,
        ordering: true,
    });
}