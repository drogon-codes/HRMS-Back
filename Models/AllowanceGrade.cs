using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class AllowanceGrade
    {
        public int AllowanceGradeId { get; set; }
        public int AllowanceId { get; set; }
        public int GradeId { get; set; }
        public double AllowanceRate { get; set; }

        public virtual AllowanceMaster Allowance { get; set; }
        public virtual GradeMaster Grade { get; set; }
    }
}
