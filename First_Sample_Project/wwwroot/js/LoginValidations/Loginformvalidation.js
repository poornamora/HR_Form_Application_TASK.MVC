$(document).ready(function () {
    var isvalid = true; 

    var emailregex = /^[a-z0-9]+@gmail.com$/;
    $("#id-email").on("input", function () {
        var email_val = $("#id-email").val();
        console.log(email_val);

        if (email_val == '') {
            $("#error").text('Please Enter Email').show();
            $('#emailicon').html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else if (!emailregex.test(email_val)) {
            $('#error').text('Please Enter valid Email').show();
            $('#emailicon').html('<i class="fas  fa-exclamation-circle red"></i>').show();
            isvalid = false;
            return false;
        } else {
            $('#error').hide();
            $('#emailicon').html('<i class="fas  fa-exclamation-circle"></i>').hide();
            return true;
        }
    });

    $("#password-id").on("input", function () {
        var password_val = $("#password-id").val();
        console.log(password_val);

        if (password_val == '') {
            $("#error1").text('Please Enter password').show();
            $('#passwordicon').html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        } else {
            $("#error1").hide();
            $("#passwordicon").html('<i class="fas  fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }
    });


    $("#loginForm").submit(function () {

        var email_val = $("#id-email").val();
        var password_val = $("#password-id").val();

        console.log(password_val);

        if (email_val == '' && password_val!='') {
            $("#error").text('Please Enter Email').show();
            $("#emailicon").html('<i class="fas  fa-exclamation-circle"></i>').show();
            return false;
        }

        if (password_val == '' && email_val!=='') {
            $("#error1").text('Please Enter password').show();
            $("#passwordicon").html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }

        if(password_val === '' && email_val === '') {
            $("#error1").text('Please Enter password').show();
            $("#passwordicon").html('<i class="fas  fa-exclamation-circle"></i>').show();

            $("#error").text('Please Enter Email').show();
            $("#emailicon").html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else
        {
            isvalid = true;
            return true;
        }

       
       
        if (isvalid) {
            //$(idreferences.loginform)[0].submit();
            $("#loginForm")[0].submit();
        }

    });
});






//$(document).ready(function () {
//    var isvalid = true;



//    var idreferences = {

//        loginform: "#loginForm",
//        emaildata: "#id-email",
//        passworddata: "#password-id",
//        errordata: "#error",
//        errordata1: "#error1",
//        emailicon: "#emailicon",
//        passwordicon: "#passwordicon",

//    };

//    var emailregex = /^[a-z]{1}[a-z0-9]+@gmail.com$/;
//    //var emailregex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
//    //var emailregex = `/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/i`;

//    $(idreferences.emaildata).on("input", function () {
//        var email_val = $(idreferences.emaildata).val();
//        console.log(email_val);

//        if (email_val == '') {
//            $(idreferences.errordata).text('Please Enter Email').show();
//            $(idreferences.emailicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }
//        else if (!emailregex.test(email_val)) {
//            $(idreferences.errordata).text('Please Enter valid Email').show();
//            $(idreferences.emailicon).html('<i class="fas  fa-exclamation-circle red"></i>').show();
//            isvalid = false;
//            return false;
//        } else {
//            $(idreferences.errordata).hide();
//            $(idreferences.emailicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
//            return true;
//        }
//    });

//    $(idreferences.passworddata).on("input", function () {
//        var password_val = $(idreferences.passworddata).val();
//        console.log(password_val);
//        if (password_val == '') {
//            $(idreferences.errordata1).text('Please Enter password').show();
//            $(idreferences.passwordicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }
//        else {
//            $(idreferences.errordata1).hide();
//            $(idreferences.passwordicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
//            isvalid = true;
//            return true;
//        }
//    });

//    $("#id-submit").on("click", function () {

//        var email_val = $(idreferences.emaildata).val();
//        var password_val = $(idreferences.passworddata).val();
//        if (email_val == '' && password_val != '') {
//            $(idreferences.errordata).text('Please Enter Email').show();
//            $(idreferences.emailicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }

//        if (password_val == '' && email_val !== '') {
//            $(idreferences.errordata1).text('Please Enter password').show();
//            $(idreferences.passwordicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }


//        if (password_val == '' && email_val === '') {
//            $(idreferences.errordata1).text('Please Enter password').show();
//            $(idreferences.passwordicon).html('<i class="fas  fa-exclamation-circle"></i>').show();

//            $(idreferences.errordata).text('Please Enter Email').show();
//            $(idreferences.emailicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }
//        if (isvalid) {
//            window.location.href = "Home/ListPageDetails";
//        }
//    });
    
    

//    $(idreferences.loginform).submit(function () {

//        var email_val = $(idreferences.emaildata).val();
//        var password_val = $(idreferences.passworddata).val();

//        console.log(password_val);

//        if (email_val == '' && password_val != '') {
//            $(idreferences.errordata).text('Please Enter Email').show();
//            $(idreferences.emailicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }

//        if (password_val == '' && email_val !== '') {
//            $(idreferences.errordata1).text('Please Enter password').show();
//            $(idreferences.passwordicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }

//        //if (password_val == '') {
//        //    $(idreferences.passworddata).text('Please Enter password').show();
//        //    $(idreferences.passwordicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//        //    isvalid = false;
//        //    return false;
//        //}

//        if (password_val == '' && email_val === '') {
//            $(idreferences.errordata1).text('Please Enter password').show();
//            $(idreferences.passwordicon).html('<i class="fas  fa-exclamation-circle"></i>').show();

//            $(idreferences.errordata).text('Please Enter Email').show();
//            $(idreferences.emailicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }



//        if (isvalid) {
//            //alert("Login successfully")
//            $(idreferences.loginform)[0].submit();
//        }

//        //if (email_val !== '' && password_val !== '' && isvalid) {
//        //    $("#loginForm").submit();
//        //    $("#loginForm")[0].submit();
//        //}
//    });


//});
