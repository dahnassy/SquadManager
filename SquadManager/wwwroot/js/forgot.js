function forgot(event) {

    event.preventDefault();

   
  
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify($("#email").val()),
        url: "https://localhost:44366/api/User/forgot",
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

