using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace fyp_V1._4.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(4, ErrorMessage = "Length must be 4", MinimumLength = 4)]
        public string EmployeeeId { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string AdminType { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string AddingEmployeeId { get; set; }

        public string timeStamp { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }
        
    }
}