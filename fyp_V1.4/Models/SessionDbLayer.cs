using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class SessionDbLayer
    {
        public void AddSession(Session session)
        {
            string query = "Insert into Session values(@DegreeTitle, @Session, @TimeStamp, @AddingEmployeeId)";

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@DegreeTitle";
                    ParamDegreeTitle.Value = session.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);

                    SqlParameter ParamSession = new SqlParameter();
                    ParamSession.ParameterName = "@Session";
                    ParamSession.Value = session.DegreeSession;
                    cmd.Parameters.Add(ParamSession);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = session.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamAddingEmployeeId = new SqlParameter();
                    ParamAddingEmployeeId.ParameterName = "@AddingEmployeeId";
                    ParamAddingEmployeeId.Value = session.AddingEmployeeId;
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

        public List<Session> ListAllSession()
        {
            string query = "Select * from Session";

            List<Session> SessionList= new List<Session>();
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
                        Session session = new Session();
                        session.DegreeSession = rdr["Session"].ToString();
                        session.DegreeTitle = rdr["Degree_Title"].ToString();
                        session.TimeStamp = rdr["Time_Stamp"].ToString();
                        session.AddingEmployeeId = rdr["Adding_Employee_Id"].ToString();
                        SessionList.Add(session);
                    }
                    con.Close();
                    return SessionList;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteSession(string Session)
        {
            String QueryValidate = "Delete from SESSION where Session =  @Session";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(QueryValidate, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParamSession = new SqlParameter();
                    ParamSession.ParameterName = "@Session";
                    ParamSession.Value = Session;
                    cmd.Parameters.Add(ParamSession);


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