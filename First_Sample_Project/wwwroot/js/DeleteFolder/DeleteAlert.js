
$(document).ready( function(){

    $(".delete-link").on("click", function (e) {
        //e.preventDefault();

        var id = $(this).data('id');
        console.log(id)

        var url = deleteById + '?id=' + id 

        $.ajax({
            url: url,
            type: 'Post',
            data:id,
            success: function (data) {
                if (data != null) {
                    alert('Record Deleted successfully',id);
                    window.location.href = '/Home/ListPage';
                }
                else {
                    alert('Unable to Delete');
                }
            },
            error: function (xhr, status, error) {
                console.error("Error", error);
                console.error("Status", status);
            }
        })
    });
});