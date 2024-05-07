//$(document).ready(function () {

//    var formreferences = {

//        namedata: "#id-name",
//        emaildata: "#id-email",
//        passworddata: "#id-password",
//        confirmpassworddata: "#id-cpassword",
//        errordata1: "#error1",
//        errordata2: "#error2",
//        errordata3: "#error3",
//        errordata4: "#error4",
//        emailicon: "#emailicon",
//        passwordicon: "#passwordicon",

//        displayicons: "#icondisplay",
//        displayicons1: "#icondisplay1",
//        displayicons2: "#icondisplay2",
//        displayicons3: "#icondisplay3",
//        userform: "#user-form",
//        registerbtnsubmit:"#btn-register"

//    }


//    $(formreferences.namedata).keyup(name_check);
//    $(formreferences.emaildata).keyup(email_check);
//    $(formreferences.passworddata).keyup(password_checkup);
//    $(formreferences.confirmpassworddata).keyup(confirmpassword_checkup);

//    $(formreferences.registerbtnsubmit).click(function () {

//        $('.error').text('');


//        var isvalid = true;

//        var name_err = name_check();
//        if (!name_err) {
//            isvalid = false;
//        }

//        var email_err = email_check();
//        if (!email_err) {
//            isvalid = false;
//        }

//        var password_err = password_checkup();
//        if (!password_err) {
//            isvalid = false;
//        }

//        var confirmpassword_err = confirmpassword_checkup();
//        if (!confirmpassword_err) {
//            isvalid = false;
//        }

//        if (isvalid) {
//            $(formreferences.userform)[0].submit();
//            alert('Registered successfully:');
//        }


//    });



//    function name_check() {
//        //var regex_name = /^[a-zA-Z]+$/;
//        var regex_name = /^(?! )[a-zA-Z]+$/;

//        var name_val = $(formreferences.namedata).val();
//        console.log(name_val);
//        if (name_val == '') {
//            $(formreferences.errordata1).show();
//            $(formreferences.errordata1).html('Please Enter the Name');
//            $(formreferences.displayicons).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        } else if (!regex_name.test(name_val)) {
//            $(formreferences.errordata1).show();
//            $(formreferences.errordata1).html('Please Enter alphabetic characters only ');
//            isvalid = false;
//            return false;
//        } else {
//            $(formreferences.errordata1).hide();
//            $(formreferences.displayicons).html('<i class="fas  fa-exclamation-circle"></i>').hide();
//            return true;
//        }
//    }

//    function email_check() {
//        var emailpattern = /^[a-zA-Z][a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/

//        var email_val = $(formreferences.emaildata).val();
//        console.log(email_val);
//        if (email_val == '') {
//            $(formreferences.errordata2).show();
//            $(formreferences.errordata2).html('Please enter Email');
//            $(formreferences.displayicons1).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        } else if (!emailpattern.test(email_val)) {
//            $(formreferences.errordata2).show();
//            $(formreferences.errordata2).html('Please Enter valid Email');
//            isvalid = false;
//            return false;
//        } else {
//            $(formreferences.errordata2).hide();
//            $(formreferences.displayicons1).html('<i class="fas  fa-exclamation-circle"></i>').hide();
//            return true;
//        }
//    }

//    var password_val;
//    function password_checkup() {
//        password_val = $(formreferences.passworddata).val();
//        console.log(password_val);
//        if (password_val == '') {
//            $(formreferences.errordata3).html('Please Enter Password').show();
//            $(formreferences.displayicons2).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }
//        if (password_val.length < 6)
//        {
//            $(formreferences.errordata3).html(' Please enter Password atleast 6 characters').show();
//            isvalid = false;
//            return false;
//        } else {
//            $(formreferences.errordata3).hide();
//            $(formreferences.displayicons2).html('<i class="fas  fa-exclamation-circle"></i>').hide();
//            return true;
//        }
//    }

//    function confirmpassword_checkup() {

//        var confirmpassword_val = $(formreferences.confirmpassworddata).val();
//        console.log(confirmpassword_val);
//        if (confirmpassword_val == '') {
//            $(formreferences.errordata4).html('Please Enter confirm Password');
//            $(formreferences.displayicons3).html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }
//        if (password_val !== confirmpassword_val) {
//            $(formreferences.errordata4).html('sorry! mismatch of password and confirm Password').show();
//            isvalid = false;
//            return false;
//        } else {
//            $(formreferences.errordata4).hide();
//            $(formreferences.displayicons3).html('<i class="fas  fa-exclamation-circle"></i>').hide();
//            return true;
//        }
//    }
//});










































































