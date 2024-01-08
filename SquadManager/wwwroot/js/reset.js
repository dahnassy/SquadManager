function forgot(event) {

    event.preventDefault();

    if ($("#password").val() != $("#confirmPassword").val()) {
        $(".error span").show();

        setTimeout(function () {
            $(".error span").hide();
        }, 3000)
        return;
    }

    const urlParam = new URLSearchParams(window.location.search);

    const id = urlParam.get('id');

    var formData = {
       
        password: $("#password").val(),
        confirmPassword: $("#confirmPassword").val(),
        id: id
    }




    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(fromData),
        url: "https://localhost:44366/api/User/reset",
        success: function (result) {
            if (result.response == "OK")
                alert("E-mail foi enviado para recuperação de senha!")
            else
                alert(" Error Inesperado!")
        },

        error: function (error) {
            console.log(error);
        }

    })
}

