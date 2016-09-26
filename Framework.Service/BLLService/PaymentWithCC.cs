using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service.BLLService
{
    public class PaymentWithCC : IPayment<CreditCardInfo>
    {
        public decimal Amount { get; set; }


        /// <summary>
        /// This is a sample code only, in order to execute unit test.
        /// Third party interface will be considered later, user interface or object injection to achieve this.
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public PayResult MakePayment(CreditCardInfo creditCard)
        {
            PayResult result = new PayResult();

            if (string.IsNullOrEmpty(creditCard.CCVCode) || creditCard.CCVCode.Length != 3)
            {
                throw new ArgumentException("Credit Card CCV code should be with 3 digits.");
            }

            try
            {
                //logic to call SDK API

                result.ResultCode = 1; //success
                result.Reason = string.Empty;
                result.PaymentId = "111111111233";
                result.Others = "otherinfo"; // this parameter will be used to bring other information back to caller.

                return result;
            }
            catch (Exception ex)
            {
                //log

                throw ex;
            }
        }




        /// <summary>
        /// This function is for test only in order to show IPayment interface could support multiple way of payment
        /// </summary>
        /// <param name="payPal"></param>
        /// <returns></returns>
        public PayResult MakePayment(PayPalInfo payPal)
        {
            PayResult result = new PayResult();

            try
            {
                //logic to call SDK API

                result.ResultCode = 1; // success
                result.Reason = string.Empty;
                result.PaymentId = "111111111233";
                result.Others = "otherinfo"; // this parameter will be used to bring other information back to caller.

                return result;
            }
            catch (Exception ex)
            {
                //log

                throw ex;
            }
        }





    }

    public class CreditCardInfo
    {
        public string CreditCardNumber { get; set; }
        public string Validity { get; set; }
        public string CCVCode { get; set; }
        public string Comments { get; set; }
    }


    /// <summary>
    /// this is for test only 
    /// </summary>
    public class PayPalInfo
    {
        public string accountId { get; set; }
        public string Password { get; set; }
        public string Comments { get; set; }
    }

}
