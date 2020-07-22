using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp_V1._4.Models;
using System.Web.Security;
using System.IO;

namespace fyp_V1._4.Controllers
{
         

    public class AdminController : Controller
    {
        //bool IsLogin = false; 
        // GET: Admin
        public ActionResult AdminMainMenu()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        [HttpGet]
        public ActionResult AppliedStudentList()
        {
            try
            {

                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    StudentDbLayer studentDBLayer = new StudentDbLayer();

                    return View(studentDBLayer.ListAppliedStudent());
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        [HttpGet]
        public ActionResult ValidateStudent(int RollNumber, String DegreeTitle, String Session)
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    StudentDbLayer studentDBLayer = new StudentDbLayer();
                    studentDBLayer.validateStudent(RollNumber, DegreeTitle, Session);
                    studentDBLayer.DeleteFromAppliedTable(RollNumber, DegreeTitle, Session);
                    return RedirectToAction("AppliedStudentList");
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }

            
            //return View();
        }

        [HttpGet]
        public ActionResult DeleteFromAppliedTable(int RollNumber, String DegreeTitle, String Session)
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    StudentDbLayer studentDBLayer = new StudentDbLayer();
                    studentDBLayer.DeleteFromAppliedTable(RollNumber, DegreeTitle, Session);
                    return RedirectToAction("AppliedStudentList");
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            

        }

        [HttpGet]
        public ActionResult ApprovedStudentsList()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    StudentDbLayer studentDBLayer = new StudentDbLayer();

