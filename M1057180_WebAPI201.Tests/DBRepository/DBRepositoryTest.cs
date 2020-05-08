using System;
using System.Collections.Generic;
using System.Transactions;
using AutoMapper;
using DBRepository.Interface;
using DBRepository.Model;
using DBRepository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M1057180_WebAPI201.Tests.DBRepository
{
    [TestClass]
    public class DBRepositoryTest
    {
        IMapper iMapper = AutoMapperConfiguration.Configure();

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

            //Arrange
            IEmployeeRepository repository = new EmployeeRepository();

            //Act
            var result = repository.AddNewEmployee(emp);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(8,result);
           
        }

        [TestMethod]
        public void Test_DeleteEmployee()
        {
            //Arrange
            IEmployeeRepository repository = new EmployeeRepository();

            //Act
            var result = repository.DeleteEmployeeByID(22);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void Test_GetEmployeeByID()
        {
            //Arrange
            IEmployeeRepository repository = new EmployeeRepository();

            //Act
            var result = repository.GetEmployeeByID(5);
            var employeeModel = iMapper.Map<EmployeeModel>(result);

            //Assert
            Assert.AreEqual(5, employeeModel.ID);
            Assert.AreEqual("Barry", employeeModel.First_Name);
            Assert.AreEqual("Allen", employeeModel.Last_Name);

        }

        [TestMethod]
        public void Test_GetAllEmployeesList()
        {
            //Arrange
            IEmployeeRepository repository = new EmployeeRepository();
            
            //Act
            var result = repository.GetAllEmployeesList();
            var list = iMapper.Map<List<EmployeeModel>>(result);

            //Assert
            Assert.AreEqual(14, list.Count);

        }
    }
}
