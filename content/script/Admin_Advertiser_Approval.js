$(document).ready(function () {
    $("#pnding_Approval").click(function () {
        var loginid1 = $(this).data("id");
        // var loginid1 = $("#id").val();
        alert("sahgdakj");
        alert(loginid1);
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/Aproval_pending',
            data: { loginid: loginid1 },
            success: function (data) {
                for (var x = 0; x < data.length; x++) {
                    console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                    var html = '<div style="background-color:white;width:400px;margin-left:150px;margin-top:10px;"><img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '</label> <input type="button" value="Approve" id="Aprove" style="margin-left:135px;margin-top:-35px;" data-id="' + data[x].loginid + '"/><br></div>';
                    $(".Approval_pending").append(html);

                }

            }
        })
    })
});