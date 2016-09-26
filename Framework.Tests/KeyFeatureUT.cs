using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.BLL;
using Framework.Model;
using Framework.Service;
using Framework.Service.UtilityTools;
using Framework.Service.BLLService;
using Moq;
using System.Data.Entity;



namespace Framework.Tests
{
    /// <summary>
    /// Summary description for KeyFeatureUT
    /// </summary>
    [TestClass]
    public class KeyFeatureUT
    {
        public KeyFeatureUT()
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
        [ExpectedException(typeof(ArgumentException), "parameter error.")]
        public void TestAddStudentAndChargeFailedBecauseOfParameters()
        {

            //
            // TODO: Add test logic here
            //

            CreditCardInfo creditCardTest = new CreditCardInfo
            {
                CreditCardNumber = "4222222222222",
                Validity = "08/32",
                CCVCode = "22",        // put this short intentionally in order to get the exception
                Comments = "Hello Test"
            };

            PaymentWithCC paymentWithCC = new PaymentWithCC();

            var result = paymentWithCC.MakePayment(creditCardTest);

            //Verify the result
            //Assert.IsTrue(result.ResultCode == 1);

        }


        [TestMethod]
        public void TestAddStudentAndChargeSuccess()
        {

            CreditCardInfo creditCardTest = new CreditCardInfo
            {
                CreditCardNumber = "4222222222222",
                Validity = "08/32",
                CCVCode = "223",        // put this short intentionally in order to get the exception
                Comments = "Hello Test"
            };

            PaymentWithCC paymentWithCC = new PaymentWithCC();

            var result = paymentWithCC.MakePayment(creditCardTest);

            //Verify the result
            Assert.IsTrue(result.ResultCode == 1);

        }


        /// <summary>
        /// Transaction Feature
        /// In some key operation, data consistency should be considered
        /// </summary>
        [TestMethod]
        public void TestTransaction()
        {
            Database.SetInitializer<FrameworkContext>(null);
            var context = new FrameworkContext();

            using (System.Data.Entity.DbContextTransaction dbTran = context.Database.BeginTransaction())
            {
                try
                {

                    Student studentTest = new Student
                    {
                        FirstName = "Helen",
                        SurName = "Fan",
                        Age = 32
                    };

                    ClassInSchool classInSchool = new ClassInSchool
                    {
                        ClassName = "test1",
                        YearGrade = 0
                    };

                    StudentService _studentService = new StudentService(context);
                    ClassService _classService = new ClassService(context);

                    //get the number of students
                    var allStudent = _studentService.GetAll();
                    int numberOfStudent = UtilityTools.GetIEnumeratorAccount<Student>(allStudent);

                    _studentService.Create(studentTest);
                    _classService.Create(classInSchool);


                    //saves all above operations within one transaction
                    context.SaveChanges();

                    //commit transaction
                    dbTran.Commit();

                    //get the total number of record
                    var allStudent2 = _studentService.GetAll();
                    int numberOfStudent2 = UtilityTools.GetIEnumeratorAccount<Student>(allStudent);

                    Assert.IsTrue(numberOfStudent2 - numberOfStudent == 1);
                }
                catch (Exception ex)
                {
                    //Rollback transaction if exception occurs
                    dbTran.Rollback();
                }

            }
        }


        /// <summary>
        /// Transaction Feature
        /// This is for Rollback operation
        /// </summary>
        [TestMethod]
        public void TestTransactionRollback()
        {
            Database.SetInitializer<FrameworkContext>(null);
            var context = new FrameworkContext();

            using (System.Data.Entity.DbContextTransaction dbTran = context.Database.BeginTransaction())
            {
                try
                {
                    Student studentTest = new Student
                    {
                        FirstName = "Helen",
                        SurName = "Fan",
                        Age = 32
                    };

                    ClassInSchool classInSchool = new ClassInSchool
                    {
                        ClassName = "test1",
                        YearGrade = 0
                    };

                    StudentService _studentService = new StudentService(context);
                    ClassService _classService = new ClassService(context);

                    //get the number of students
                    var allStudent = _studentService.GetAll();
                    int numberOfStudent = UtilityTools.GetIEnumeratorAccount<Student>(allStudent);

                    //get the number of classes
                    var allClass = _classService.GetAll();
                    int numberOfClass = UtilityTools.GetIEnumeratorAccount<ClassInSchool>(allClass);

                    _studentService.Create(studentTest);
                    _classService.Create(classInSchool);

                    //saves all above operations within one transaction
                    context.SaveChanges();

                    //commit transaction
                    dbTran.Rollback();

                    //get the total number of record
                    var allStudent2 = _studentService.GetAll();
                    int numberOfStudent2 = UtilityTools.GetIEnumeratorAccount<Student>(allStudent);
                    //get the number of classes
                    var allClass2 = _classService.GetAll();
                    int numberOfClass2 = UtilityTools.GetIEnumeratorAccount<ClassInSchool>(allClass2);


                    Assert.IsTrue(numberOfStudent2 - numberOfStudent == 0);
                    Assert.IsTrue(numberOfClass2 - numberOfClass == 0);
                }
                catch (Exception ex)
                {
                    //Rollback transaction if exception occurs
                    dbTran.Rollback();
                }

            }
        }




    }
}