                    return View(studentDBLayer.ListApprovedStudents());
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        [HttpGet]
        public ActionResult DeleteFromStudentTable(int RollNumber, String DegreeTitle, String Session)
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    StudentDbLayer studentDBLayer = new StudentDbLayer();
                    studentDBLayer.DeleteFromStudentTable(RollNumber, DegreeTitle, Session);
                    return RedirectToAction("ApprovedStudentsList");

                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin user)
        {
            AdminDbLayer adminDbLayer = new AdminDbLayer();
            if (adminDbLayer.IsValid(user.EmployeeeId, user.Password))
                {
                    Response.Cookies["EmployeeId"].Value = user.EmployeeeId.ToString();
                    Response.Cookies["EmployeeId"].Expires = DateTime.Now.AddDays(1);
                    //IsLogin = true;

                if (adminDbLayer.IsMain(user.EmployeeeId))
                {
                    Response.Cookies["AdminType"].Value = "Main";
                    Response.Cookies["AdminType"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Response.Cookies["AdminType"].Value = "Sub";
                    Response.Cookies["AdminType"].Expires = DateTime.Now.AddDays(1);
                }

                return RedirectToAction("NoticeMenu", "Admin");
                }

            else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            
            return View();
         }

        [HttpGet]
        public ActionResult Logout()
        {
            Response.Cookies["EmployeeId"].Expires= DateTime.Now.AddDays(-1);
            Response.Cookies["AdminType"].Expires = DateTime.Now.AddDays(-1);
            //IsLogin = false;
            return RedirectToAction("Login", "Admin");
        }

        [HttpGet]
        public ActionResult StudentCourseRegister()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult StudentCourseRegister(FormCollection formCollection)
        {
            try
            {
                StudentCourseRegistration studentCourseRegistration = new StudentCourseRegistration();
                studentCourseRegistration.CourseCode = formCollection["CourseCode"];
                studentCourseRegistration.RollNumber = Convert.ToInt32(formCollection["RollNumber"]);
                studentCourseRegistration.DegreeTitle = formCollection["DegreeTitle"];
                studentCourseRegistration.Session = formCollection["Session"];
                studentCourseRegistration.RegisterType = formCollection["RegisterType"];

                StudentCourseRegistrationDbLayer studentCourseregistrationDbLayer = new StudentCourseRegistrationDbLayer();
                studentCourseregistrationDbLayer.RegisterCourse(studentCourseRegistration.CourseCode, studentCourseRegistration.RollNumber, studentCourseRegistration.DegreeTitle, studentCourseRegistration.Session, studentCourseRegistration.RegisterType);
                ViewBag.SuccessMessage = "Student Registered with Course Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed..!!<br/> Course Code or Student Data is Incorrect..!!";
                return View();
            }
        }
        [HttpGet]
        public ActionResult NoticeMenu()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }

            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult AllStudentsNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AllStudentsNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            var allowedExtensions = new[] { ".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();
            try
            { 
                if (file.ContentLength > 0 )
                {
                    if (allowedExtensions.Contains(checkextension))
                    {
                        
                            string _FileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                            //string _path = Path.Combine(Server.MapPath("../../Publish/UploadedFiles"), _FileName);
                            file.SaveAs(_path);



                            Notice notice = new Notice();
                            notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                            notice.NoticeTitle = formCollection["NoticeTitle"];
                            notice.NoticePath = _path;
                            notice.AllStudent = "Yes";
                            notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                            NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                            noticeDbLayer.AllStudentsNotice(notice);

                            ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                            return View();
                        
                    }

                    else
                    {
                        ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                        return View();
                    }
            }

            else
            {
                ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                return View();
            }


        }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Invalid Data..!! Try Again";
                return View();
                throw ex;

            }
            //return View();
}
        
        public ActionResult SessionWiseNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult SessionWiseNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            
            var allowedExtensions = new[] {".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();
            

            try
            {
                if (file.ContentLength > 0 && allowedExtensions.Contains(checkextension))
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    Notice notice = new Notice();
                    notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                    notice.NoticeTitle = formCollection["NoticeTitle"];
                    notice.NoticePath = _path;
                    notice.Session = formCollection["Session"];
                    notice.DegreeTitle = formCollection["DegreeTitle"];
                    notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    noticeDbLayer.SessionWiseNotice(notice);


                    ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.ErrorMessage = " Invalid Session..!! Try Again";
                return View();
            }
            
        }

        public ActionResult SemesterWiseNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult SemesterWiseNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            var allowedExtensions = new[] { ".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();


            try
            {
                if (file.ContentLength > 0 && allowedExtensions.Contains(checkextension))
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    Notice notice = new Notice();
                    notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                    notice.NoticeTitle = formCollection["NoticeTitle"];
                    notice.NoticePath = _path;
                    notice.Semester = Convert.ToInt32(formCollection["Semester"]);
                    notice.DegreeTitle = formCollection["DegreeTitle"];
                    notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    noticeDbLayer.SemesterWiseNotice(notice);


                    ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.ErrorMessage = " Invalid Section..!! Try Again";
                return View();
            }

        }


        public ActionResult SectionWiseNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult SectionWiseNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            var allowedExtensions = new[] { ".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();


            try
            {
                if (file.ContentLength > 0 && allowedExtensions.Contains(checkextension))
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    Notice notice = new Notice();
                    notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                    notice.NoticeTitle = formCollection["NoticeTitle"];
                    notice.NoticePath = _path;
                    notice.Semester = Convert.ToInt32(formCollection["Semester"]);
                    notice.Section = formCollection["Section"];
                    notice.DegreeTitle = formCollection["DegreeTitle"];
                    notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    noticeDbLayer.SectionWiseNotice(notice);


                    ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Invalid Section..! Try Again";
                return View();
            }
        }

        public ActionResult MorningEveningWiseNotice()
        {
            try
            {

                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }

            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult MorningEveningWiseNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            var allowedExtensions = new[] { ".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();


            try
            {
                if (file.ContentLength > 0 && allowedExtensions.Contains(checkextension))
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    Notice notice = new Notice();
                    notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                    notice.NoticeTitle = formCollection["NoticeTitle"];
                    notice.NoticePath = _path;
                    notice.MorningEvening = formCollection["MorningEvening"];
                    notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    noticeDbLayer.MorningEveningWiseNotice(notice);


                    ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.ErrorMessage = " Invalid Data..!! Try Again";
                return View();
            }
        }

        public ActionResult RollNumberWiseNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult RollNumberWiseNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            var allowedExtensions = new[] { ".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();


            try
            {
                if (file.ContentLength > 0 && allowedExtensions.Contains(checkextension))
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    Notice notice = new Notice();
                    notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                    notice.NoticeTitle = formCollection["NoticeTitle"];
                    notice.NoticePath = _path;
                    notice.RollNumber = Convert.ToInt32(formCollection["RollNumber"]);
                    notice.DegreeTitle = formCollection["DegreeTitle"];
                    notice.Session = formCollection["Session"]; 
                    notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    noticeDbLayer.RollNumberWiseNotice(notice);


                    ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Invalid Roll Number or Session..!! Try Again";
                return View();
            }
        }

        public ActionResult CourseWiseNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CourseWiseNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            var allowedExtensions = new[] { ".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();


            try
            {
                if (file.ContentLength > 0 && allowedExtensions.Contains(checkextension))
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    Notice notice = new Notice();
                    notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                    notice.NoticeTitle = formCollection["NoticeTitle"];
                    notice.NoticePath = _path;
                    
                    notice.CourseCode = formCollection["CourseCode"];
                    notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    noticeDbLayer.CourseWiseNotice(notice);


                    ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.ErrorMessage = " Invalid Course Code..!! Try Again";
                return View();
            }
        }

        public ActionResult DegreeWiseNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult DegreeWiseNotice(HttpPostedFileBase file, FormCollection formCollection)
        {
            var allowedExtensions = new[] { ".jpeg", ".png", ".docx", ".doc", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".zip", ".rar" };
            var checkextension = Path.GetExtension(file.FileName).ToLower();


            try
            {
                if (file.ContentLength > 0 && allowedExtensions.Contains(checkextension))
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    Notice notice = new Notice();
                    notice.EmployeeeId = Request.Cookies["EmployeeId"].Value.ToString();
                    notice.NoticeTitle = formCollection["NoticeTitle"];
                    notice.NoticePath = _path;

                    notice.DegreeTitle = formCollection["DegreeTitle"];
                    notice.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");

                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    noticeDbLayer.DegreeWiseNotice(notice);


                    ViewBag.SuccessMessage = "File Uploaded Successfully!!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = " File has invalid extension File upload failed!!";
                    return View();
                }
            }
            catch
            {
                ViewBag.ErrorMessage = " Invalid Degree Title..!! Try Again";
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AddAdmin(FormCollection formCollection)
        {
            Admin admin = new Admin();
            admin.EmployeeeId = formCollection["EmployeeeId"];
            admin.Name = formCollection["Name"];
            admin.Designation = formCollection["Designation"];
            admin.Password = formCollection["Password"];
            admin.AdminType = formCollection["AdminType"];
            admin.AddingEmployeeId = Request.Cookies["EmployeeId"].Value.ToString();
            AdminDbLayer adminDbLayer = new AdminDbLayer();

            if (Request.Cookies["AdminType"].Value.ToString() == "Sub")
            {
                ViewBag.ErrorMessage = "You are not authorized to add more Admins!!";
                return View();
            }

            else
            {
                try
                {
                    adminDbLayer.AddAdmin(admin);
                    ViewBag.SuccessMessage = "Admin Added Successfully!!";
                    return View();
                }

                catch
                {
                    ViewBag.ErrorMessage = "Failed..! <br/> This Admin Already Exists";
                    return View();
                    //throw ex;

                }
             
            }
            

            
        }

        public ActionResult ListAllAdmin()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    AdminDbLayer adminDbLayer = new AdminDbLayer();
                    return View(adminDbLayer.ListAllAdmin());
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        public ActionResult AddSession()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AddSession(FormCollection formCollection)
        {
            if (Request.Cookies["AdminType"].Value.ToString() == "Sub")
            {
                ViewBag.ErrorMessage = "You are not authorized to add more Sessions!!";
                return View();
            }
            else
            {
                Session session = new Session();
                session.DegreeTitle = formCollection["DegreeTitle"].ToString();
                session.DegreeSession = formCollection["DegreeSession"].ToString();
                session.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");
                session.AddingEmployeeId = Request.Cookies["EmployeeId"].Value.ToString();
                SessionDbLayer sessionDbLayer = new SessionDbLayer();
                try
                {

                    sessionDbLayer.AddSession(session);
                    ViewBag.SuccessMessage = "Session Added Successfully!!";
                    return View();
                }
                catch
                {
                    ViewBag.ErrorMessage = "Invalid Session..!! <br/> This Session Allready Exists";
                    return View();
                }
            }
        }

        public ActionResult ListAllSession()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    SessionDbLayer sessionDbLayer = new SessionDbLayer();
                    return View(sessionDbLayer.ListAllSession());
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        public ActionResult AddSection()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AddSection(FormCollection formCollection)
        {
            if (Request.Cookies["AdminType"].Value.ToString() == "Sub")
            {
                ViewBag.ErrorMessage = "You are not authorized to add more Sections!!";
                return View();
            }

            else
            {
                Section section = new Section();
                section.DegreeTitle = formCollection["DegreeTitle"].ToString();
                section.DegreeSection = formCollection["DegreeSection"].ToString();
                section.TimeStamp = DateTime.Now.ToString("MMM dd yyyy/ddd/hh:mm");
                section.AddingEmployeeId = Request.Cookies["EmployeeId"].Value.ToString();
                SectionDbLayer sectionDblayer = new SectionDbLayer();
                try
                {

                    sectionDblayer.AddSection(section);
                    ViewBag.SuccessMessage = "Section Added Successfully!!";
                    return View();
                }
                catch
                {
                    ViewBag.ErrorMessage = "Invalid Section..!! <br/>This Section Allready Exists";
                    return View();
                }
            }
            
        }

        public ActionResult ListAllSection()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    SectionDbLayer sectionDbLayer = new SectionDbLayer();
                    return View(sectionDbLayer.ListAllSection());
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        public ActionResult ListAllNotice()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
                    return View(noticeDbLayer.ListAllNotice());
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        public ActionResult DeleteSession(string Session)
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    SessionDbLayer sessionDbLayer = new SessionDbLayer();
                    if (Request.Cookies["AdminType"].Value.ToString().Equals("Main"))
                    {
                        sessionDbLayer.DeleteSession(Session);
                        return RedirectToAction("ListAllSession");

                    }
                    else
                    {
                        //TempData["DeleteValidationMessage"] = "You are Not Authorized to Delete a Session";
                        return RedirectToAction("ListAllSession");
                    }

                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
           

        }

        public ActionResult DeleteSection(string section, string DegreeTitle)
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    SectionDbLayer sectionDblayer = new SectionDbLayer();
                    if (Request.Cookies["AdminType"].Value.ToString().Equals("Main"))
                    {
                        sectionDblayer.DeleteSection(section, DegreeTitle);
                        return RedirectToAction("ListAllSection");

                    }
                    else
                    {
                        //TempData["DeleteValidationMessage"] = "You are Not Authorized to Delete a Session";
                        return RedirectToAction("ListAllSection");
                    }
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
            


        }

        public ActionResult DeleteAdmin(string EmployeeId)
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    AdminDbLayer adminDbLayer = new AdminDbLayer();
                    if (Request.Cookies["AdminType"].Value.ToString().Equals("Main"))
                    {
                        adminDbLayer.DeleteAdmin(EmployeeId);
                        return RedirectToAction("ListAllAdmin");
                    }
                    else
                    {
                        return RedirectToAction("ListAllAdmin");
                    }
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
           
        }

        public ActionResult ListStudentCourseRegistration()
        {
            try
            {
                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    StudentCourseRegistrationDbLayer studentCourseRegistrationDbLayer = new StudentCourseRegistrationDbLayer();
                    return View(studentCourseRegistrationDbLayer.ListStudentCourseRegistration());
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }

            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
       }
            

        public ActionResult DeleteStudentCourseRegistration(string CourseCode, int RollNumber, string DegreeTitle, string Session)
        {
            try
            {

                if (Request.Cookies["AdminType"].Value.ToString() != null)
                {
                    StudentCourseRegistrationDbLayer studentCourseRegistrationDbLayer = new StudentCourseRegistrationDbLayer();
                    studentCourseRegistrationDbLayer.DeleteStudentCourseRegistration(CourseCode, RollNumber, DegreeTitle, Session);
                    return RedirectToAction("ListStudentCourseRegistration");
                }

                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Admin");
            }
           
        }

        public ActionResult AboutProduct()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }

}
