using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class EmployeeGrade
    {
        public int EmployeeGradeId { get; set; }
        public int EmployeeId { get; set; }
        public int GradeId { get; set; }
        public string IsActive { get; set; }

        public virtual EmployeeMaster Employee { get; set; }
        public virtual GradeMaster Grade { get; set; }
    }
}
