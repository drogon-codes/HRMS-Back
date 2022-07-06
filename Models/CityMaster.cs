using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class CityMaster
    {
        public CityMaster()
        {
            DepartmentMaster = new HashSet<DepartmentMaster>();
            EmployeeMaster = new HashSet<EmployeeMaster>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public virtual StateMaster State { get; set; }
        public virtual ICollection<DepartmentMaster> DepartmentMaster { get; set; }
        public virtual ICollection<EmployeeMaster> EmployeeMaster { get; set; }
    }
}
