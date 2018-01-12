using BindingBits.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BindingBits.Tests.ObservableObjectTests
{
    [TestClass]
    public class GetShould
    {
        [TestMethod]
        public void ReturnDefaultValueForStringWhenNotSet()
        {
            var testObject = new TestObservableObject();
            var expectedValue = default(string);
            Assert.AreEqual(expectedValue, testObject.StringPropertyNoBacking);
        }

        [TestMethod]
        public void ReturnFalseForBoolWhenNotSet()
        {
            var testObject = new TestObservableObject();
            Assert.IsFalse(testObject.BoolPropertyNoBacking);
        }

        [TestMethod]
        public void ReturnTrueForBoolWhenSet()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = true;
            Assert.IsTrue(testObject.BoolPropertyNoBacking);
        }

        [TestMethod]
        public void ReturnValueSetWhenSet()
        {
            var testObject = new TestObservableObject();
            var expectedValue = "value set";
            testObject.StringPropertyNoBacking = expectedValue;
            Assert.AreEqual(expectedValue, testObject.StringPropertyNoBacking);
        }
    }
}