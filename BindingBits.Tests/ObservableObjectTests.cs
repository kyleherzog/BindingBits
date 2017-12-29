using System;
using System.Linq;
using BindingBits.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BindingBits.Tests
{
    [TestClass]
    public class ObservableObjectTests
    {
        [TestMethod]
        public void GetOnBoolPropertyNoBackingReturnsDefaultValueWhenNotSet()
        {
            var testObject = new TestObservableObject();
            Assert.IsFalse(testObject.BoolPropertyNoBacking);
        }

        [TestMethod]
        public void GetOnBoolPropertyNoBackingReturnValueSet()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = true;
            Assert.IsTrue(testObject.BoolPropertyNoBacking);
        }

        [TestMethod]
        public void GetOnStringPropertyNoBackingReturnDefaultValueWhenNotSet()
        {
            var testObject = new TestObservableObject();
            var expectedValue = default(string);
            Assert.AreEqual(expectedValue, testObject.StringPropertyNoBacking);
        }

        [TestMethod]
        public void GetOnStringPropertyNoBackingReturnValueWhenSet()
        {
            var testObject = new TestObservableObject();
            var expectedValue = "value set";
            testObject.StringPropertyNoBacking = expectedValue;
            Assert.AreEqual(expectedValue, testObject.StringPropertyNoBacking);
        }

        [TestMethod]
        public void SetOnBoolPropertyRaisesPropertyChangedWhenValueChangedFromDefault()
        {
            var testObject = new TestObservableObject();
            testObject.BoolProperty = !testObject.BoolProperty;

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolProperty)));
        }

        [TestMethod]
        public void SetOnBoolPropertyDoesNotRaisePropertyChangedWhenValueSetToDefault()
        {
            var testObject = new TestObservableObject();
            testObject.BoolProperty = testObject.BoolProperty;

            var expectedChangedCount = 0;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolProperty)));
        }

        [TestMethod]
        public void SetOnBoolPropertyNoBackingRaisesPropertyChangedWhenValueChangedFromDefault()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = !testObject.BoolPropertyNoBacking;

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolPropertyNoBacking)));
        }

        [TestMethod]
        public void SetOnBoolPropertyNoBackingDoesNotRaisePropertyChangedWhenValueSetToDefault()
        {
            var testObject = new TestObservableObject();
            testObject.BoolPropertyNoBacking = testObject.BoolPropertyNoBacking;

            var expectedChangedCount = 0;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolPropertyNoBacking)));
        }

        [TestMethod]
        public void SetOnStringPropertyRaisesPropertyChangedWhenValueChangedFromDefault()
        {
            var testObject = new TestObservableObject
            {
                StringProperty = "a new value"
            };

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringProperty)));
        }

        [TestMethod]
        public void SetOnStringPropertyDoesNotRaisePropertyChangedWhenValueNotChangedFromDefault()
        {
            var testObject = new TestObservableObject
            {
                StringProperty = TestObservableObject.DefaultStringValue
            };

            var expectedChangedCount = 0;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringProperty)));
        }

        [TestMethod]
        public void SetOnStringPropertyNoBackingRaisesPropertyChangedWhenValueChangedFromDefault()
        {
            var testObject = new TestObservableObject
            {
                StringPropertyNoBacking = "a new value"
            };

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringPropertyNoBacking)));
        }

        [TestMethod]
        public void SetOnStringPropertyNoBackingDoesNotRaisePropertyChangedWhenValueNotChangedFromDefault()
        {
            var testObject = new TestObservableObject
            {
                StringPropertyNoBacking = default(string)
            };

            var expectedChangedCount = 0;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringPropertyNoBacking)));
        }
    }
}
