$(document).ready(function () {
    $("#editprfle").click(function () {
        $("#hide").hide();
        $("#pre1").hide();
        var loginid1 = $("#X_mainloginid").val();
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/edit_userprofile',
            data: { logginid: loginid1 },
            success: function (data) {
                for (var x = 0; x < data.length; x++) {
                    console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic + "days:" + data[x].day + "month:" + data[x].month + "year:" + data[x].year + "gender:" + data[x].gender + "email:" + data[x].emailaddress);

                    var html = '<div style="background-color:white;width:400px;margin-left:100px;"><label>' + data[x].firstname + data[x].surname + ' </label>' + '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;margin-left:200px;margin-top:-20px;"/><br><label>email:' + data[x].emailaddress + '</label><br><br><label>Day:' + data[x].day + '</label><br><label>Month:' + data[x].month + '</label><br><label>year:' + data[x].year + '</label><br><br><label>gender:' + data[x].gender + '</label><br><input type="button" value="Save" style="background-color:blue;color:white;margin-left:200px;"/></div>';
                    $(".prof_edit").append(html);
                }
            }
        })
    })
});