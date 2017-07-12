$(document).ready(function () {
    $("#aply_advrtiser").click(function () {
        var name = $("#aply_advrtiser").text();
        if (name == "Apply For Advertisement") {
            $("#aply_advrtiser").empty();
            $("#aply_advrtiser").append("Advertiser Role approval pending");
            alert(name);
            var loginid = $("#X_mainloginid").val();
              $.ajax({
                    type: 'GET',
                    dataType: 'Json',
                    url: 'Home/aply_advertisr',
                    data: { logginid: loginid },
                    success: function (data) {

                    }


                })
            }
       // }
    });
});
