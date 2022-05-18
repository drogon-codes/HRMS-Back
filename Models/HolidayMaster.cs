using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class HolidayMaster
    {
        public int HolidayId { get; set; }
        public DateTime? HolidayDate { get; set; }
        public string HolidayTitle { get; set; }
    }
}
