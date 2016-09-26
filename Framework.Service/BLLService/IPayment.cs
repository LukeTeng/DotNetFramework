using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public interface IPayment<T>
    {
        decimal Amount { get; set; }

        PayResult MakePayment(T paymentParams);
    }

    public class PayResult
    {
        public int ResultCode { get; set; }
        public string Reason { get; set; }
        public string PaymentId { get; set; }
        public string Others { get; set; }
    }


}
