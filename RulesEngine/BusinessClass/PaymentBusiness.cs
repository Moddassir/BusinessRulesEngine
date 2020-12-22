using RulesEngine.Model;
using RulesEngine.Model.Common;
using RulesEngine.RuleEngine;
using RulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RulesEngine.BusinessClass
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly Payments payments;

        public PaymentBusiness(Payments payments)
        {
            this.payments = payments ?? throw new ArgumentNullException(Constants.paymentNullException);
            if(payments.ProductAmount <= 0 )
            {
                throw new ArgumentException();
            }
        }

        public string ProcessOrder()
        {
            var ruleType = typeof(IPaymentRule);
            IEnumerable<IPaymentRule> rules = ruleType.Assembly.GetTypes()
                .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                .Select(r => Activator.CreateInstance(r) as IPaymentRule);

            var engine = new PaymentRuleEngine(rules);

            return engine.ProcessingRules(payments);
        }
    }
}
