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
        public void SetOnStringPropertyRaisesPropertyChangedWhenValueChangedFromDefault()
        {
            var testObject = new TestObservableObject();
            testObject.StringProperty = "a new value";

            var expectedChangedCount = 1;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringProperty)));
        }

        [TestMethod]
        public void SetOnStringPropertyDoesNotRaisePropertyChangedWhenValueNotChangedFromDefault()
        {
            var testObject = new TestObservableObject();
            testObject.StringProperty = TestObservableObject.DefaultStringValue;

            var expectedChangedCount = 0;

            Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringProperty)));
        }
    }
}
