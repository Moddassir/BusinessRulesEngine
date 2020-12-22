using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    internal class UpgradeMembershipRule : IPaymentRule
    {
        public string ProcessOrder(Payments payment, string output)
        {
            if (payment.eProduct == EProduct.UpgradeMembership)
            {
                output += Constants.upgradeMembership + Environment.NewLine;
            }
            return output;
        }
    }
}
