using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class StudentDbLayer
    {

        public void AddStudent(Student appliedstudent)
        {
            string querry = "Insert Into APPLIED_STUDENT values(@Name, @RollNumber, @Degree_Title, @Session, @Section, @Semester, @Morning_Evening, @Password, @Time_Stamp)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(querry, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParamName = new SqlParameter();
                    ParamName.ParameterName = "@Name";
                    ParamName.Value = appliedstudent.Name;
                    cmd.Parameters.Add(ParamName);

                    SqlParameter ParamRollNUmber = new SqlParameter();
                    ParamRollNUmber.ParameterName = "@RollNumber";
                    ParamRollNUmber.Value = Convert.ToInt32(appliedstudent.RollNumber);
                    cmd.Parameters.Add(ParamRollNUmber);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@Degree_Title";
                    ParamDegreeTitle.Value = appliedstudent.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);

                    SqlParameter ParamSession = new SqlParameter();
                    ParamSession.ParameterName = "@Session";
                    ParamSession.Value = appliedstudent.Session;
                    cmd.Parameters.Add(ParamSession);

                    SqlParameter ParamSection = new SqlParameter();
                    ParamSection.ParameterName = "@Section";
                    ParamSection.Value = appliedstudent.Section;
                    cmd.Parameters.Add(ParamSection);

                    SqlParameter ParamSemester = new SqlParameter();
                    ParamSemester.ParameterName = "@Semester";
                    ParamSemester.Value = Convert.ToInt32(appliedstudent.Semester);
                    cmd.Parameters.Add(ParamSemester);

                    SqlParameter ParamMorning_Evening = new SqlParameter();
                    ParamMorning_Evening.ParameterName = "@Morning_Evening";
                    ParamMorning_Evening.Value = appliedstudent.MorningEvening;
                    cmd.Parameters.Add(ParamMorning_Evening);

                    SqlParameter ParamPassword = new SqlParameter();
                    ParamPassword.ParameterName = "@Password";
                    ParamPassword.Value = appliedstudent.Password;
                    cmd.Parameters.Add(ParamPassword);

                    SqlParameter ParamTime_Stamp = new SqlParameter();
                    ParamTime_Stamp.ParameterName = "@Time_Stamp";
                    ParamTime_Stamp.Value = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");
                    cmd.Parameters.Add(ParamTime_Stamp);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void validateStudent(int @RollNumber, String @DegreeTitle, String @Session)
        {
            //String QueryValidate = "insert into STUDENT select Name, Roll_Number, Degree_Title, Session, Section, Semester, Morning_Evening, Password from APPLIED_STUDENT where Roll_Number =  @RollNumber AND Degree_Title =  @DegreeTitle  AND Session =  @Session";
            //String QueryValidateTimeStamp = "insert into STUDENT(Time_Stamp) values(@TimeStamp) ";
            String QueryValidate = "insert into STUDENT(Name, Roll_Number, Degree_Title, Session, Section, Semester, Morning_Evening, Password, Time_Stamp) values ((select Name from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), (select Roll_Number from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), (select Degree_Title from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), (select Session from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), (select Section from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), (select Semester from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), (select Morning_Evening from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), (select Password from APPLIED_STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session), @TimeStamp)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(QueryValidate, con);
                    /// SqlCommand cmd2 = new SqlCommand(QueryValidateTimeStamp, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

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

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");
                    cmd.Parameters.Add(ParamTimeStamp);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    //cmd2.ExecuteNonQuery();
                    con.Close();




                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void DeleteFromAppliedTable(int @RollNumber, String @DegreeTitle, String @Session)
        {
            String QueryValidate = "Delete from APPLIED_STUDENT where Roll_Number =  @RollNumber AND Degree_Title =  @DegreeTitle  AND Session =  @Session";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(QueryValidate, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

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

        public IEnumerable<Student> ListAppliedStudent()
        {

            String query = "Select * from APPLIED_STUDENT";
            List<Student> AppliedStudents = new List<Student>();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    //SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student students = new Student();
                        students.Name = rdr["Name"].ToString();
                        students.RollNumber = Convert.ToInt32(rdr["Roll_Number"]);
                        students.DegreeTitle = rdr["Degree_Title"].ToString();
                        students.Session = rdr["Session"].ToString();
                        students.Section = rdr["Section"].ToString();
                        students.Semester = Convert.ToInt32(rdr["Semester"]);
                        students.MorningEvening = rdr["Morning_Evening"].ToString();
                        students.TimeStamp = rdr["Time_Stamp"].ToString();
                        AppliedStudents.Add(students);
                    }
                    con.Close();
                    return AppliedStudents;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<Student> ListApprovedStudents()
        {
            String query = "Select * from STUDENT";
            List<Student> AppliedStudents = new List<Student>();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    //SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student students = new Student();
                        students.Name = rdr["Name"].ToString();
                        students.RollNumber = Convert.ToInt32(rdr["Roll_Number"]);
                        students.DegreeTitle = rdr["Degree_Title"].ToString();
                        students.Session = rdr["Session"].ToString();
                        students.Section = rdr["Section"].ToString();
                        students.Semester = Convert.ToInt32(rdr["Semester"]);
                        students.MorningEvening = rdr["Morning_Evening"].ToString();
                        students.TimeStamp = rdr["Time_Stamp"].ToString();
                        AppliedStudents.Add(students);
                    }
                    con.Close();
                    return AppliedStudents;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteFromStudentTable(int @RollNumber, String @DegreeTitle, String @Session)
        {
            String QueryValidate = "Delete from STUDENT where Roll_Number =  @RollNumber AND Degree_Title =  @DegreeTitle  AND Session =  @Session";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(QueryValidate, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

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

        public bool IsValid(int @RollNumber, string @DegreeTitle, string @Session, string @Password)
        {
            string query = "select Roll_Number, Degree_Title, Session, Password from STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session AND Password = @Password";
            string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                //SqlCommand cmd = new SqlCommand("Add_Student", con);
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = CommandType.StoredProcedure;

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

        public Student GetSpecificStudent(int @RollNumber, string @DegreeTitle, string @Session)
        {
            string query = "select * from STUDENT where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session";
            string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                //SqlCommand cmd = new SqlCommand("Add_Student", con);
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = CommandType.StoredProcedure;

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
                
                SqlDataReader rdr = cmd.ExecuteReader();
                Student student = new Student();
                while (rdr.Read())
                {

                    //students.Name = rdr["Name"].ToString();
                    student.RollNumber = Convert.ToInt32(rdr["Roll_Number"]);
                    student.DegreeTitle = rdr["Degree_Title"].ToString();
                    student.Session = rdr["Session"].ToString();
                    student.Section = rdr["Section"].ToString();
                    student.Semester = Convert.ToInt32(rdr["Semester"]);
                    student.MorningEvening = rdr["Morning_Evening"].ToString();
                }
                con.Close();
                return student;



            }
        }
    }
}







