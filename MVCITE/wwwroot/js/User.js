
$(document).ready(function () {
    LoadListing();
});

function LoadListing() {
    var testdata = [];
    $.ajax({
        type: "POST",
        url: "/User/GetAllData",
        async: false,
        success: function (data) {
            $.each(data, function (key, value) {
                var newbtn = "<a onclick='NewUser()' class='btn btn-success'><i class='bi-person-plus-fill'></i></a>";
                var editbtn = "<a onclick='EditUser(this)' class='btn btn-primary'><i class='bi-pen-fill'></i></a>";
                var removebtn = "<a onclick='RemoveUser(this)' class='btn btn-danger'><i class='bi-person-dash-fill'></i></a>";
                var hdn = "<input type='hidden' value=" + value.id + " />";
                var action = newbtn + " | " + editbtn + " | " + removebtn + hdn;
                testdata.push([value.id, value.fullName, value.username, value.email, value.role, action])
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

function NewUser() {
    window.location.href = "/User/Add";
}
function EditUser(element)
{
    var id = $(element).closest('tr').find('input[type=hidden]').val();
    window.location.href = "/User/Edit?id=" + id;
}
function RemoveUser(element) {
    var id = $(element).closest('tr').find('input[type=hidden]').val();
    if (confirm("Do you want to remove?")) {
        $.ajax({
            type: "POST",
            url: "/User/Remove",
            data: { id: id },
            success: function (data) {
                if (data == 'pass') {
                    alert('Removed successfully.');
                    window.location.reload();
                } else {
                    alert("Failure due to :" + data)
                }
            },
            failure: function (err) {

            }
        });
    }
}

function CancelCreateUser() {
    window.location.href = "/User/User";
}