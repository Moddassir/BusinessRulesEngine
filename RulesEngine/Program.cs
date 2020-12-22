using RulesEngine.BusinessClass;
using RulesEngine.Model;
using System;

namespace RulesEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Payments physical = new Payments { ProductAmount = 200, eProduct = EProduct.PhysicalProduct};
            Payments book = new Payments { ProductAmount = 100, eProduct = EProduct.Book };
            Payments member = new Payments { ProductAmount = 300, eProduct = EProduct.Membership };
            Payments upgrade = new Payments { ProductAmount = 200, eProduct = EProduct.UpgradeMembership };
            Payments video = new Payments { ProductAmount = 200, eProduct = EProduct.Video };

            IPaymentBusiness paymentBusiness = new PaymentBusiness(video);
            string output= paymentBusiness.ProcessOrder();
            Console.WriteLine(output);

        }
    }
}
