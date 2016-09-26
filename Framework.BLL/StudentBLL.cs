using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Service;
using Framework.Service.BLLService;
using Framework.Model;

namespace Framework.BLL
{
    public class StudentBLL
    {
        IStudentService _StudentService;

        ///should be optimized here
        IPayment<CreditCardInfo> _Payment;
        IPayment<PayPalInfo> _PaymentWithPayPal;

        /// <summary>
        /// injection through constructor
        /// All the external related modules used in BLL should be injected through constructor
        /// </summary>
        /// <param name="studentService"></param>
        /// <param name="payment"></param>
        public StudentBLL(IStudentService studentService, IPayment<CreditCardInfo> payment)
        {
            _StudentService = studentService;
            _Payment = payment;

        }




        public StudentBLL(IStudentService studentService, IPayment<PayPalInfo> payment)
        {
            _StudentService = studentService;
            _PaymentWithPayPal = payment;

        }


        public bool CreateStudent(Student student, CreditCardInfo creditCard)
        {
            //this logi is used for test purpose
            bool result = false;

            try
            {
                //charge the user first
                _Payment.MakePayment(creditCard);

                _StudentService.Create(student);

                result = true;

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }





    }
}
