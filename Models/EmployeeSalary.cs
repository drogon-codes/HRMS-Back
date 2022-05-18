using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class EmployeeSalary
    {
        public EmployeeSalary()
        {
            SalaryPayment = new HashSet<SalaryPayment>();
        }

        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EmbursementDate { get; set; }
        public double? BasicSalary { get; set; }
        public double? GrossSalary { get; set; }
        public double? TotalSalary { get; set; }

        public virtual EmployeeMaster Employee { get; set; }
        public virtual ICollection<SalaryPayment> SalaryPayment { get; set; }
    }
}
