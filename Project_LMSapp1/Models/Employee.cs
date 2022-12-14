using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_LMSapp1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your mobile number")]
        [Display(Name = "Mobile number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please enter your email id")]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        public string DateJoined { get; set; }
        [Required(ErrorMessage = "Please enter your designation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter your Manager name")]
        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }
        public string Salary { get; set; }
        [Required(ErrorMessage = "Please enter user name")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
