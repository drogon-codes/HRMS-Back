using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCoreWebApp.Models
{
    public class AllowanceDetail
    {
        public int AllowanceGradeId { get; set; }
        public int AllowanceId { get; set; }
        public string AllowanceName { get; set; }
        public string IsTaxable { get; set; }
        public int GradeId { get; set; }
        public double AllowanceRate { get; set; }
    }
}