//$(document).ready(function () {

//    $('#id-name').keyup(name_check);
//    $('#id-email').keyup(email_check);
//    $('#id-password').keyup(password_checkup);
//    $('#id-cpassword').keyup(confirmpassword_checkup);



//    $("#btn-register").on("click",function () {

//        //e.preventdefault();

//        $('.error').text('');

//        var isvalid = true;

//        var name_err = name_check();
//        if (!name_err) {
//            isvalid = false;
//        }

//        var email_err = email_check();
//        if (!email_err) {
//            isvalid = false;
//        }

//        var password_err = password_checkup();
//        if (!password_err) {
//            isvalid = false;
//        }

//        var confirm_err = confirmpassword_checkup();
//        if (!confirm_err) {
//            isvalid = false;
//        }

//        if (isvalid===true) {
//            $('#user-form')[0].submit();
//        }
//    });
//    function name_check() {
//        var regex_name = /^[a-za-z\s]+$/;

//        var name_val = $("#id-name").val();
//        console.log(name_val);
//        if (name_val == '') {
//            $("#error1").show();
//            $("#error1").html('please enter the name');
//            $("#icondisplay").html('<i class="bi bi-exclamation-circle"></i>');
//            return false;
//        }
//        else if (!regex_name.test(name_val)) {
//            $("#error1").show();
//            $("#error1").html('please enter alphabetic characters only ');
//            $("#icondisplay").html('<i class="bi bi-exclamation-circle"></i>');
//            return false;
//        }
//        else {
//            $("#error1").hide();
//            return true;
//        }
//    }



//    function email_check() {
//        var emailpattern = /^[a-za-z0-9._-]+@[a-za-z0-9.-]+\.[a-za-z]{2,4}$/
//        var email_val = $("#id-email").val();
//        console.log(email_val);
//        if (email_val == '') {
//            $("#error2").show();
//            $("#error2").html('please enter email');
//            return false;
//        }
//        else if (!emailpattern.test(email_val)) {
//            $('#error2').show();
//            $('#error2').html('please enter valid email');
//            return false;
//        }
//        else {
//            $('#error2').hide();
//            return true;
//        }
//    }

//    function password_checkup() {
//        var password_val = $('#id-password').val();
//        console.log(password_val);
//        if (password_val == '') {
//            $('#error3').html('please enter password');
//            return false;
//        }
//        if (password_val.length < 6) {
//            $('#error3').html(' please enter password atleast 6 characters');
//            return false;
//        }
//        else {
//            $('#error3').hide();
//            return true;
//        }
//    }

//    function confirmpassword_checkup() {
//        var password_val = $('#id-password').val();
//        var confirmpassword_val = $('#id-cpassword').val();
//        console.log(password_val);
//        if (password_val == '') {
//            $('#error4').html('please enter confirm password');
//            return false;
//        }

//        if (password_val != confirmpassword_val) {
//            $('#error4').html('sorry! mismatch of password and confirm password');
//            return false;
//        }
//        else {
//            $('#error4').hide();
//            return true;
//        }
//    }


//});



