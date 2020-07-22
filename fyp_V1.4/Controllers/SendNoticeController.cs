using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp_V1._4.Models;
using System.IO;

namespace fyp_V1._4.Controllers
{
    public class SendNoticeController : Controller
    {
        public ActionResult PopulateStudentNoticeView()
        {
            Student student = new Student();
            //List<Notice> NoticeList = new List<Notice>();

            student.RollNumber = Convert.ToInt32(Request.Cookies["StudentRollNumber"].Value);
            student.DegreeTitle = Request.Cookies["StudentDegreeTitle"].Value;
            student.Session = Request.Cookies["StudentSession"].Value;
            student.Section = Request.Cookies["StudentSection"].Value;
            student.Semester = Convert.ToInt32(Request.Cookies["StudentSemester"].Value);
            student.MorningEvening = Request.Cookies["StudentMorningEvening"].Value;
            NoticeDbLayer noticeDbLayer = new NoticeDbLayer();
            //NoticeList = noticeDbLayer.GetNoticeList(notice);
            return View(noticeDbLayer.GetNoticeList(student));
        }

        [HttpGet]
        public ActionResult DownloadNotice(string NoticePath)
        {
            string file = NoticePath;
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(file, contentType, Path.GetFileName(file));

            //return RedirectToAction("PopulateStudentNoticeView");
        }
    }
}