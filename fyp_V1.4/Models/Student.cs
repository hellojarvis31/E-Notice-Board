using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class Student
    {
        [Required(ErrorMessage = "This is a required field")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public int RollNumber { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string DegreeTitle { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(9,ErrorMessage = "Session Must be In 2013-2017 format",MinimumLength = 9)]
        public string Session { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string Section { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [Range(1,8,ErrorMessage = "Semester Must be Between 1 and 8")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [StringLength(1,ErrorMessage ="M For Moring and E For Evening",MinimumLength = 1)]
        public string MorningEvening { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public String TimeStamp { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

    }
}