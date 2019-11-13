$(document).ready(function () {

    $(".pager .item-list").click(() => {

        alert($(this).text());
    });

    var usrSession = sessionStorage.getItem("user");
    //alert(usrSession);
    if (usrSession == null) {

        $("#ShowModal").modal({ backdrop: 'static', keyboard: false });
    }
    else {

        $("#username").text(usrSession.toUpperCase());

        $("#EditPatientForm").hide();
        //$("#EditDocForm").hide();
        //$("#MakeApForm").hide();

        $("#logout").click(() => {

            sessionStorage.clear();

        });

        $("#CreateNewIcon").click(() => {
            $("#createPatientForm").show();
            $("#EditPatientForm").hide();
        });

        $("#closeCreateIcon").click(() => {
            $("#createPatientForm").hide();
        });

        $("#SettingIcon").click(() => {
            $(".opCell").show();
        });

        $("#closeEditIcon").click(() => {
            $("#EditPatientForm").hide();

        });

        $(".EditIcon").click(() => {

            $("#createPatientForm").hide();
            $("#EditPatientForm").show();

        });

        $("#closeApIcon").click(() => {

            $("#MakeApForm").hide();
        });

        $("#closeDocEditIcon").click(() => {
            $("#EditDocForm").hide();
        });

        $("#CreateApIcon").click(() => {

            $("#MakeApForm").show();
        });


        //Radio
        $("#rdM").val(1);
        $("#rdF").val(0);
        $("#rdM2").val(1);
        $("#rdF2").val(0);
        $("#rdA").val(1);
        $("#rdU").val(0);

        $("#rdM").click(() => {
            $("#rdM").val(1);
            $("#rdF").val(0);
        });
        $("#rdF").click(() => {
            $("#rdF").val(1);
            $("#rdM").val(0);
        });

        $("#rdM2").click(() => {
            $("#rdM2").val(1);
            $("#rdF2").val(0);
        });
        $("#rdF2").click(() => {
            $("#rdF2").val(1);
            $("#rdM2").val(0);
        });
        $("#rdA").click(() => {
            $("#rdA").val(1);
            $("#rdU").val(0);

        });
        $("#rdU").click(() => {
            $("#rdU").val(1);
            $("#rdA").val(0);
        });



        //Datetime Picker
        $('#example').timepicker({
            timeFormat: 'h:mm p',
            interval: 60,
            minTime: '9',
            maxTime: '6:00pm',
            defaultTime: '11',
            startTime: '9:00',
            dynamic: false,
            dropdown: true,
            scrollbar: true
        });


        $('.table tbody').on('click', '.EditIcon', function () {

            $("#createPatientForm").hide();
            $("#EditPatientForm").show();

            var row = $(this).closest('tr');

            var pId = row.find('td:eq(0)').text();
            var pName = row.find('td:eq(1)').text();
            var pSex = row.find('td:eq(2)').text();
            var pTel = row.find('td:eq(3)').text();
            var pAddr = row.find('td:eq(4)').text();
            var pDocNo = row.find('td:eq(5)').text();
            var cNo = row.find('td:eq(6)').text();

            $('#efId').val(pId.trim());
            $('#efName').val(pName.trim());
            //$('#efSex').val(pSex.trim());
            $('#efTel').val(pTel.trim());
            $('#efAddr').val(pAddr.trim());
            $('#efDocNo').val(pDocNo.trim());
            $('#efCardNo').val(cNo.trim());

            if (pSex == 'M') {

                $("#rdM2").prop("checked", true);
                //$("#rdF2").attr("checked", false);

            }
            else {

                $("#rdF2").prop("checked", true);
                //$("#rdM2").attr("checked", false);
            }
            //alert(pSex);
        });

        $('.table tbody').on('click', '.EditDocIcon', function () {

            $("#EditDocForm").show();

            var row = $(this).closest('tr');

            var id = row.find('td:eq(0)').text();
            var q = row.find('td:eq(5)').text();
            var status = row.find('td:eq(6)').text().trim();

            $('#efDId').val(id.trim());
            $('#efDq').val(q.trim());

            if (status == '0') {

                $("#rdU").prop("checked", true);
                //$("#rdA").attr("checked", false);
            }
            else {

                $("#rdA").prop("checked", true);
                //$("#rdU").attr("checked", false);
            }
        });

        $('.table tbody').on('click', '#DeleteIcon', function () {
            var row = $(this).closest('tr');

            var pId = row.find('td:eq(0)').text();
            var pName = row.find('td:eq(1)').text();

            if (confirm("Are you sure want to delete No: " + pId + " " + pName)) {
                var data = {
                    PId: pId
                };

                $.ajax({
                    type: "POST",
                    url: "/home/Delete",
                    data: JSON.stringify(data),
                    contentType: "application/json",

                    success: function (res) {
                        if (res == true) {

                            LoadPatientData();

                        }
                    }

                });
                $(".opCell").show();
            }
        });

        $('.table tbody').on('click', '#PayIcon', function () {
            var conf = "";
            var row = $(this).closest('tr');

            var id = row.find('td:eq(0)').text().trim();
            var fee = row.find('td:eq(2)').text().trim();
            var dId = row.find('td:eq(3)').text().trim();
            var status = row.find('td:eq(5)').text().trim();

            if (status == "Uncharged") {
                conf = "Are you sure want to pay for ID: " + id;
                status = 0;
            }
            else {
                conf = "Are you sure want to undo the payment for ID: " + id;
                status = 1;
            }

            if (confirm(conf)) {
                data = {
                    ChFee: fee,
                    ApId: id,
                    DId: dId,
                    ChStatus: status
                };

                $.ajax({
                    type: "POST",
                    url: "/Appointment/PayFee",
                    data: JSON.stringify(data),
                    contentType: "application/json",

                    success: function (res) {
                        if (res == true) {

                            LoadAppointmentData();

                        }
                        else {
                            alert("The Queue is now full.");
                        }
                    }

                });
            }

        });

        $('.table tbody').on('click', '#UndoIcon', function () {
            var conf = "";
            var row = $(this).closest('tr');

            var id = row.find('td:eq(0)').text().trim();
            var fee = row.find('td:eq(2)').text().trim();
            var dId = row.find('td:eq(3)').text().trim();
            var status = row.find('td:eq(5)').text().trim();


            conf = "Are you sure want to cancel the appointment ID: " + id;
            status = 1;


            if (confirm(conf)) {
                data = {

                    ApId: id,
                    DId: dId,
                    ApStatus: status
                };

                $.ajax({
                    type: "POST",
                    url: "/Appointment/CancelAppointment",
                    data: JSON.stringify(data),
                    contentType: "application/json",

                    success: function (res) {
                        if (res == true) {

                            LoadAppointmentData();

                        }
                        else {
                            alert("Unable to cancel the appointment.");
                        }
                    }

                });
            }

        });

        $("#search").keyup(() => {

            $(".rows").each(function () {

                var searchText = $("#search").val().toLowerCase();

                if ($(this).text().toLowerCase().indexOf(searchText) != -1)

                    $(this).show();
                else
                    $(this).hide();
            });

        });
        
    }

});

