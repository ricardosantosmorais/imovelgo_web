
var notyf = new Notyf();

function DoLogin(elem) {

    var email = $('#login_email').val();
    var password = $('#login_password').val();

    if (email == '' || password == '') {
        notyf.error('Preencha todos os dados.');
        return false;
    }

    var dataLogin = {
        Email: email,
        Password: password
    }

    console.log(dataLogin);
    console.log(JSON.stringify(dataLogin));

    addLoading(elem);
    $.ajax({
        type: "POST",
        dataType: 'json',
        data: JSON.stringify(dataLogin),
        contentType: "application/json; charset=utf-8",
        url: '/Account/Login',
        success: function (data) {
            console.log(data);
            if (data.success) {
                console.log("FUNFOU!");
            } else {
                notyf.error({
                    message: 'Falha no login, verifique seus dados.',
                    duration: 5000
                });
            }
        },
        error: function (data) {
            notyf.error({
                message: 'Falha no login, verifique seus dados.',
                duration: 5000
            });
        },
        complete: function (data) {
            removeLoading(elem);
        }
    });

}

function DoRegister(elem) {

    var name = $('#signup_name').val();
    var lastname = $('#signup_lastname').val();
    var email = $('#signup_email').val();
    var password = $('#signup_password').val();
    var cellphone = $('#signup_cellphone').val();

    if (name == '' || lastname == '' || email == '' || password == '' || cellphone == '') {
        notyf.error('Preencha todos os dados.');
        return false;
    }

    var dataRegister = {
        FistName: name,
        LastName: lastname,
        Email: email,
        Password: password,
        CellPhone: cellphone
    }

    addLoading(elem);
    $.ajax({
        type: "POST",
        dataType: 'json',
        data: JSON.stringify(dataRegister),
        contentType: "application/json; charset=utf-8",
        url: '/Account/Register',
        success: function (data) {
            console.log(data)
            if (!data.success) {
                notyf.error({
                    message: data.message,
                    duration: 5000
                });
                return false;
            }
            location.reload();
        },
        error: function (data) {
            notyf.error({
                message: data.Message,
                duration: 5000
            });
        },
        complete: function (data) {
            removeLoading(elem);
        }
    });

}

function addLoading(elem) {
    $(elem).addClass('loading');
}

function removeLoading(elem) {
    $(elem).removeClass('loading');
}


