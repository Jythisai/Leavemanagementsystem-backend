using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_LMSapp1.Models
{
    public class LeaveApplication
    {
        public int LeaveApplicationId { get; set; }
        public string NumberOfDays { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Status { get; set; }
        public string LeaveReason { get; set; }
        public string EmployeeId { get; set; }
        public string AppliedOn { get; set; }
    }
}
