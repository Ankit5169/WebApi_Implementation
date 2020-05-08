using System;
using System.Web.Http;
using M1057180_WebAPI201.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M1057180_WebAPI_Test.Controller
{
    [TestClass]
    public class EmployeeeControllerTest
    {
        [TestMethod]
        public void Test_GetAllEmployees()
        {
            // Arrange
            EmployeeController controller = new EmployeeController();

            // Act
            var result = controller.Get() as IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
