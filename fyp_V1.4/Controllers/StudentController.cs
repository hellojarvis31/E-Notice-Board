using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp_V1._4.Models;
using System.Web.Security;

namespace fyp_V1._4.Controllers
{
    public class StudentController : Controller
    {
        
        [HttpGet]
        public ActionResult StudentMainMenu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentSignUp()
        {

            return View();
        }
        [HttpPost]
        public ActionResult StudentSignUp(FormCollection formcollection)
        {
            Student appliedstudent = new Student();
            StudentDbLayer studentDBLayer = new StudentDbLayer();

            if (ModelState.IsValid)
            {
                
                appliedstudent.Name = formcollection["Name"];
                appliedstudent.RollNumber = Convert.ToInt32(formcollection["RollNumber"]);
                appliedstudent.DegreeTitle = formcollection["DegreeTitle"];
                appliedstudent.Session = formcollection["Session"];
                appliedstudent.Section = formcollection["Section"];
                appliedstudent.Semester = Convert.ToInt32(formcollection["Semester"]);
                appliedstudent.MorningEvening = formcollection["MorningEvening"];
                appliedstudent.Password = formcollection["Password"];
                }

            try
            {
                studentDBLayer.AddStudent(appliedstudent);

               

                ViewBag.SuccessMessage = "Now wait for admin approval and then login";
                return View();
            }

            catch
            {
                ViewBag.ErrorMessage = "Invalid Section or Session..!! Try Again or contact Admin";
                return View();
            }
        }

        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(Student student)
        {
            StudentDbLayer studentDbLayre = new StudentDbLayer();
            if (studentDbLayre.IsValid(student.RollNumber, student.DegreeTitle, student.Session,student.Password))
            {
                Student studentForCookie = new Student();

                studentForCookie = studentDbLayre.GetSpecificStudent(student.RollNumber, student.DegreeTitle, student.Session);

                Response.Cookies["StudentRollNumber"].Value = studentForCookie.RollNumber.ToString();
                Response.Cookies["StudentRollNumber"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["StudentDegreeTitle"].Value = studentForCookie.DegreeTitle;
                Response.Cookies["StudentDegreeTitle"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["StudentSession"].Value = studentForCookie.Session;
                Response.Cookies["StudentSession"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["StudentSection"].Value = studentForCookie.Section;
                Response.Cookies["StudentSection"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["StudentSemester"].Value = studentForCookie.Semester.ToString();
                Response.Cookies["StudentSemester"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["StudentMorningEvening"].Value = studentForCookie.MorningEvening;
                Response.Cookies["StudentMorningEvening"].Expires = DateTime.Now.AddDays(1);

                return RedirectToAction("PopulateStudentNoticeView", "SendNotice");
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect!");
            }

            return View();
          
        }

        public ActionResult StudentLogout()
        {
            Response.Cookies["StudentRollNumber"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["StudentDegreeTitle"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["StudentSession"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["StudentSection"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["StudentSemester"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["StudentMorningEvening"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("StudentLogin", "Student");
        }
    }
}