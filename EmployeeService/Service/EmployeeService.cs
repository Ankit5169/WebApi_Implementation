using AutoMapper;
using DBRepository.Interface;
using DBRepository.Model;
using Employees.Common;
using Employees.Common.Model;
using EmployeeService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;
        IMapper iMapper = AutoMapperConfiguration.Configure();

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public int AddEmployee(EmployeeViewModel emp)
        {
            try
            {
                return _repository.AddNewEmployee(iMapper.Map<EmployeeModel>(emp));
            }
            catch (Exception ex)
            {
                //Exception handing in case Model mapping fails
                return 0;
            }
        }

        public bool DeleteEmployee(int empId)
        {
            return _repository.DeleteEmployeeByID(empId);
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            try
            {
                var result = _repository.GetAllEmployeesList();

                if (result == null)
                    return null;

                return iMapper.Map<List<EmployeeViewModel>>(result);
            }
            catch (Exception ex)
            {
                //Exception handing in case Model mapping fails
                return null;
            }
        }

        public EmployeeViewModel GetEmployee(int Id)
        {
            try
            {
                var result = _repository.GetEmployeeByID(Id);

                if (result == null)
                    return null;

                return iMapper.Map<EmployeeViewModel>(result);
            }
            catch (Exception ex)
            {
                //Exception handing in case Model mapping fails
                return null;
            }
        }
    }
}
