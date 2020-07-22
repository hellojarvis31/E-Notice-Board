using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class StudentCourseRegistration
    {
        [Required(ErrorMessage = "This is a required field")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public int RollNumber { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string DegreeTitle { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(9, ErrorMessage = "Session Must be In 2013-2017 format", MinimumLength = 9)]
        public string Session { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string RegisterType { get; set; }
    }
}