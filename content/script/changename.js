$(document).ready(function () {
    $("#aply_advrtiser").hover(function () {
        var status = $("status").val();
        if(status==1)
        {
            $("#aply_advrtiser").empty();
            $("#aply_advrtiser").append("Advertiser Role approval pending");
        }
        else
        {
            $("#aply_advrtiser").empty();
            $("#aply_advrtiser").append("Apply For Advertisement");
        }
    })
});