using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    internal class PhysicalProductRule : IPaymentRule
    {
        public string ProcessOrder(Payments payment, string output)
        {
            if (payment.eProduct == EProduct.PhysicalProduct)
            {
                output += Constants.physicalProduct + Environment.NewLine;
            }
            return output;
        }
    }
}