$(document).ready(function () {

    var mode = $("#mode").val();
    var formreferences = {
        namedata: "#id-name",
        emaildata: "#id-email",
        passworddata: "#id-password",
        confirmpassworddata: "#id-cpassword",
        errordata1: "#error1",
        errordata2: "#error2",
        errordata3: "#error3",
        errordata4: "#error4",
        emailicon: "#emailicon",
        passwordicon: "#passwordicon",
        displayicons: "#icondisplay",
        displayicons1: "#icondisplay1",
        displayicons2: "#icondisplay2",
        displayicons3: "#icondisplay3",
        userform: "#user-form",
        registerbtnsubmit: "#btn-register"
    }

    $(formreferences.namedata).keyup(name_check);
    $(formreferences.emaildata).keyup(email_check);
    $(formreferences.passworddata).keyup(password_checkup);
    $(formreferences.confirmpassworddata).keyup(confirmpassword_checkup);

    $(formreferences.registerbtnsubmit).on("click", function () {

        $('.error').text('');

        var name_val = $(formreferences.namedata).val();
        var email_val = $(formreferences.emaildata).val();
        var password_val = $(formreferences.passworddata).val();
        var confirmpassword_val = $(formreferences.confirmpassworddata).val();

        var isvalid = true;

        var name_err = name_check();
        if (!name_err) {
            isvalid = false;
        }

        var email_err = email_check();
        if (!email_err) {
            isvalid = false;
        }

        var password_err = password_checkup();
        if (!password_err) {
            isvalid = false;
        }

        if (mode == "submit") {
            var confirmpassword_err = confirmpassword_checkup();
            if (!confirmpassword_err) {
                isvalid = false;
            }
        }
        else {
            isvalid = true;
        }

        if (isvalid) {

            var formdata = {
                name: $(formreferences.namedata).val(),
                email: $(formreferences.emaildata).val(),
                password: $(formreferences.passworddata).val(),
                confirmPassword: $(formreferences.confirmpassworddata).val()
            };
            if (mode == 'submit') {
                $.ajax({
                    url: "Register",
                    type: "POST",
                    data: formdata,
                    success: function (data) {
                        if (data != null) {
                            console.log(data);
                            alert('Form submitted successfully:');
                            window.location.href = "/Home/ListPage";
                        }
                        else {
                            alert("Form upload error:");
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error(xhr.responseText);
                        console.error(status);
                        console.error(error);
                        alert('An error occurred while processing your request.');
                    }
                });
            }
            else {

                var ID = $("#userid").val();
                $.ajax({
                    url: "UpdateUser",
                    type: "POST",
                    data: { id: ID , user: formdata },
                    success: function (data) {
                        if (data != null) {
                            console.log(data);
                            alert('Form updated '+ ID +' successfully:');
                            window.location.href = "/Home/ListPage";
                        }
                        else {
                            alert("Form upload error:");
                        }
                    },

                    error: function (xhr, status, error) {
                        console.error(xhr.responseText);
                        console.error(status);
                        console.error(error);
                        alert('An error occurred while processing your request.');
                    }
                });
            }
        }
        
    });

    function name_check() {
        var regex_name = /^(?! )[a-zA-Z]+$/;
        var name_val = $(formreferences.namedata).val();
        console.log(name_val);
        if (name_val == '') {
            $(formreferences.errordata1).show().html('Please Enter the Name');
            $(formreferences.displayicons).html('<i class="fas  fa-exclamation-circle"></i>').show();
            return false;
        } else if (!regex_name.test(name_val)) {
            $(formreferences.errordata1).show().html('Please Enter alphabetic characters only ');
            return false;
        } else {
            $(formreferences.errordata1).hide();
            $(formreferences.displayicons).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            return true;
        }
    }

    function email_check() {
        var emailpattern = /^[a-zA-Z][a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        var email_val = $(formreferences.emaildata).val();
        console.log(email_val);
        if (email_val == '') {
            $(formreferences.errordata2).show().html('Please enter Email');
            $(formreferences.displayicons1).html('<i class="fas  fa-exclamation-circle"></i>').show();
            return false;
        } else if (!emailpattern.test(email_val)) {
            $(formreferences.errordata2).show().html('Please Enter valid Email');
            return false;
        } else {
            $(formreferences.errordata2).hide();
            $(formreferences.displayicons1).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            return true;
        }
    }

    var password_val;

    function password_checkup()
    {
        password_val = $(formreferences.passworddata).val();
        console.log(password_val);
        if (password_val == '') {
            $(formreferences.errordata3).html('Please Enter Password').show();
            $(formreferences.displayicons2).html('<i class="fas  fa-exclamation-circle"></i>').show();
            return false;
        }
        if (password_val.length < 6) {
            $(formreferences.errordata3).html(' Please enter Password atleast 6 characters').show();
            return false;
        } else {
            $(formreferences.errordata3).hide();
            $(formreferences.displayicons2).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            return true;
        }
    }

    function confirmpassword_checkup() {
        var confirmpassword_val = $(formreferences.confirmpassworddata).val();
        console.log(confirmpassword_val);
        if (confirmpassword_val == '') {
            $(formreferences.errordata4).html('Please Enter confirm Password');
            $(formreferences.displayicons3).html('<i class="fas  fa-exclamation-circle"></i>').show();
            return false;
        }
        if (password_val !== confirmpassword_val) {
            $(formreferences.errordata4).html('sorry! mismatch of password and confirm Password').show();
            return false;
        } else {
            $(formreferences.errordata4).hide();
            $(formreferences.displayicons3).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            return true;
        }
    }
});
