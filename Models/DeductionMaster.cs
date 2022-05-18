using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class DeductionMaster
    {
        public DeductionMaster()
        {
            DeductionGrade = new HashSet<DeductionGrade>();
        }

        public int DeductionId { get; set; }
        public string DeductionName { get; set; }
        public string DeductionType { get; set; }

        public virtual ICollection<DeductionGrade> DeductionGrade { get; set; }
    }
}
