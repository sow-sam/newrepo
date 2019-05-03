using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Script.Services;
using applicationusingcurd.Model;

namespace applicationusingcurd
{
    /// <summary>
    /// Summary description for Employee
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Employee : System.Web.Services.WebService
    {
       
        [WebMethod]
        public string employeeadd(string e_id, string e_name, string e_designation)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string Query = string.Empty;
            Query = "INSERT INTO employee_details (Empid,Empname,Empdesignation) VALUES (" + e_id + ",'" + e_name + "','" + e_designation + "')";
            SqlCommand cmd = new SqlCommand(Query, sqlcon);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            return "added employee successfully";
        }
        [WebMethod]
        public string update_employee(string e_id, string e_name, string e_designation)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string Query = string.Empty;
            Query = "update employee_details set Empname='" + e_name + "',Empdesignation='" + e_designation + "' where Empid=(" + e_id + ")";
            SqlCommand cmd = new SqlCommand(Query, sqlcon);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            return "updated successfully";
        }
        [WebMethod]
        public string deleteemployee(string e_id, string e_name, string e_designation)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            try
            {
                string Query = string.Empty;
                Query = "delete from employee_details where Empid=(" + e_id + ")";
                SqlCommand cmd = new SqlCommand(Query, sqlcon);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                return "updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public empclass[] binds()
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            EmpCollection data = new EmpCollection();
            SqlConnection sqlcon = new SqlConnection(con);
            string Query = string.Empty;
            Query = "select * from employee_details";
            SqlCommand cmd = new SqlCommand(Query, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                empclass emp = new empclass();
                emp.e_id = dr["Empid"].ToString();
                emp.e_name = dr["Empname"].ToString();
                emp.e_designation = dr["Empdesignation"].ToString();
                data.Add(emp);
            }
            return data.ToArray();
        }
        [WebMethod]
       public string empadd(List<Employees> edata)
            //public Employee[] empadd()
        {
            try
            {
                string con = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
               // EmplstCollection d = new EmplstCollection();

                SqlConnection sqlcon = new SqlConnection(con);
                sqlcon.Open();
                  string Query = string.Empty;
                
               int get;
                foreach (Employees i in edata)
                {
                    get = 0;
                    Query = "INSERT INTO emp1 (firstname,lastname,address,phoneno,emailid,role) VALUES ('" + i.firstname + "','" + i.lastname + "','" + i.address + "','" + i.phoneno + "','" + i.emailid + "','" + i.role + "')";
                    SqlCommand cmd = new SqlCommand(Query, sqlcon);
                   get= cmd.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "not done";
        }
    }
}



