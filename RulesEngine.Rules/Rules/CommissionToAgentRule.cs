using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules.Rules
{
    internal class CommissionToAgentRule : IPaymentRule
    {
        public string ProcessOrder(Payments payment, string output)
        {
            if (payment.eProduct == EProduct.PhysicalProduct || payment.eProduct == EProduct.Book)
            {
                output += Constants.sentToAgent + Environment.NewLine;
            }
            return output;
        }
    }
}
