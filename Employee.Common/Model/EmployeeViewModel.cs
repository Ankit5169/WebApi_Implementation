using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.Model
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Department { get; set; }
    }
}
