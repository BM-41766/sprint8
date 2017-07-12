$(document).on('click', '#btn_delete', function () {
    var id = $(this).data("id");
    var email = $("#email").val();
    alert(id);
    alert(email);
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/admin_delete',
        data: { loginid: id, emailaddress: email },
        success: function (data) {
        }
    })
});