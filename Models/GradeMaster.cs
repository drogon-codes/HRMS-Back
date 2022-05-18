using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class GradeMaster
    {
        public GradeMaster()
        {
            AllowanceGrade = new HashSet<AllowanceGrade>();
            DeductionGrade = new HashSet<DeductionGrade>();
            DesignationGrade = new HashSet<DesignationGrade>();
            EmployeeGrade = new HashSet<EmployeeGrade>();
            PromotionMaster = new HashSet<PromotionMaster>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string ModeOfSalary { get; set; }
        public double? WagePerHour { get; set; }
        public double? DailySalary { get; set; }

        public virtual ICollection<AllowanceGrade> AllowanceGrade { get; set; }
        public virtual ICollection<DeductionGrade> DeductionGrade { get; set; }
        public virtual ICollection<DesignationGrade> DesignationGrade { get; set; }
        public virtual ICollection<EmployeeGrade> EmployeeGrade { get; set; }
        public virtual ICollection<PromotionMaster> PromotionMaster { get; set; }
    }
}
