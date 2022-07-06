using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCoreWebApp.Models
{
    public class DeductionDetail
    {
        public int DeductionGradeId { get; set; }
        public int DeductionId { get; set; }
        public string DeductionName { get; set; }
        public string DeductionType { get; set; }
        public int GradeId { get; set; }
        public double DeductionRate { get; set; }
    }
}
