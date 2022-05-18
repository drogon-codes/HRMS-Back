using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class DepartmentMaster
    {
        public DepartmentMaster()
        {
            DesignationMaster = new HashSet<DesignationMaster>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public int CityId { get; set; }

        public virtual CityMaster City { get; set; }
        public virtual ICollection<DesignationMaster> DesignationMaster { get; set; }
    }
}
