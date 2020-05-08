using Employees.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Interface
{
    public interface IEmployeeService
    {
        EmployeeViewModel GetEmployee(int Id);
        IEnumerable<EmployeeViewModel> GetAllEmployees();
        int AddEmployee(EmployeeViewModel emp);
        bool DeleteEmployee(int empId);
    }
}