function Login() {
    //alert($("#rdF").val() + "-" + $("#rdM").val());
    
    var user = $("#usr").val().trim();
    var pw = $("#pw").val().trim();

    if (user != "" && pw != "") {

        var data = {
            Username: user,
            Password: pw,

        };

        $.ajax({
            type: "POST",
            url: "/home/Login",
            data: JSON.stringify(data),
            contentType: "application/json",

            success: function (res) {

                if (res == true) {

                    //LoadPatientData();
                    sessionStorage.setItem("user", user);
                    var usrName = sessionStorage.getItem("user");
                    $("#username").text(usrName.toUpperCase());

                    $("#ShowModal").modal("hide");

                    //$("#logout").attr("href", "/home/Logout/" + usrName)
              

                    location.reload(true);
                }
                else {

                    alert("Username or password is incorrect!");
                }
            },
            error: function (ex) {
                console.log(ex);
            }

        });

    }
    else {
        alert("All fields are required!")
    }
}


function LoadPatientData() {

    $('#tbStudentList').find('tr').detach();

    $.get("/home/GetPatientList", null, function (stdList) {
         
        var setData = $("#tbStudentList");
        for (var i = 0; i < stdList.length; i++) {
            var data = "<tr class='rows' >" +
                "<td>" + stdList[i].PId + "</td>" +
                "<td>" + stdList[i].PName + "</td>" +
                "<td>" + stdList[i].PSex + "</td>" +
                "<td>" + stdList[i].PTel + "</td>" +
                "<td>" + stdList[i].PAddress + "</td>" +
                "<td>" + stdList[i].PDocumentNo + "</td>" +
                "<td>" + stdList[i].CNo + "</td>" +
                "<td class='opCell'><a class='EditIcon opIcon'  title='Edit'><i class='btn EditIcon far fa-edit text-info' style='font-size:18px; padding: 0;'></i></a>" +
                "<a id='DeleteIcon' class='opIcon' title='Delete' ><i class='btn far fa-trash-alt text-danger' style='font-size: 18px;  padding: 0;'></i></a></td>" +
                "</tr>";
            setData.append(data);
        }

        setTimeout(() => {
      
            $("#patientListTable").DataTable();

        });
    });
}

