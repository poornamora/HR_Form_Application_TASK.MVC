
$(document).ready(function () {


    $('#searchbtn').on('click', function () {

        var id = $('#nameinput').val();
        if (id == '') {
            alert("Please enter ID.");
        }
        else if (id>=1) {
            var url = searchByIdUrl + '?id=' + id;
            window.location.href = url;
            $('#nameinput').val('');
        } else 
        {
            alert("Please enter valid ID.");
        }
    });
});
