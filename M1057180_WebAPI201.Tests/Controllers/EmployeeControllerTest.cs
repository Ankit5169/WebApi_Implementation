using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DBRepository.Model;
using Employees.Common.Model;
using EmployeeService.Interface;
using M1057180_WebAPI201.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace M1057180_WebAPI201.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void Test_GetAllEmployees()
        {
            var empList = new List<EmployeeViewModel>
            {
                new EmployeeViewModel{ID = 1,First_Name="Ankit",Last_Name="Pratap",Age=29,Department="IT"},
                new EmployeeViewModel{ID = 1,First_Name="Bruce",Last_Name="Wayne",Age=34,Department="Operations"}
            };

            // Arrange
            var mockRepository = new Mock<IEmployeeService>();
            mockRepository.Setup(x => x.GetAllEmployees()).Returns(empList);

            var controller = new EmployeeController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<EmployeeViewModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

        }

        [TestMethod]
        public void Test_GetEmployeeById()
        {
            var emp = new EmployeeViewModel { ID = 1, First_Name = "Ankit", Last_Name = "Pratap", Age = 29, Department = "IT" };

            // Arrange
            var mockRepository = new Mock<IEmployeeService>();
            mockRepository.Setup(x => x.GetEmployee(1)).Returns(emp);

            var controller = new EmployeeController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Get(1);
            var contentResult = actionResult as OkNegotiatedContentResult<EmployeeViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ID);
            Assert.AreEqual("Ankit", contentResult.Content.First_Name);
            Assert.AreEqual("Pratap", contentResult.Content.Last_Name);
        }

        [TestMethod]
        public void Test_AddNewEmployee()
        {
            EmployeeViewModel emp = new EmployeeViewModel
            {
                ID = 8,
                First_Name = "Ankit",
                Last_Name = "Pratap",
                Age = 45,
                Department = "Ministry of IT",
            };

            // Arrange
            var mockRepository = new Mock<IEmployeeService>();
            mockRepository.Setup(x => x.AddEmployee(emp)).Returns(8);

            EmployeeController controller = new EmployeeController(mockRepository.Object);
            
            // Act
            IHttpActionResult actionResult = controller.Add(emp);
            var contentResult = actionResult as NegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("New employee added successfully.", contentResult.Content);
        }


        [TestMethod]
        public void Test_DeleteEmployee()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeService>();
            mockRepository.Setup(x => x.DeleteEmployee(1)).Returns(true);

            EmployeeController controller = new EmployeeController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Delete(1);
            var contentResult = actionResult as NegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("Employee deleted successfully.", contentResult.Content);
        }
    }
}
