$(document).ready(function () {
    $("#fileinput").on("change", function () {

        var Message = $(this).next(".messagelabel");
        var files = $(this)[0].files;

        if (files.length > 1) {
            Message.html(files.length+' files selected');
        }
        else {
            Message.html(files[0].name);
        }
    });
});