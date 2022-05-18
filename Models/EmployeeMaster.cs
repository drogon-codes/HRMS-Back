using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class EmployeeMaster
    {
        public EmployeeMaster()
        {
            AttendanceMaster = new HashSet<AttendanceMaster>();
            EmployeeGrade = new HashSet<EmployeeGrade>();
            EmployeeSalary = new HashSet<EmployeeSalary>();
            LeaveMaster = new HashSet<LeaveMaster>();
            PromotionMaster = new HashSet<PromotionMaster>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFname { get; set; }
        public string EmployeeMname { get; set; }
        public string EmployeeLname { get; set; }
        public string EmployeeEmail { get; set; }
        public string Password { get; set; }
        public string EmployeeContact { get; set; }
        public DateTime? EmployeeDoj { get; set; }
        public string EmployeeAddress { get; set; }
        public int? CityId { get; set; }
        public string PanNo { get; set; }
        public string PanCopy { get; set; }
        public string Qualifications { get; set; }
        public int? Experiance { get; set; }
        public string BankAcNo { get; set; }
        public string BankIfsccode { get; set; }
        public string BankHolderName { get; set; }

        public virtual CityMaster City { get; set; }
        public virtual ICollection<AttendanceMaster> AttendanceMaster { get; set; }
        public virtual ICollection<EmployeeGrade> EmployeeGrade { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
        public virtual ICollection<LeaveMaster> LeaveMaster { get; set; }
        public virtual ICollection<PromotionMaster> PromotionMaster { get; set; }
    }
}
