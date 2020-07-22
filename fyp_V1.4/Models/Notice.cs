using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class Notice
    {   
        [Required(ErrorMessage = "This is a required field")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string NoticeTitle { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(4, ErrorMessage = "Length must be 4", MinimumLength = 4)]
        public string EmployeeeId { get; set; }

        public string TimeStamp { get; set; }


        [Required(ErrorMessage = "This is a required field")]
        public int RollNumber { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string DegreeTitle { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(9, ErrorMessage = "Session Must be In 2013-2017 format", MinimumLength = 9)]
        public string Session { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string Section { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [Range(1, 8, ErrorMessage = "Semester Must be Between 1 and 8")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(1, ErrorMessage = "M For Moring and E For Evening", MinimumLength = 1)]
        public string MorningEvening { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string NoticePath { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string AllStudent { get; set; }


        //[Required, FileExtensions(Extensions = "csv", ErrorMessage = "Specify a CSV file")]
        public HttpPostedFileBase File { get; set; }
    }
}