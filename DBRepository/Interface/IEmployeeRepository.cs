using DBRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Interface
{
    public interface IEmployeeRepository
    {
        EmployeeModel GetEmployeeByID(int empId);
        IEnumerable<EmployeeModel> GetAllEmployeesList();
        int AddNewEmployee(EmployeeModel emp);
        bool DeleteEmployeeByID(int empId);

    }
}
