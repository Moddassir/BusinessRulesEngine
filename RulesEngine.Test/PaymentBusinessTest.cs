using Microsoft.VisualStudio.TestTools.UnitTesting;
using RulesEngine.BusinessClass;
using RulesEngine.Model;
using RulesEngine.Model.Common;
using System;

namespace RulesEngine.Test
{
    [TestClass]
    public class PaymentBusinessTest
    {
        private readonly Payments physical;
        private readonly Payments book;
        private readonly Payments membership;
        private readonly Payments upgradeMembership;
        private readonly Payments video;
        private readonly Payments invalid;
        public PaymentBusinessTest()
        {
            physical = new Payments { ProductAmount = 200, eProduct = EProduct.PhysicalProduct };
            book = new Payments { ProductAmount = 200, eProduct = EProduct.Book };
            membership = new Payments { ProductAmount = 200, eProduct = EProduct.Membership };
            upgradeMembership = new Payments { ProductAmount = 200, eProduct = EProduct.UpgradeMembership };
            video = new Payments { ProductAmount = 200, eProduct = EProduct.Video };
            invalid = new Payments { ProductAmount = -3, eProduct = EProduct.Video };
        }

        [TestMethod]
        public void PhysicalProductPositive()
        {
            //Arrange

            IPaymentBusiness paymentBusiness = new PaymentBusiness(physical);

            //Act
            string output = paymentBusiness.ProcessOrder();


            //Assert
            Assert.IsTrue(output.Contains(Constants.physicalProduct));
            Assert.IsTrue(output.Contains(Constants.sentToAgent));
            Assert.IsFalse(output.Contains(Constants.duplicateSlip));
            Assert.IsFalse(output.Contains(Constants.upgradeMembership));
            Assert.IsFalse(output.Contains(Constants.membership));
            Assert.IsFalse(output.Contains(Constants.emailSent));
            Assert.IsFalse(output.Contains(Constants.firstAid));
        }

        [TestMethod]
        public void BookProductPositive()
        {
            //Arrange

            IPaymentBusiness paymentBusiness = new PaymentBusiness(book);

            //Act
            string output = paymentBusiness.ProcessOrder();


            //Assert
            Assert.IsTrue(output.Contains(Constants.duplicateSlip));
            Assert.IsTrue(output.Contains(Constants.sentToAgent));
            Assert.IsFalse(output.Contains(Constants.upgradeMembership));
            Assert.IsFalse(output.Contains(Constants.membership));
            Assert.IsFalse(output.Contains(Constants.physicalProduct));
            Assert.IsFalse(output.Contains(Constants.emailSent));
            Assert.IsFalse(output.Contains(Constants.firstAid));
        }

        [TestMethod]
        public void MembershipProductPositive()
        {
            //Arrange

            IPaymentBusiness paymentBusiness = new PaymentBusiness(membership);

            //Act
            string output = paymentBusiness.ProcessOrder();


            //Assert
            Assert.IsTrue(output.Contains(Constants.membership));
            Assert.IsTrue(output.Contains(Constants.emailSent));
            Assert.IsFalse(output.Contains(Constants.duplicateSlip));
            Assert.IsFalse(output.Contains(Constants.firstAid));
            Assert.IsFalse(output.Contains(Constants.upgradeMembership));
            Assert.IsFalse(output.Contains(Constants.physicalProduct));
        }

        [TestMethod]
        public void UpgradeMembershipProductPositive()
        {
            //Arrange

            IPaymentBusiness paymentBusiness = new PaymentBusiness(upgradeMembership);

            //Act
            string output = paymentBusiness.ProcessOrder();


            //Assert
            Assert.IsTrue(output.Contains(Constants.upgradeMembership));
            Assert.IsTrue(output.Contains(Constants.emailSent));
            Assert.IsFalse(output.Contains(Constants.duplicateSlip));
            Assert.IsFalse(output.Contains(Constants.membership));
            Assert.IsFalse(output.Contains(Constants.physicalProduct));
            Assert.IsFalse(output.Contains(Constants.firstAid));
        }

        [TestMethod]
        public void videoProductPositive()
        {
            //Arrange

            IPaymentBusiness paymentBusiness = new PaymentBusiness(video);

            //Act
            string output = paymentBusiness.ProcessOrder();


            //Assert
            Assert.IsTrue(output.Contains(Constants.firstAid));
            Assert.IsFalse(output.Contains(Constants.duplicateSlip));
            Assert.IsFalse(output.Contains(Constants.upgradeMembership));
            Assert.IsFalse(output.Contains(Constants.membership));
            Assert.IsFalse(output.Contains(Constants.physicalProduct));
            Assert.IsFalse(output.Contains(Constants.emailSent));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaymentNullException()
        {
            //Arrange

            IPaymentBusiness paymentBusiness = new PaymentBusiness(null);

            //Act
            string output = paymentBusiness.ProcessOrder();


            //Assert
            

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaymentLessthanZeroException()
        {
            //Arrange

            IPaymentBusiness paymentBusiness = new PaymentBusiness(invalid);

            //Act
            string output = paymentBusiness.ProcessOrder();


            //Assert


        }
    }
}
