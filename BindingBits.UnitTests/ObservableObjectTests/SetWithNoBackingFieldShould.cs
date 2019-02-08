using BindingBits.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BindingBits.UnitTests.ObservableObjectTests
{
    [TestClass]
    public class SetGivenNoFieldPassedShould
    {
        [TestMethod]
        public void NotRaisePropertyChangedWhenBoolPropertyValueNotChangedFromDefault()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = testObject.BoolPropertyNoBacking;

            var expectedChangedCount = 0;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolPropertyNoBacking)));
        }

        [TestMethod]
        public void NotRaisePropertyChangedWhenStringPropertyNotChangedFromDefault()
        {
            var testObject = new TestObservableObject
            {
                StringPropertyNoBacking = default(string)
            };

            var expectedChangedCount = 0;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringPropertyNoBacking)));
        }

        [TestMethod]
        public void RaisePropertyChangedOnlyOnceWhenBoolPropertyValueSetTwiceButChangedOnce()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = !testObject.BoolPropertyNoBacking;
            testObject.BoolPropertyNoBacking = testObject.BoolPropertyNoBacking;
            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolPropertyNoBacking)));
        }

        [TestMethod]
        public void RaisePropertyChangedOnlyOnceWhenStringProperySetTwiceButChangedOnce()
        {
            var newValue = "a new value";
            var testObject = new TestObservableObject
            {
                StringPropertyNoBacking = newValue
            };

            testObject.StringPropertyNoBacking = newValue;

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringPropertyNoBacking)));
        }

        [TestMethod]
        public void RaisePropertyChangedTwiceWhenBoolPropertyValueChangedTwice()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = !testObject.BoolPropertyNoBacking;
            testObject.BoolPropertyNoBacking = !testObject.BoolPropertyNoBacking;
            var expectedChangedCount = 2;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolPropertyNoBacking)));
        }

        [TestMethod]
        public void RaisePropertyChangedTwiceWhenStringProperyChangedTwice()
        {
            var testObject = new TestObservableObject
            {
                StringPropertyNoBacking = "a new value"
            };

            testObject.StringPropertyNoBacking = "another value";

            var expectedChangedCount = 2;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringPropertyNoBacking)));
        }

        [TestMethod]
        public void RaisePropertyChangedWhenBoolPropertyValueChangedFromDefault()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = !testObject.BoolPropertyNoBacking;

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolPropertyNoBacking)));
        }

        [TestMethod]
        public void RaisePropertyChangedWhenStringProperyChangedFromDefault()
        {
            var testObject = new TestObservableObject
            {
                StringPropertyNoBacking = "a new value"
            };

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringPropertyNoBacking)));
        }
    }
}
