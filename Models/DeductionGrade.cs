using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class DeductionGrade
    {
        public int DeductionGradeId { get; set; }
        public int DeductionId { get; set; }
        public int GradeId { get; set; }
        public double DeductionRate { get; set; }

        public virtual DeductionMaster Deduction { get; set; }
        public virtual GradeMaster Grade { get; set; }
    }
}
