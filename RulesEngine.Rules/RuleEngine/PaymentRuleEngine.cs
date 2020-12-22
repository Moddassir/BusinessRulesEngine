
using RulesEngine.Model;
using RulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.RuleEngine
{
    public class PaymentRuleEngine
    {
        List<IPaymentRule> _rules = new List<IPaymentRule>();

        public PaymentRuleEngine(IEnumerable<IPaymentRule> rules)
        {
            _rules.AddRange(rules);
        }

        public string ProcessingRules(Payments customer)
        {
            string output = string.Empty;
            foreach (var rule in _rules)
            {
                output = rule.ProcessOrder(customer, output);
            }
            return output;
        }
    }
}
