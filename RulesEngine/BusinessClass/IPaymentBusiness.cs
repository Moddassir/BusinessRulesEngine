using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.BusinessClass
{
    public interface IPaymentBusiness
    {
        //private readonly Payments payments { get; set; }
        //public IOutput output { get; set; }

        public string ProcessOrder();
    }
}
