 $(document).ready(function () {
    $("#useredit").click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'Json',
            url: 'Home/Userprofile1',
            data: {},
            success: function (data) {
                for (var x = 0; x < data.length; x++) {
                    console.log("ID: " + data[x].loginid + " name: " + data[x].firstname + " picture: " + data[x].profilepic);
                    var html = '<img src="' + data[x].profilepic + '"style="height:55px;width:30px;"/>' + '<label style="margin-top:-35px; margin-left:50px;">' + data[x].firstname + data[x].surname + '</label> <input type="button" value="viewprofile" id="vewprflebtn" style="margin-left:135px;margin-top:-35px;" data-id="' + data[x].loginid + '"/><br>';
                    $(".usereditprofile").append(html);
                    //$("#hde").show();
                }

            }
        })
    })
});