function LoadDoctorData() {

    $('#tbDocList').find('tr').detach();

    $.get("/doctor/GetDoctorsList", null, function (docList) {

        var setData = $("#tbDocList");
        for (var i = 0; i < docList.length; i++) {
            var data = "<tr class='rows' >" +
                "<td>" + docList[i].DId + "</td>" +
                "<td>" + docList[i].DName + "</td>" +
                "<td>" + docList[i].DSex + "</td>" +
                "<td>" + docList[i].DFee + "</td>" +
                "<td>" + docList[i].DTel + "</td>" +
                "<td>" + docList[i].DApQueue + "</td>" +
                "<td>" + docList[i].DStatus + "</td>" +
                "<td ><a class='EditDocIcon opIcon'  title='Edit'><i class=' far fa-edit btn text-info' style='font-size:18px;color:gray;padding: 0px;'></i></a>" +
                "</tr>";
            setData.append(data);
        }

        setTimeout(() => {

            $("#DoctListTable").DataTable();

        });
    });
}

function LoadAppointmentData() {


    $('#tbApList').find('tr').detach();

    $.get("/appointment/GetAppointmentList", null, function (ApList) {

        var setData = $("#tbApList");
        for (var i = 0; i < ApList.length; i++) {
            var chStatus, icon, icon2;

            if ((ApList[i].ApStatus == 0)) {

                if ((ApList[i].ChStatus == 0)) {
                    chStatus = "Uncharged";
                    icon2 = "<a id='UndoIcon'  title='Click to Cancel'><i class='btn fas fa-undo text-info' style='font-size: 18px;'></i></a>";
                    icon = "<a id='PayIcon'  title='Click to Pay'><i class='btn fas fa-exclamation-triangle text-warning' style='font-size: 18px;'></i></a>";
                }

                else {
                    icon2 = "";
                    icon = "<a title='Paid'><i class='btn fas fa-check-circle text-success' style='font-size: 18px;'></i></a>";
                    chStatus = "Charged";

                }
            }
            else {

                icon = "";
                icon2 = "<a  title='Cancelled'><i class='btn far fa-times-circle text-danger' style='font-size: 18px;'></i></a>";
                if ((ApList[i].ChStatus == 0))
                    chStatus = "Uncharged";
                else chStatus = "Charged";
            }


            var data = "<tr class='rows' >" +
                "<td>" + ApList[i].ApId + "</td>" +
                "<td>" + ApList[i].CNo + "</td>" +
                "<td>" + ApList[i].ChFee + "</td>" +
                "<td>" + ApList[i].Doctor.DId + "</td>" +
                "<td>" + ApList[i].ApDate + "</td>" +
                "<td>" + chStatus + "</td>" +
                "<td >" +
                icon2 +
                icon +
                "</td>" +
                "</tr>";
            setData.append(data);

        }
        setTimeout(() => {

            $("#ApTable").DataTable();

        });
    });


}

