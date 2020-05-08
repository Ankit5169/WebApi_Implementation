using Employees.Common.Model;
using EmployeeService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace M1057180_WebAPI201.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public EmployeeController()
        {
        }

        //Get All Employees
        [HttpGet]
        [Route()]
        public IHttpActionResult Get()
        {
            try
            {
                var emp = _service.GetAllEmployees();

                if (emp == null)
                    return Content(HttpStatusCode.InternalServerError, "No able to fetch data found.Please contact Admin.");

                if (emp.ToList().Count == 0)
                    return Content(HttpStatusCode.NotFound, "No data found.");

                return Ok(emp);
            }
            catch (Exception ex)
            { return InternalServerError(ex); }
        }

        //Get Employee by id
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int ID)
        {
            try
            {
                if (ID > 0)
                {
                    var emp = _service.GetEmployee(ID);

                    if (emp == null)
                        return Content(HttpStatusCode.NotFound, "Employee not found."); ;

                    return Ok(emp);
                }
                else
                    return Content(HttpStatusCode.BadRequest, "Employee Id has to be greater than 0.");
            }
            catch (Exception ex)
            { return InternalServerError(ex); }
        }

        //Add New Employee
        [HttpPost]
        [Route()]
        public IHttpActionResult Add(EmployeeViewModel emp)
        {
            try
            {
                if (emp != null)
                {
                    var emp_ID = _service.AddEmployee(emp);

                    if (emp_ID > 0)
                        return Content(HttpStatusCode.Created, "New employee added successfully.");
                    else
                        return Content(HttpStatusCode.InternalServerError, "No able save new employee. Please contact Admin.");
                }
                else
                    return Content(HttpStatusCode.BadRequest, "Employee data cannot be null");
            }
            catch (Exception ex)
            { return InternalServerError(ex); }
        }

        //Delete existing employee
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int ID)
        {
            try
            {
                if (ID > 0)
                {
                    var status = _service.DeleteEmployee(ID);

                    if (status)
                        return Content(HttpStatusCode.OK, "Employee deleted successfully.");
                    else
                        return Content(HttpStatusCode.NotFound, "Employee not found."); ;
                }
                else
                    return Content(HttpStatusCode.BadRequest, "Employee Id has to be greater than 0.");
            }
            catch (Exception ex)
            { return InternalServerError(ex); }
        }
    }
}
