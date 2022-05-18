using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class SalaryPayment
    {
        public int TransactionId { get; set; }
        public int SalaryId { get; set; }
        public double? Amount { get; set; }
        public string PaymentId { get; set; }

        public virtual EmployeeSalary Salary { get; set; }
    }
}
