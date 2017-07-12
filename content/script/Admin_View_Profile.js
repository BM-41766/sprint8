$(document).on('click', '#vewprflebtn', function () {
    $(".usereditprofile").empty();
    var loginid1 = $(this).data("id");
    //var loginid1 = $("#X_mainloginid").val();
  
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: 'Home/editUserprofile1',
        data: { loginid: loginid1 },
        success: function (data) {
            for (var x = 0; x < data.length; x++) {
                console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic + "days:" + data[x].day+"month:"+data[x].month+"year:"+data[x].year+"gender:"+data[x].gender+"email:"+data[x].emailaddress);
                //var html = '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname +' </label>' + '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>';
                var html = '<div style="background-color:white;width:400px;margin-left:100px;"><label>' + data[x].firstname + data[x].surname + ' </label>' + '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;margin-left:200px;"/><br><br><input type="button" value="Suspend" id="btn_suspend" data-id="' + data[x].loginid + '" style="background-color:blue;color:white;"/><input type="button" value="Delete" id="btn_delete" data-id="' + data[x].loginid + '" style="background-color:blue;color:white;" /><br><br><label>email:' + data[x].emailaddress + '</label><br><input type="text" value=' + data[x].emailaddress + ' id="email"/><br><label>Day:' + data[x].day + '</label><br><br><label>Month:' + data[x].month + '</label><br><br><label>year:' + data[x].year + '</label><br><br><label>gender:' + data[x].gender + '</label></div>';
                $(".proflelist").append(html);
            }
        }
    })
});