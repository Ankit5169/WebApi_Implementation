using AutoMapper;
using DBRepository.Interface;
using DBRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        DbConnection db = new DbConnection();
        IMapper iMapper = AutoMapperConfiguration.Configure();

        public int AddNewEmployee(EmployeeModel emp)
        {
            try
            {
                db.Employees.Add(iMapper.Map<Employee>(emp));
                db.SaveChanges();

                return emp.ID;

            }
            catch (Exception ex)
            {
                //Log Error ex.Message
                return 0;
            }
        }

        public bool DeleteEmployeeByID(int empId)
        {
            try
            {
                var emp = db.Employees.Find(empId);
                if (emp != null)
                {
                    db.Employees.Remove(emp);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                //Log Error ex.Message
                return false;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployeesList()
        {
            List<EmployeeModel> empList = new List<EmployeeModel>();
            try
            {

                var emp = db.Employees.ToList();
                if (emp.Count > 0)
                {
                    foreach (var e in emp)
                    {
                        var empM = iMapper.Map<EmployeeModel>(e);
                        empList.Add(empM);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log Error ex.Message
                return null;
            }
            return empList;
        }

        public EmployeeModel GetEmployeeByID(int empId)
        {
            try
            {
                var emp = db.Employees.Where(e => e.ID == empId).FirstOrDefault();

                if (emp == null)
                    return null;

                return iMapper.Map<EmployeeModel>(emp);
            }
            catch (Exception ex)
            {
                //Log Error ex.Message
                return null;
            }
        }
    }
}

