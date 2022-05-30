using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class LeaveMaster
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Reason { get; set; }
        public string IsApproved { get; set; }

        public virtual EmployeeMaster Employee { get; set; }
    }
}
