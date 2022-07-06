using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCoreWebApp.Models
{
    public class AttendanceByEmployee
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan? TimeOfArrival { get; set; }
        public TimeSpan? TimeOfLeave { get; set; }
        public double? OverTimeHours { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public TimeSpan? TotalHours { get; set; }
    }
}
