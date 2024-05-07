//const { type } = require("jquery");



//$(document).ready(function () {
//    $("#btn-upload").click(function () {

//        /*e.preventDefault();*/
//        var isvalid = true;

//        let fileInput = $("#fileinput")[0];
//        if (fileInput.files.length === 0) {
//            $("#error").text("Please select any file").show();
//            $("#icon").html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }

//        if (isvalid) {
//            let formData = new FormData();

//            let files = fileInput.files;


//            for (let i = 0; i < files.length; i++) {
//                formData.append('files', files[i]);
//            }


//            //let file = fileInput.files[0];
//            //formData.append('file', file);



//            $.ajax({
//                url: "Data/FileUpload",
//                type: 'POST',
//                data: formData,
//                processData: false,
//                contentType: false,
//                success: function (data) {
//                    if (data !== 0) {
//                        alert('File Uploaded successfully:');
//                        window.location.href = 'Purple/Files/FileUploading';

//                    } else {
//                        alert('File upload error');
//                    }
//                },
//                error: function () {
//                    alert('An error occurred during the file upload');
//                }
//            });
//        }
//    });
//});













//$(document).ready(function () {
//    $("#btn-upload").click(function () {

//        /*e.preventDefault();*/
//        var isvalid = true;

//        let fileInput = $("#fileinput")[0];
//        if (fileInput.files.length === 0) {
//            $("#error").text("Please select any file").show();
//            $("#icon").html('<i class="fas  fa-exclamation-circle"></i>').show();
//            isvalid = false;
//            return false;
//        }

//        if (isvalid) {
//            let formData = new FormData();

//            let files = fileInput.files;


//            for (let i = 0; i < files.length; i++) {
//                formData.append('files', files[i]);
//            }


//            //let file = fileInput.files[0];
//            //formData.append('file', file);


//            $.ajax({
//                url: 'GetFolder?foldername=FileDocuments',
//                type: 'GET',
//                success: function (data) {
//                    if (data.Exists) {
//                        $.ajax({
//                            url: "Data/FileUpload",
//                            type: 'POST',
//                            data: formData,
//                            processData: false,
//                            contentType: false,
//                            success: function (formData) {
//                                if (formData.Exists) {

//                                    var overrideconfirmed = confirm('File already exists Do you want to override it ?')

//                                    if (overrideconfirmed) {
//                                        functionUpload(formData);
//                                    }
//                                }
//                                else {
//                                    alert("File doesn't exists");
//                                }
//                            },
//                            error: function () {
//                                alert('An error occurred during the file checking');
//                            }
//                        });
//                    }
//                    else {
//                        functionUpload(formData);
//                    }
//                },
//                error: function (xhr, status, error) {
//                    console.error('Error', error);
//                }
//            });
//        }
//    });
//});
//function functionUpload(formData) {
//    $.ajax({
//        url: "Data/FileUpload",
//        type: 'POST',
//        data: formData,
//        processData: false,
//        contentType: false,
//        success: function (data) {
//            if (data !== 0)
//            {
//                alert('File uploaded successfully');
//                window.location.href = 'Purple/Files/FileUploading';

//            } else {
//                alert('File uploaded error');
//            }
//        },
//        error: function () {
//            alert('An error occurred during the file upload');
//        }
//    });
//}







var Globalvariable = {

        btnupload: "#btn-upload",
        fileinput: "#fileinput",
        passworddata: "#password-id",
        errordata: "#error",
        erroricon: "#icon",
        overrideyes: "#override-yes",
        popupmodal: "#popup-modal",
        invalidfileformat: "#invalidfileformat",
        versionsave:"#versiondetails"
    };


