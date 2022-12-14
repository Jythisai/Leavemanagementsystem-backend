using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_LMSapp1.Models
{
    public class LoginPage
    {
        
        
            [Key]
            public int UserId { get; set; }
            [Required(ErrorMessage = "Please enter employee id")]
            public string EmployeeId { get; set; }
            [Required(ErrorMessage = "Please enter password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        
    }

}

