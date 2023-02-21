function LoginClick() {
   
    var userName = $("#user").val();
    var password = $("#pass").val();
   
    $.ajax('MVCITE/Login/LoginCheck',{
        type: "POST",
        //url: "LoginCheck",
        data: { userName: userName, password: password, },
        beforeSend: function () {           
        },
        success: function (result) {

            if (result != null) {
               

            }
        },
        error: function (jqXHR) {           
            var errorText = jqXHR.responseText.split("<title>")[1].split("</title>")[0];          
        }
    });
}