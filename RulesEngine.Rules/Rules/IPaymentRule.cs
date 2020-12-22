using RulesEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    public interface IPaymentRule
    {
        string ProcessOrder(Payments payment, string output);
    }
}
