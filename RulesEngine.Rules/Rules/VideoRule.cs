using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    internal class VideoRule : IPaymentRule
    {
        public string ProcessOrder(Payments payment, string output)
        {
            if (payment.eProduct == EProduct.Video)
            {
                output += Constants.firstAid + Environment.NewLine;
            }
            return output;
        }
    }
}
