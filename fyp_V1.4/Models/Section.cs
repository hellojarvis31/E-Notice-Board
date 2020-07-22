using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp_V1._4.Models
{
    public class Section
    {
        [Required(ErrorMessage = "This is a required field")]
        public string DegreeTitle { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string DegreeSection { get; set; }

        public string TimeStamp { get; set; }

        public string AddingEmployeeId { get; set; }
    }
}