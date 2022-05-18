using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class DesignationMaster
    {
        public DesignationMaster()
        {
            DesignationGrade = new HashSet<DesignationGrade>();
        }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }

        public virtual DepartmentMaster Department { get; set; }
        public virtual ICollection<DesignationGrade> DesignationGrade { get; set; }
    }
}
