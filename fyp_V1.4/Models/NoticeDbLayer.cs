using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class NoticeDbLayer
    {
        public void AllStudentsNotice(Notice notice)
        {

            string querry = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, All_Student, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @AllStudent, @NoticePath)";
            
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Add_Student", con);
                    SqlCommand cmd = new SqlCommand(querry, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamAllStudent = new SqlParameter();
                    ParamAllStudent.ParameterName = "@AllStudent";
                    ParamAllStudent.Value = notice.AllStudent;
                    cmd.Parameters.Add(ParamAllStudent);

                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch(Exception ex)
            {
                throw ex;
            }
         }   

        public void SessionWiseNotice(Notice notice)
        {
            string query = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, Session, Degree_Title, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @Session, @DegreeTitle, @NoticePath)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamSession = new SqlParameter();
                    ParamSession.ParameterName = "@Session";
                    ParamSession.Value = notice.Session;
                    cmd.Parameters.Add(ParamSession);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@DegreeTitle";
                    ParamDegreeTitle.Value = notice.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);

                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SemesterWiseNotice(Notice notice)
        {
            string query = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, Semester, Degree_title, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @Semester, @DegreeTitle, @NoticePath)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamSemester = new SqlParameter();
                    ParamSemester.ParameterName = "@Semester";
                    ParamSemester.Value = notice.Semester;
                    cmd.Parameters.Add(ParamSemester);

                    SqlParameter ParamDegreetitle = new SqlParameter();
                    ParamDegreetitle.ParameterName = "@DegreeTitle";
                    ParamDegreetitle.Value = notice.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreetitle);

                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SectionWiseNotice(Notice notice)
        {
            string query = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, Semester, Section, Degree_Title, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @Semester, @Section, @DegreeTitle, @NoticePath)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamSemester = new SqlParameter();
                    ParamSemester.ParameterName = "@Semester";
                    ParamSemester.Value = notice.Semester;
                    cmd.Parameters.Add(ParamSemester);

                    SqlParameter ParamSection = new SqlParameter();
                    ParamSection.ParameterName = "@Section";
                    ParamSection.Value = notice.Section;
                    cmd.Parameters.Add(ParamSection);

                    SqlParameter ParamDegreetitle = new SqlParameter();
                    ParamDegreetitle.ParameterName = "@DegreeTitle";
                    ParamDegreetitle.Value = notice.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreetitle);

                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MorningEveningWiseNotice(Notice notice)
        {
            string query = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, Morning_Evening, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @MorningEvening, @NoticePath)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamMorningEvening = new SqlParameter();
                    ParamMorningEvening.ParameterName = "@MorningEvening";
                    ParamMorningEvening.Value = notice.MorningEvening;
                    cmd.Parameters.Add(ParamMorningEvening);

                    
                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RollNumberWiseNotice(Notice notice)
        {
            string query = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, Roll_Number, Degree_Title, Session, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @RollNumber, @DegreeTitle, @Session, @NoticePath)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);

                    SqlParameter ParamRollNumber = new SqlParameter();
                    ParamRollNumber.ParameterName = "@RollNumber";
                    ParamRollNumber.Value = notice.RollNumber;
                    cmd.Parameters.Add(ParamRollNumber);

                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@Degreetitle";
                    ParamDegreeTitle.Value = notice.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);

                    SqlParameter ParamSession = new SqlParameter();
                    ParamSession.ParameterName = "@Session";
                    ParamSession.Value = notice.Session;
                    cmd.Parameters.Add(ParamSession);

                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CourseWiseNotice(Notice notice)
        {
            string query = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, Course_Code, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @CourseCode, @NoticePath)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);
                    
                    SqlParameter ParamCourseCode = new SqlParameter();
                    ParamCourseCode.ParameterName = "@CourseCode";
                    ParamCourseCode.Value = notice.CourseCode;
                    cmd.Parameters.Add(ParamCourseCode);

                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DegreeWiseNotice(Notice notice)
        {
            string query = "insert into NOTICE(Notice_Title,Employee_Id,Time_Stamp, Degree_Title, Notice_Path) values(@NoticeTitle, @EmployeeId, @TimeStamp, @DegreeTitle, @NoticePath)";

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlParameter ParamNoticeTitle = new SqlParameter();
                    ParamNoticeTitle.ParameterName = "@NoticeTitle";
                    ParamNoticeTitle.Value = notice.NoticeTitle;
                    cmd.Parameters.Add(ParamNoticeTitle);

                    SqlParameter ParamEmployeeId = new SqlParameter();
                    ParamEmployeeId.ParameterName = "@EmployeeId";
                    ParamEmployeeId.Value = notice.EmployeeeId.ToString();
                    cmd.Parameters.Add(ParamEmployeeId);

                    SqlParameter ParamTimeStamp = new SqlParameter();
                    ParamTimeStamp.ParameterName = "@TimeStamp";
                    ParamTimeStamp.Value = notice.TimeStamp;
                    cmd.Parameters.Add(ParamTimeStamp);
                    
                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@Degreetitle";
                    ParamDegreeTitle.Value = notice.DegreeTitle;
                    cmd.Parameters.Add(ParamDegreeTitle);

                    
                    SqlParameter ParamNoticePath = new SqlParameter();
                    ParamNoticePath.ParameterName = "@NoticePath";
                    ParamNoticePath.Value = notice.NoticePath;
                    cmd.Parameters.Add(ParamNoticePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Notice> ListAllNotice()
        {
            string query = "Select * from Notice";
            List<Notice> NoticeList = new List<Notice>();
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
                        Notice notice = new Notice();
                        notice.NoticeTitle = rdr["Notice_Title"].ToString();
                        notice.TimeStamp = rdr["Time_Stamp"].ToString();
                        notice.EmployeeeId = rdr["Employee_Id"].ToString();
                        if (rdr["Degree_Title"] == DBNull.Value)
                        {
                            notice.DegreeTitle = "None";
                        }
                        else
                        {
                            notice.DegreeTitle = rdr["Degree_Title"].ToString();
                        }

                        if (rdr["Morning_Evening"] == DBNull.Value)
                        {
                            notice.MorningEvening = "None";
                        }
                        else
                        {
                            notice.MorningEvening = rdr["Morning_Evening"].ToString();
                        }

                        if (rdr["Roll_Number"] == DBNull.Value)
                        {
                            notice.RollNumber = 0;
                        }
                        else
                        {
                            notice.RollNumber = Convert.ToInt32(rdr["Roll_Number"]);
                        }
                        if (rdr["Session"] == DBNull.Value)
                        {
                            notice.Session = "None";
                        }
                        else
                        {
                            notice.Session = rdr["Session"].ToString();
                        }
                        if (rdr["Section"] == DBNull.Value)
                        {
                            notice.Section = "None";
                        }
                        else
                        {
                            notice.Section = rdr["Section"].ToString();
                        }
                        if (rdr["Semester"] == DBNull.Value)
                        {
                            notice.Semester = 0;
                        }
                        else
                        {
                            notice.Semester = Convert.ToInt32(rdr["Semester"]);
                        }

                        if (rdr["Course_Code"] == DBNull.Value)
                        {
                            notice.CourseCode = "None";
                        }
                        else
                        {
                            notice.CourseCode = rdr["Course_Code"].ToString();
                        }
                        if (rdr["All_Student"] == DBNull.Value)
                        {
                            notice.AllStudent = "None";
                        }
                        else
                        {
                            notice.AllStudent = rdr["All_Student"].ToString();
                        }
                        
                        //notice.NoticePath = rdr["Notice_Path"].ToString();
                        NoticeList.Add(notice);
                    }
                    con.Close();
                    return NoticeList;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Notice> GetNoticeList(Student student)
        {
            string AllStudentWiseNoticeQuery = "select Notice_Title, Time_Stamp, Notice_Path from NOTICE where All_Student = 'yes'";
            
            List<Notice> NoticeList = new List<Notice>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(AllStudentWiseNoticeQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr["Notice_Title"].ToString();
                        Tempnotice.TimeStamp = rdr["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }

                    string RollNumberWiseNoticeQuery = "select Notice_Title, Time_Stamp, Notice_Path from NOTICE where Roll_Number = @RollNumber AND Degree_Title = @DegreeTitle AND Session = @Session";

                    SqlCommand cmd2 = new SqlCommand(RollNumberWiseNoticeQuery, con);
                    //con.Open();
                    SqlParameter ParamRollNumber = new SqlParameter();
                    ParamRollNumber.ParameterName = "@RollNumber";
                    ParamRollNumber.Value = student.RollNumber;
                    cmd2.Parameters.Add(ParamRollNumber);

                    SqlParameter Param_DegreeTitle = new SqlParameter();
                    Param_DegreeTitle.ParameterName = "@DegreeTitle";
                    Param_DegreeTitle.Value = student.DegreeTitle;
                    cmd2.Parameters.Add(Param_DegreeTitle);

                    SqlParameter Param_Session = new SqlParameter();
                    Param_Session.ParameterName = "@Session";
                    Param_Session.Value = student.Session;
                    cmd2.Parameters.Add(Param_Session);

                    SqlDataReader rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr2["Notice_Title"].ToString();
                        Tempnotice.TimeStamp = rdr2["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr2["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }

                    string DegreeWiseWiseNoticeQuery = "select * from NOTICE where Degree_Title = @DegreeTitle AND Session is Null AND Section is NUll AND Roll_Number is NULL AND Semester is NULL AND Morning_Evening is Null AND Course_Code is NULL";

                    SqlCommand cmd3 = new SqlCommand(DegreeWiseWiseNoticeQuery, con);
                    //con.Open();
                    SqlParameter ParamDegreeTitle = new SqlParameter();
                    ParamDegreeTitle.ParameterName = "@DegreeTitle";
                    ParamDegreeTitle.Value = student.DegreeTitle;
                    cmd3.Parameters.Add(ParamDegreeTitle);

                    SqlDataReader rdr3 = cmd3.ExecuteReader();

                    while (rdr3.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr3["Notice_Title"].ToString();
                        Tempnotice.TimeStamp = rdr3["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr3["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }

                    string SessionWiseWiseNoticeQuery = "select Notice_Title, Time_Stamp, Notice_Path from NOTICE where Session = @Session AND Degree_Title = @DegreeTitle AND Semester is null AND Morning_Evening is NUll AND Course_Code is Null and Section is NULL and Roll_Number is Null";

                    SqlCommand cmd4 = new SqlCommand(SessionWiseWiseNoticeQuery, con);
                    //con.Open();
                    SqlParameter ParamSession = new SqlParameter();
                    ParamSession.ParameterName = "@Session";
                    ParamSession.Value = student.Session;
                    cmd4.Parameters.Add(ParamSession);

                    SqlParameter Param__DegreeTitle = new SqlParameter();
                    Param__DegreeTitle.ParameterName = "@DegreeTitle";
                    Param__DegreeTitle.Value = student.DegreeTitle;
                    cmd4.Parameters.Add(Param__DegreeTitle);

                    SqlDataReader rdr4 = cmd4.ExecuteReader();

                    while (rdr4.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr4["Notice_Title"].ToString();
                        Tempnotice.TimeStamp = rdr4["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr4["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }

                    string SectionWiseWiseNoticeQuery = "select Notice_Title, Time_Stamp, Notice_Path from NOTICE where Section = @Section AND Degree_Title = @DegreeTitle AND Semester = @Semester AND Morning_Evening is NUll AND Course_Code is Null and Session is NULL and Roll_Number is Null";

                    SqlCommand cmd5 = new SqlCommand(SectionWiseWiseNoticeQuery, con);
                    //con.Open();
                    SqlParameter ParamSection = new SqlParameter();
                    ParamSection.ParameterName = "@Section";
                    ParamSection.Value = student.Section;
                    cmd5.Parameters.Add(ParamSection);

                    SqlParameter Param___DegreeTitle = new SqlParameter();
                    Param___DegreeTitle.ParameterName = "@DegreeTitle";
                    Param___DegreeTitle.Value = student.DegreeTitle;
                    cmd5.Parameters.Add(Param___DegreeTitle);

                    SqlParameter ParamSemester= new SqlParameter();
                    ParamSemester.ParameterName = "@Semester";
                    ParamSemester.Value = student.Semester;
                    cmd5.Parameters.Add(ParamSemester);

                    SqlDataReader rdr5 = cmd5.ExecuteReader();

                    while (rdr5.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr5["Notice_Title"].ToString();
                        Tempnotice.TimeStamp = rdr5["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr5["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }

                    string SemesterWiseWiseNoticeQuery = "select Notice_Title, Time_Stamp, Notice_Path from NOTICE where Semester = @Semester AND Degree_Title = @DegreeTitle AND Morning_Evening is Null AND Course_Code is null and Section is null and Roll_Number is null and Session is null";

                    SqlCommand cmd6 = new SqlCommand(SemesterWiseWiseNoticeQuery, con);
                    //con.Open();
                    SqlParameter Param_Semester = new SqlParameter();
                    Param_Semester.ParameterName = "@Semester";
                    Param_Semester.Value = student.Semester;
                    cmd6.Parameters.Add(Param_Semester);

                    SqlParameter Param____DegreeTitle = new SqlParameter();
                    Param____DegreeTitle.ParameterName = "@DegreeTitle";
                    Param____DegreeTitle.Value = student.DegreeTitle;
                    cmd6.Parameters.Add(Param____DegreeTitle);

                    SqlDataReader rdr6 = cmd6.ExecuteReader();

                    while (rdr6.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr6["Notice_Title"].ToString();
                        Tempnotice.TimeStamp = rdr6["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr6["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }

                    string MorningWiseWiseNoticeQuery = "select Notice_Title, Time_Stamp, Notice_Path from NOTICE where Morning_Evening = @MorningEvening";

                    SqlCommand cmd7 = new SqlCommand(MorningWiseWiseNoticeQuery, con);
                    //con.Open();
                    SqlParameter ParamMorningEvening = new SqlParameter();
                    ParamMorningEvening.ParameterName = "@MorningEvening";
                    ParamMorningEvening.Value = student.MorningEvening;
                    cmd7.Parameters.Add(ParamMorningEvening);

                    SqlDataReader rdr7 = cmd7.ExecuteReader();

                    while (rdr7.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr7["Notice_Title"].ToString();
                        Tempnotice.TimeStamp = rdr7["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr7["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }

                    string CourseWiseNoticeQuery = "select Notice_Title, Time_stamp, Notice_Path from NOTICE inner join Course on COURSE.Course_Code = Notice.Course_Code inner join STUDENT_COURSE_REGISTRATION on STUDENT_COURSE_REGISTRATION.Course_Code = COURSE.Course_Code where STUDENT_COURSE_REGISTRATION.Roll_Number = @RollNumber AND STUDENT_COURSE_REGISTRATION.Degree_Title = @DegreeTitle AND STUDENT_COURSE_REGISTRATION.Session = @Session";

                    SqlCommand cmd8 = new SqlCommand(CourseWiseNoticeQuery, con);
                    //con.Open();
                    SqlParameter Param_RollNumber = new SqlParameter();
                    Param_RollNumber.ParameterName = "@RollNumber";
                    Param_RollNumber.Value = student.RollNumber;
                    cmd8.Parameters.Add(Param_RollNumber);

                    SqlParameter Param_____DegreeTitle = new SqlParameter();
                    Param_____DegreeTitle.ParameterName = "@DegreeTitle";
                    Param_____DegreeTitle.Value = student.DegreeTitle;
                    cmd8.Parameters.Add(Param_____DegreeTitle);

                    SqlParameter Param__Session = new SqlParameter();
                    Param__Session.ParameterName = "@Session";
                    Param__Session.Value = student.Session;
                    cmd8.Parameters.Add(Param__Session);

                    SqlDataReader rdr8 = cmd8.ExecuteReader();

                    while (rdr8.Read())
                    {
                        Notice Tempnotice = new Notice();
                        Tempnotice.NoticeTitle = rdr8["Notice_Title"].ToString();

                        //Tempnotice.TimeStamp = DateTime.ParseExact(rdr8["Time_Stamp"].ToString(), "MMM dd yyyy/ddd/hh:mm", System.Globalization.CultureInfo.InvariantCulture);

                        Tempnotice.TimeStamp = rdr8["Time_Stamp"].ToString();
                        Tempnotice.NoticePath = rdr8["Notice_Path"].ToString();
                        NoticeList.Add(Tempnotice);
                    }


                    con.Close();

                    NoticeList = NoticeList.OrderByDescending(o => o.TimeStamp).ToList();

                    //NoticeList.OrderBy(,)
                    //NoticeList.Sort(delegate (Notice x, Notice y)
                    //{
                    //    return DateTime.ParseExact(x.TimeStamp, "MMM dd yyyy/ddd/hh:mm", System.Globalization.CultureInfo.InvariantCulture).CompareTo(DateTime.ParseExact(y.TimeStamp, "MMM dd yyyy/ddd/hh:mm", System.Globalization.CultureInfo.InvariantCulture));
                    //});
                    return NoticeList.Distinct().ToList();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        
    }

   
}