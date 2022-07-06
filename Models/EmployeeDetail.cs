using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCoreWebApp.Models
{
    public class EmployeeDetail
    {
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
        public string CityName { get; set; }
        public string PanNo { get; set; }
        public string PanCopy { get; set; }
        public string Qualifications { get; set; }
        public int? Experiance { get; set; }
        public string BankAcNo { get; set; }
        public string BankIfsccode { get; set; }
        public string BankHolderName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int EmployeeGradeId { get; set; }
    }
}
