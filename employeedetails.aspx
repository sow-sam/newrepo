<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employeedetails.aspx.cs" Inherits="applicationusingcurd.employeedetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.2.1.min.js"></script>
    <script src="Data/employees.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divData">
            EMPLOYEE ID
            <input id="empid" type="text" /><br />
            EMPLOYEE NAME
            <input id="empname" type="text" /><br />
            EMPLOYEE DESIGNATION<input id="empdesignation" type="text" /><br />
            <br />
            <input id="save" type="button" value="save" onclick="saveData()" />
            <input id="update" type="button" value="update" onclick="updateemp()" />
            <input id="delete" type="button" value="delete" onclick="deleteemp()" />
            <select id="Select1">
                <option></option>

            </select>
            <input id="add" type="button" value="add data" />
        </div>
        <div id="addemp" >
            <table></table>
        </div>
    </form>
    <p>
    </p>
    <p>
        <input id="select" type="button" value="view the data" onclick="binds()" />
    </p>
</body>
<script src="employee.js"></script>
<script src="JavaScript/Internal/Insert_Employee_details.js"></script>
</html>
