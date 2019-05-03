function saveData() {   
    var id = $("#empid").val();
    var name = $("#empname").val();
    var designation = $("#empdesignation").val();
    alert(name);
    $.ajax({
        type: "POST",
        url: "Employee.asmx/employeeadd",
        data: "{e_id:'" + id + "',e_name:'" + name + "',e_designation:'" + designation + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (responseFromServer)
        {
            alert(responseFromServer.d)
            alert("success");
        }
    });
}
function updateemp()
{
    var id = $("#empid").val();
    var name = $("#empname").val();
    var designation = $("#empdesignation").val();
    alert(name);
    $.ajax({
        type: "POST",
        url: "Employee.asmx/update_employee",
        data: "{e_id:'" + id + "',e_name:'" + name + "',e_designation:'" + designation + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function () {
            alert("success");
        }
    });
}

function binds() {
    alert("bind");
    $.ajax({
        type: "POST",  
        url: "Employee.asmx/binds",
        data: "{}",
        contentType: "application/json; charset=utf-8",  
        dataType: "json",
        async:"true",
        success: function (response) {
            var TableContent = "<table>" +
            "<tr>" +
            "<td>id</td>" +
            "<td>Name</td>" +
            "<td>Designation</td>" +
            "</tr>";
            for (var i = 0; i < response.d.length; i++) {
                TableContent += "<tr>" +
                "<td>" + response.d[i].e_id + "</td>" +
                "<td>" + response.d[i].e_name + "</td>" +
                 "<td>" + response.d[i].e_designation + "</td>" +

               "</tr>";
            }
            TableContent += "</table>";
            $("#addemp").html(TableContent);
            debugger;
       }
       });
}
function deleteemp() {
    var id = $("#empid").val();
    var name = $("#empname").val();
    var designation = $("#empdesignation").val();
    alert(name);
    $.ajax({
        type: "POST",
        url: "Employee.asmx/deleteemployee",
        data: "{e_id:'" + id + "',e_name:'" + name + "',e_designation:'" + designation + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function () {
            alert("success");
        }
    });
}