$(document).ready(function () {

    var isvalid = true;


    $(Globalvariable.erroricon).hide();

    $(Globalvariable.fileinput).on('change', function (event) {
        var FileValue = $(Globalvariable.fileinput).val();
        if (FileValue != '') {
            $(Globalvariable.erroricon).hide();
            $(Globalvariable.errordata).hide();
        }
    });


    $(Globalvariable.fileinput).on("change", function () {
        var fileinput = $(this)[0]; // 'this' refers to the file input element

        if (fileinput.files.length === 0) {
            $(Globalvariable.errordata).text("Please select any file").show();
            isvalid = false;
            return false;
        }

        var fileExtensionCheck = /\.(jpg|png|pdf|pptx|docx|xlsx?)$/i; 

        if (!fileExtensionCheck.test(fileinput.files[0].name)) {
            $(Globalvariable.invalidfileformat).text("Invalid File format").show();
            isvalid = false;
            return false;
        } else {
            $(Globalvariable.invalidfileformat).text("Invalid File format").hide();
            $(Globalvariable.errordata).text("Please select any file").hide();
            isvalid = true;
            return true;
        }
    });


    $(Globalvariable.btnupload).on("click", function ()
    {
        let fileInput = $(Globalvariable.fileinput)[0];
        if (fileInput.files.length === 0) {
            $(Globalvariable.errordata).text("Please select any file").show();
            $(Globalvariable.erroricon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }

        let fileextensioncheck = $(Globalvariable.fileinput).val();
        var validextensions = /\.(jpg|png|pdf|pptx|docx|xlsx?)$/i;
        if (!validextensions.test(fileextensioncheck)) {
            $(Globalvariable.invalidfileformat).text("Invalid File format").show();
            return false;
            isvalid = false;
        }
        
       

        if (isvalid) {
            let formData = new FormData();

            let files = fileInput.files;

            
            var foldername = "FileDocuments";
            for (let i = 0; i < files.length; i++) {
                fileName = formData.append('files', files[i]);
                FileNameExistence(foldername, files[i].name, formData);
            }
            

            //let file = fileInput.files[0];
            //formData.append('file', file);
        }
    });

    //This is for override
    $(Globalvariable.overrideyes).click(function () {
        var formData = new FormData();
        var files = $(Globalvariable.fileinput)[0].files;

        for (var i = 0; i < files.length; i++) {
            formData.append('files', files[i]);
        }
        uploadFiles(formData);
    });    

    //This is for version Name while file uploading
    $(Globalvariable.versionsave).click(function () {
        var formData = new FormData();

        var files = $(Globalvariable.fileinput)[0].files;
        for (var i = 0; i < files.length; i++) {
            formData.append('files', files[i]);
        }
        uploadFileswithversion(formData);
    });
});

function FileNameExistence(foldername, fileName, formData) {

    $.ajax({
        url: '/Files/GetFolder?foldername=' + foldername + '&fileName=' + fileName,
        type: 'GET',
        success: function (data)
        {
            if (data.fileExists)
            {    
                console.log(data);
                $(Globalvariable.popupmodal).modal('show');
            }
            else {
                uploadFiles(formData);
            }
        },
        error: function (xhr, status, error) {
            console.error('Error', error);
            console.log('Error came');
        }
    });
}

function uploadFiles(formData) {
    $.ajax({
        url: "/Files/PostFileUpload",
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            if (data !== 0)
            {
                alert('File uploaded successfully');
                window.location.href = '/Files/FileListPage';

            } else {
                alert('File uploaded error');
            }
        },
        error: function (status, error) {
            console.error('Error', error);
            console.error(status);
        }
    });
}

//This is for version save
function uploadFileswithversion(formData) {
    $.ajax({
        url: "/Files/UploadwithVersion",
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            if (data !== 0) {

                alert('File uploaded with version successfully');
                window.location.href = '/Files/FileListPage';

            } else {
                debugger;
                alert('File uploaded error');
            }
        },
        error: function (xhr,status,error) {
            debugger;
            console.log("Error", error);
            console.log("Error", status);
            alert('An error occurred during the file upload');
        }
    });
}




