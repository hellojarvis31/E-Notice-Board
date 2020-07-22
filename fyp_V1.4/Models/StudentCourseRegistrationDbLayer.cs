using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class StudentCourseRegistrationDbLayer
    {
        public void RegisterCourse(string @CourseCode, int @RollNumber, string @DegreeTitle, string @Session, string RegisterType)
        {
            string query = "insert into STUDENT_COURSE_REGISTRATION values(@CourseCode, @RollNumber, @DegreeTitle, @Session, @RegisterType)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    SqlParameter ParamCourseCode = new SqlParameter();
                    ParamCourseCode.ParameterName = "@CourseCode";
                    ParamCourseCode.Value = CourseCode;
                    cmd.Parameters.Add(ParamCourseCode);

                    SqlParameter ParamRollNUmber = new SqlParameter();
                    ParamRollNUmber.ParameterName = "@RollNumber";
                    ParamRollNUmber.Value = RollNumber;
                    cmd.Parameters.Add(ParamRollNUmber);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@DegreeTitle";
                    ParamDegreeTitle.Value = DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);

                    SqlParameter ParamSession = new SqlParameter();
                    ParamSession.ParameterName = "@Session";
                    ParamSession.Value = Session;
                    cmd.Parameters.Add(ParamSession);

                    SqlParameter ParamRegisterType = new SqlParameter();
                    ParamRegisterType.ParameterName = "@RegisterType";
                    ParamRegisterType.Value = RegisterType;
                    cmd.Parameters.Add(ParamRegisterType);


                    //SqlParameter ParamTime_Stamp = new SqlParameter();
                    //ParamTime_Stamp.ParameterName = "@Time_Stamp";
                    //ParamTime_Stamp.Value = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");
                    //cmd.Parameters.Add(ParamTime_Stamp);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentCourseRegistration> ListStudentCourseRegistration()
        {
            string query = "Select * from STUDENT_COURSE_REGISTRATION";

            List<StudentCourseRegistration> studentCourseRegistrationList = new List<StudentCourseRegistration>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query,con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        StudentCourseRegistration studentCourseRegistration = new StudentCourseRegistration();
                        studentCourseRegistration.CourseCode = rdr["Course_Code"].ToString();
                        studentCourseRegistration.DegreeTitle = rdr["Degree_Title"].ToString();
                        studentCourseRegistration.RollNumber = Convert.ToInt32(rdr["Roll_Number"]);
                        studentCourseRegistration.Session = rdr["Session"].ToString();
                        studentCourseRegistration.RegisterType = rdr["Register_Type"].ToString();
                        studentCourseRegistrationList.Add(studentCourseRegistration);
                    }
                    con.Close();
                    return studentCourseRegistrationList;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteStudentCourseRegistration(string @CourseCode, int @RollNumber, string @DegreeTitle, string @Session)
        {
            String QueryValidate = "Delete from STUDENT_COURSE_REGISTRATION where Course_Code = @CourseCode AND Roll_Number =  @RollNumber AND Degree_Title =  @DegreeTitle  AND Session =  @Session";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(QueryValidate, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParamCourseCode = new SqlParameter();
                    ParamCourseCode.ParameterName = "@CourseCode";
                    ParamCourseCode.Value = CourseCode;
                    cmd.Parameters.Add(ParamCourseCode);

                    SqlParameter ParamRollNumber = new SqlParameter();
                    ParamRollNumber.ParameterName = "@RollNumber";
                    ParamRollNumber.Value = RollNumber;
                    cmd.Parameters.Add(ParamRollNumber);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@DegreeTitle";
                    ParamDegreeTitle.Value = DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);



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