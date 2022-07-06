using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCoreWebApp.Models
{
    public class EmployeeSalaryReport
    {
        public int EmployeeId { get; set; }
        public string EmployeeFname { get; set; }
        public string EmployeeMname { get; set; }
        public string EmployeeLname { get; set; }
        public string EmployeeEmail { get; set; }
        public DateTime? EmployeeDoj { get; set; }
        public string PanNo { get; set; }
        public string BankAcNo { get; set; }
        public string BankIfsccode { get; set; }
        public string BankHolderName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public double? DailySalary { get; set; }
        public double? WagePerHour { get; set; }
        public string ModeOfSalary { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int EmployeeGradeId { get; set; }
        public int AllowanceId { get; set; }
        public string AllowanceName { get; set; }
        public double AllowanceRate { get; set; }
        public int DeductionId { get; set; }
        public string DeductionName { get; set; }
        public double DeductionRate { get; set; }
    }
}
