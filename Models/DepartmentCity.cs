using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCoreWebApp.Models
{
    public class DepartmentCity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
