using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    internal class BookProductRule : IPaymentRule
    {
        public string ProcessOrder(Payments payment, string output)
        {
            if(payment.eProduct == EProduct.Book)
            {
                output += Constants.duplicateSlip + Environment.NewLine;
            }
            return output;
        }
    }
}
