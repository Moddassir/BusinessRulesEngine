using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    internal class MembershipRule : IPaymentRule
    {
        public string ProcessOrder(Payments payment, string output)
        {
            if (payment.eProduct == EProduct.Membership)
            {
                output += Constants.membership + Environment.NewLine;
            }
            return output;
        }
    }
}
