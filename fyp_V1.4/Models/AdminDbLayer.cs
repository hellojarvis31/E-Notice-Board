using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class AdminDbLayer
    {

        public bool IsValid(string @EmployeeId, string @Password)
        {
            string query = "select Employee_id, Password from ADMIN where Employee_id = @EmployeeId AND Password = @Password";
            string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
        {
                //SqlCommand cmd = new SqlCommand("Add_Student", con);
                SqlCommand cmd = new SqlCommand(query, con);
                /// SqlCommand cmd2 = new SqlCommand(QueryValidateTimeStamp, con);
                //cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamEmployeeId = new SqlParameter();
                ParamEmployeeId.ParameterName = "@EmployeeId";
                ParamEmployeeId.Value = EmployeeId;
                cmd.Parameters.Add(ParamEmployeeId);

                SqlParameter ParamPassword = new SqlParameter();
                ParamPassword.ParameterName = "@Password";
                ParamPassword.Value = Password;
                cmd.Parameters.Add(ParamPassword);

                con.Open();
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }

        public void AddAdmin(Admin admin)
        {
            string query = "Insert into ADMIN(Employee_id, Name, Designation, Password, Admin_Type, Time_Stamp, Adding_Employee_Id) Values(@EmployeeId, @Name, @Designation, @Password, @AdminType, @Time_Stamp, @AddingEmployeeId)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = admin.EmployeeeId;
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamName = new SqlParameter();
                    ParamName.ParameterName = "@Name";
                    ParamName.Value = admin.Name;
                    cmd.Parameters.Add(ParamName);

                    SqlParameter ParamDesignation = new SqlParameter();
                    ParamDesignation.ParameterName = "@Designation";
                    ParamDesignation.Value = admin.Designation;
                    cmd.Parameters.Add(ParamDesignation);

                    SqlParameter ParamAdminType = new SqlParameter();
                    ParamAdminType.ParameterName = "@AdminType";
                    ParamAdminType.Value = admin.AdminType;
                    cmd.Parameters.Add(ParamAdminType);
                    
                    SqlParameter ParamPassword = new SqlParameter();
                    ParamPassword.ParameterName = "@Password";
                    ParamPassword.Value = admin.Password;
                    cmd.Parameters.Add(ParamPassword);

                    SqlParameter ParamTime_Stamp = new SqlParameter();
                    ParamTime_Stamp.ParameterName = "@Time_Stamp";
                    ParamTime_Stamp.Value = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");
                    cmd.Parameters.Add(ParamTime_Stamp);

                    SqlParameter ParamAddingEmployee = new SqlParameter();
                    ParamAddingEmployee.ParameterName = "@AddingEmployeeId";
                    ParamAddingEmployee.Value = admin.AddingEmployeeId;
                    cmd.Parameters.Add(ParamAddingEmployee);

                    
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Admin> ListAllAdmin()
        {
            List<Admin> AdminList = new List<Admin>();
            string query = "Select * from ADMIN";
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Admin admin = new Admin();
                        admin.EmployeeeId = rdr["Employee_Id"].ToString();
                        admin.Name = rdr["Name"].ToString();
                        admin.Designation = rdr["Designation"].ToString();
                        admin.AdminType = rdr["Admin_Type"].ToString();
                        admin.timeStamp = rdr["Time_Stamp"].ToString();
                        admin.AddingEmployeeId = rdr["Adding_Employee_Id"].ToString();
                        AdminList.Add(admin);
                    }
                    con.Close();
                    return AdminList;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsMain(string EmployeeId)
        {
            string query = "Select Admin_Type from ADMIN where Employee_Id = @EmployeeId";

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = EmployeeId;
                    cmd.Parameters.Add(ParamEmployeeId);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    string AdminType = "";
                    while (rdr.Read())
                    {
                        AdminType = rdr["Admin_Type"].ToString();
                    }
                    con.Close();
                    
                    if(AdminType.Equals("Main"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                {

                    }

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAdmin(string EmployeeId)
        {
            string query = "Delete From ADMIN where Employee_Id = @EmployeeId";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = EmployeeId;
                    cmd.Parameters.Add(ParamEmployeeId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
    
}