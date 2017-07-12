$(document).on('click', '#Aprove', function () {
    var logginid = $(this).data("id");
    $(this).prop('value', 'Approve Advertiser Request');
    alert(logginid);
    $.ajax({

        type: 'GET',
        dataType: 'Json',
        url: 'Home/approv',
        data: { loginid: logginid },
        success: function (data) {
        }
    })

});