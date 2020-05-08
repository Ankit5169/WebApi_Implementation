using System;
using System.Collections.Generic;
using AutoMapper;
using DBRepository.Interface;
using DBRepository.Model;
using Employees.Common.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace M1057180_WebAPI201.Tests.Repository
{
    [TestClass]
    public class ServiceLayerTest
    {
        IMapper iMapper = AutoMapperConfiguration.Configure();

        [TestMethod]
        public void Test_GetAllEmployeesFromDB()
        {
            var empList = new List<EmployeeModel>
            {
                new EmployeeModel{ID = 1,First_Name="Ankit",Last_Name="Pratap",Age=29,Department="IT"},
                new EmployeeModel{ID = 1,First_Name="Bruce",Last_Name="Wayne",Age=34,Department="Operations"}
            };

            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(x => x.GetAllEmployeesList()).Returns(empList);

            var serviceLayer = new EmployeeService.Service.EmployeeService(mockRepository.Object);

            // Act
            IEnumerable<EmployeeViewModel> actionResult =  serviceLayer.GetAllEmployees();
            var contentResult = iMapper.Map<List<EmployeeViewModel>>(actionResult);

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(2,contentResult.Count);
            Assert.AreEqual("Ankit", contentResult[0].First_Name);
            Assert.AreEqual("Pratap", contentResult[0].Last_Name);

        }

        [TestMethod]
        public void Test_GetEmployeeById()
        {
            var emp = new EmployeeModel { ID = 1, First_Name = "Ankit", Last_Name = "Pratap", Age = 29, Department = "IT" };

            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(x => x.GetEmployeeByID(1)).Returns(emp);

            var serviceLayer = new EmployeeService.Service.EmployeeService(mockRepository.Object);

            // Act
            EmployeeViewModel actionResult = serviceLayer.GetEmployee(1);
            var contentResult = iMapper.Map<EmployeeViewModel>(actionResult);

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual("Ankit", contentResult.First_Name);
            Assert.AreEqual("Pratap", contentResult.Last_Name);

        }

        [TestMethod]
        public void Test_AddNewEmployee()
        {
            EmployeeModel emp = new EmployeeModel
            {
                ID = 8,
                First_Name = "Ankit",
                Last_Name = "Pratap",
                Age = 45,
                Department = "Ministry of IT",
            };

            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(x => x.AddNewEmployee(emp)).Returns(8);

            var serviceLayer = new EmployeeService.Service.EmployeeService(mockRepository.Object);

            // Act
            var actionResult = serviceLayer.AddEmployee(iMapper.Map<EmployeeViewModel>(emp));
            
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(0, actionResult);
            
        }

        [TestMethod]
        public void Test_DeleteEmployeeByID()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(x => x.DeleteEmployeeByID(1)).Returns(true);

            var serviceLayer = new EmployeeService.Service.EmployeeService(mockRepository.Object);

            // Act
            var actionResult = serviceLayer.DeleteEmployee(1);
            
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(true, actionResult);
        }
    }
}
