using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCoreWebApp.Models
{
    public class HrGrade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string ModeOfSalary { get; set; }
        public double? WagePerHour { get; set; }
        public double? DailySalary { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string? Allowance { get; set; }
        public double? AllowanceRate { get; set; }
        public string? Deduction { get; set; }
        public double? DeductionRate { get; set; }
        public int DesignationGradeId { get; set; }
        public int AllowanceGradeId { get; set; }
        public int DeductionGradId { get; set; }
    }
}