function CheckAptByDate() {

    var date1 = $("#ApDate1").val();
    var date2 = $("#ApDate2").val();

    var data = {
        Date1: date1,
        Date2: date2,

    };

    $('#tbApList').find('tr').detach();

    $.ajax({
        type: "POST",
        url: "/appointment/GetAppointmentListByDate",
        data: JSON.stringify(data),
        contentType: "application/json",

        success: function (ApList) {

            var setData = $("#tbApList");
            for (var i = 0; i < ApList.length; i++) {
                var chStatus, icon, icon2;

                if ((ApList[i].ApStatus == 0)) {

                    if ((ApList[i].ChStatus == 0)) {
                        chStatus = "Uncharged";
                        icon2 = "<a id='UndoIcon'  title='Click to Cancel'><i class='btn fas fa-undo text-info' style='font-size: 18px;'></i></a>";
                        icon = "<a id='PayIcon'  title='Click to Pay'><i class='btn fas fa-exclamation-triangle text-warning' style='font-size: 18px;'></i></a>";
                    }

                    else {
                        icon2 = "";
                        icon = "<a title='Paid'><i class='btn fas fa-check-circle text-success' style='font-size: 18px;'></i></a>";
                        chStatus = "Charged";

                    }
                }
                else {

                    icon = "";
                    icon2 = "<a  title='Cancelled'><i class='btn far fa-times-circle text-danger' style='font-size: 18px;'></i></a>";
                    if ((ApList[i].ChStatus == 0))
                        chStatus = "Uncharged";
                    else chStatus = "Charged";
                }


                var data = "<tr class='rows' >" +
                    "<td>" + ApList[i].ApId + "</td>" +
                    "<td>" + ApList[i].CNo + "</td>" +
                    "<td>" + ApList[i].ChFee + "</td>" +
                    "<td>" + ApList[i].Doctor.DId + "</td>" +
                    "<td>" + ApList[i].ApDate + "</td>" +
                    "<td>" + chStatus + "</td>" +
                    "<td >" +
                    icon2 +
                    icon +
                    "</td>" +
                    "</tr>";
                setData.append(data);

            }
            setTimeout(() => {

                $("#ApTable").DataTable();

            });
        }
    });
}

function CheckLogByDate() {

    var date1 = $("#LogDate1").val();
    var date2 = $("#LogDate2").val();

    var data = {
        Date1: date1,
        Date2: date2,

    };

    $('#tbLogList').find('tr').detach();

    $.ajax({
        type: "POST",
        url: "/Log/GetLogListByDate",
        data: JSON.stringify(data),
        contentType: "application/json",

        success: function (ApList) {

            var setData = $("#tbLogList");
            for (var i = 0; i < ApList.length; i++) {
              
                var data = "<tr class='rows' >" +
                    "<td>" + ApList[i].Id + "</td>" +
                    "<td>" + ApList[i].Date + "</td>" +
                    "<td>" + ApList[i].Action + "</td>" +
                    "<td>" + ApList[i].Message + "</td>" +
                    "<td>" + ApList[i].Exception + "</td>" + 
                    "</tr>";
                setData.append(data);

            }
            setTimeout(() => {

                $("#LogTable").DataTable();

            });
        }
    });
}



