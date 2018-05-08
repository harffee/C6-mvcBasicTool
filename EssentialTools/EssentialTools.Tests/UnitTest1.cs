using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void Discount_Above_100()
        {
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            var discountedTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9M, discountedTotal);
        }
        [TestMethod]
        public void Discount_between_10_And_100()
        {
            IDiscountHelper target = getTestObject();

            decimal Ten = target.ApplyDiscount(10);
            decimal Hundered = target.ApplyDiscount(100);
            decimal Fifty = target.ApplyDiscount(50);

            Assert.AreEqual(5, Ten, "$10 discount is wrong");
            Assert.AreEqual(95, Hundered, "$100 discount is wrong");
            Assert.AreEqual(45, Fifty, "$50 discount is wrong");
        }
        [TestMethod]
        public void Discount_Less_Than_10()
        {
            IDiscountHelper target = getTestObject();

            decimal Five = target.ApplyDiscount(5);
            decimal Zero = target.ApplyDiscount(0);
            

            Assert.AreEqual(5, Five);
            Assert.AreEqual(0, Zero);
            
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            IDiscountHelper target = getTestObject();

            target.ApplyDiscount(-1);
        }
    }
}
