$(document).on('click', '#btn_suspend', function () {
    var id = $(this).data("id");
    alert("kfj");
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/Suspend',
        data: { loginid: id },
        success: function (data) {
        }
    })
});