function CreateInfo() {
    //alert($("#rdF").val() + "-" + $("#rdM").val());

    var sex = "";
    if ($("#rdM").val() == 1) {
        sex = "M";
    }
    else sex = "F";

    var cNo = $("#crCard").val().trim();
    var name = $("#crName").val().trim();
    //var sex = $("#crSex").val().trim();
    var tel = $("#crTel").val().trim();
    var addr = $("#crAddr").val().trim();
    var docNo = $("#crDocNo").val().trim();

    if (cNo != "" && name != "" && sex != "" && tel != "" && docNo != "") {

        var data = {
            CardNo: cNo,
            PName: name,
            PSex: sex,
            PTel: tel,
            PAddress: addr,
            PdocumentNo: docNo

        };

        $.ajax({
            type: "POST",
            url: "/home/CreateInfo",
            data: JSON.stringify(data),
            contentType: "application/json",

            success: function (res) {
                if (res == true) {

                    LoadPatientData();

                    //$("#patientListTable").append(newRow)
                }
                else
                    alert("Your Card ID has been used.");
            }

        });
    }
    else {
        alert("All fields are required!")
    }

}

function MakeApt() {

    var cNo = $("#apfCNo").val().trim();
    var name = $("#apfName").val().trim();
    var split = name.split("-");
    var dName = split[0];

    var fee = $("#apfFee").val().trim();
    var date = $("#example").val().trim();

    var usrName = sessionStorage.getItem("user");


    if (cNo != "" && dName != "" && fee != 0 && date != "") {

        //get current date
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();

        var output = d.getFullYear() + '/' +
            (month < 10 ? '0' : '') + month + '/' +
            (day < 10 ? '0' : '') + day + " " + date;

        alert(output);

        var data = {
            CNo: cNo,
            DId: dName,
            ApDate: date,
            ChFee: fee,
            SpUsername: usrName,

        };

        $.ajax({
            type: "POST",
            url: "/Appointment/MakeAppointment",
            data: JSON.stringify(data),
            contentType: "application/json",

            success: function (res) {
                if (res == true) {

                    LoadAppointmentData();

                }
                else
                    alert("Make sure your card number is correct and the doctor is available!");
            }

        });
    }
    else {
        alert("All fields are required!")
    }
}

function EditInfo() {

    var sex = "";
    if ($("#rdM2").val() == 1) {
        sex = "M";
    }
    else sex = "F";

    var id = $("#efId").val().trim();
    var cNo = $("#efCardNo").val().trim();
    var name = $("#efName").val().trim();
    //var sex = $("#efSex").val().trim();
    var tel = $("#efTel").val().trim();
    var addr = $("#efAddr").val().trim();
    var docNo = $("#efDocNo").val().trim();

    if (cNo != "" && name != "" && sex != "" && tel != "" && docNo != "") {

        var data = {
            PId: id,
            CardNo: cNo,
            PName: name,
            PSex: sex,
            PTel: tel,
            PAddress: addr,
            PdocumentNo: docNo

        };

        $.ajax({
            type: "POST",
            url: "/home/EditPatientInfo",
            data: JSON.stringify(data),
            contentType: "application/json",

            success: function (res) {
                if (res == true) {

                    LoadPatientData();

                }
            }

        });
    }
    else {
        alert("All fields are required!")
    }
}

function EditDocStatus() {

    var status = null;

    if ($("#rdA").val() == 1) {

        status = 1;
    }
    else status = 0;

    var id = $("#efDId").val();
    var q = $("#efDq").val();

    //alert(id + "-" + q + "-" + status);
    if (id != 0 && q != "" && status != null) {

        var data = {
            DId: id,
            DApQueue: q,
            DStatus: status
        };

        $.ajax({
            type: "POST",
            url: "/doctor/EditDocStatus",
            data: JSON.stringify(data),
            contentType: "application/json",

            success: function (res) {
                if (res == true) {

                    LoadDoctorData();

                }
            }

        });
    }
    else {
        alert("Select a doctor.");
    }

}