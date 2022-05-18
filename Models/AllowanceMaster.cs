using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class AllowanceMaster
    {
        public AllowanceMaster()
        {
            AllowanceGrade = new HashSet<AllowanceGrade>();
        }

        public int AllowanceId { get; set; }
        public string AllowanceName { get; set; }
        public string IsTaxable { get; set; }

        public virtual ICollection<AllowanceGrade> AllowanceGrade { get; set; }
    }
}
