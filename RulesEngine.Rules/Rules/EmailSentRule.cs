using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules.Rules
{
    internal class EmailSentRule : IPaymentRule
    {
        public string ProcessOrder(Payments payment, string output)
        {
            if (payment.eProduct == EProduct.Membership || payment.eProduct == EProduct.UpgradeMembership)
            {
                output += Constants.emailSent + Environment.NewLine;
            }
            return output;
        }
    }
}
