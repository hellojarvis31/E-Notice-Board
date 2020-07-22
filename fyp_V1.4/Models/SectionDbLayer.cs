using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class SectionDbLayer
    {
        public void AddSection(Section section)
        {
            string query = "Insert into Section values(@DegreeTitle, @Section, @TimeStamp, @AddingEmployeeId)";

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@DegreeTitle";
                    ParamDegreeTitle.Value = section.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);

                    SqlParameter ParamSection = new SqlParameter();
                    ParamSection.ParameterName = "@Section";
                    ParamSection.Value = section.DegreeSection;
                    cmd.Parameters.Add(ParamSection);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = section.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamAddingEmployeeId = new SqlParameter();
                    ParamAddingEmployeeId.ParameterName = "@AddingEmployeeId";
                    ParamAddingEmployeeId.Value = section.AddingEmployeeId;
                    cmd.Parameters.Add(ParamAddingEmployeeId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Section> ListAllSection()
        {
            string query = "Select * from Section";

            List<Section> SectionList  = new List<Section>();
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
                        Section section = new Section();
                        section.DegreeSection = rdr["Section"].ToString();
                        section.DegreeTitle = rdr["Degree_Title"].ToString();
                        section.TimeStamp = rdr["Time_Stamp"].ToString();
                        section.AddingEmployeeId = rdr["Adding_Employee_Id"].ToString();
                        SectionList.Add(section);
                    }
                    con.Close();
                    return SectionList;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSection(string section, string DegreeTitle)
        {
            String QueryValidate = "Delete from Section where Section =  @Section AND Degree_Title = @DegreeTiTle";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(QueryValidate, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParamSection = new SqlParameter();
                    ParamSection.ParameterName = "@Section";
                    ParamSection.Value = section;
                    cmd.Parameters.Add(ParamSection);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@DegreeTiTle";
                    ParamDegreeTitle.Value = DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}