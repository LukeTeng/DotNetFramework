using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.BLL;
using Framework.Model;
using Framework.Service;
using Moq;
using System.Web.Mvc;

namespace Framework.Controllers.Tests
{
    [TestClass()]
    public class ControllerTest
    {
        [TestMethod()]
        public void StudentCreateTest()
        {

            Student studentTest = new Student
            {
                FirstName = "Helen",
                SurName = "Fan",
                Age = 32
            };

            var mockStudent = new Mock<IStudentService>();
            mockStudent.Setup(p => p.Create(studentTest)).Returns(true);

            var controller = new StudentController(mockStudent.Object);

            //normal flow, redirect to another action
            var result = (RedirectToRouteResult) controller.Create(studentTest);

            //Student student = (Student)result.Model;

            Assert.AreEqual("Index", result.RouteValues["action"]);
            //Assert.AreEqual(result.ViewName, "Create");
            //Assert.IsTrue(student.Age == 32);

        }
    }
}