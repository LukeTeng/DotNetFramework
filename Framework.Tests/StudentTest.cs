using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.BLL;
using Framework.Model;
using Framework.Service;
using Framework.Service.BLLService;
using Moq;

namespace Framework.Tests
{
    /// <summary>
    /// Summary description for Student
    /// </summary>
    [TestClass]
    public class StudentTest
    {
        public StudentTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestAddStudentAndChargeSuccess()
        {
            //
            // TODO: Add test logic here
            //

            var _mockDB = new Mock<IStudentService>();
            var _mockPayment = new Mock<IPayment<CreditCardInfo>>();

            StudentBLL studentBLL = new StudentBLL(_mockDB.Object, _mockPayment.Object);

            Student studentTest = new Student
            {
                FirstName = "Helen",
                SurName = "Fan",
                Age = 32
            };

            CreditCardInfo creditCardTest = new CreditCardInfo
            {
                CreditCardNumber = "4222222222222",
                Validity = "08/32",
                CCVCode = "333",
                Comments = "Hello Test"
            };

            PayResult payResult = new PayResult
            {
                PaymentId = "1353535",
                ResultCode = 1,
                Reason = "",
                Others = "Json or XML or other structure can be stored here"
            };


            _mockDB.Setup(p => p.Create(studentTest)).Returns(true);
            _mockPayment.SetupProperty(p => p.Amount, 100);
            _mockPayment.Setup(p => p.MakePayment(creditCardTest)).Returns(payResult);
            var result = studentBLL. CreateStudent(studentTest, creditCardTest);



            //Verify the result
            Assert.IsTrue(result);
            _mockPayment.Verify(p => p.MakePayment(creditCardTest), Times.Once);
            _mockDB.Verify(p => p.Create(studentTest), Times.Once);
        }




    }
}
