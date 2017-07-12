$(document).ready(function () {
    $("#aply_advrtiser").click(function () {
        var status = $("#status").val();
        
        if (status == 1) {
            alert("sghsah");
            return null;
            alert("error");
        }
        else if (status == 2) {
            return null; 
        }
        else if (status == 0) {
            $.ajax({
                type: 'GET',
                dataType: 'Json',
                url: 'Home/aply_advertisr',
                data: { logginid: loginid },
                success: function (data) {

                }


            })
        }
            
    })
});