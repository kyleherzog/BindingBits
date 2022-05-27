using System.Linq;
using BindingBits.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BindingBits.UnitTests.ObservableObjectTests;

[TestClass]
public class SetWithBackingFieldShould
{
    [TestMethod]
    public void NotRaisePropertyChangedWhenBoolPropertyValueNotChangedFromDefault()
    {
        var testObject = new TestObservableObject();
        testObject.BoolProperty = testObject.BoolProperty;

        var expectedChangedCount = 0;

        Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolProperty)));
    }

    [TestMethod]
    public void NotRaisePropertyChangedWhenStringProperyNotChangedFromDefault()
    {
        var testObject = new TestObservableObject
        {
            StringProperty = TestObservableObject.DefaultStringValue,
        };

        var expectedChangedCount = 0;

        Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringProperty)));
    }

    [TestMethod]
    public void RaisePropertyChangedWhenBoolPropertyValueChangedFromDefault()
    {
        var testObject = new TestObservableObject();
        testObject.BoolProperty = !testObject.BoolProperty;

        var expectedChangedCount = 1;

        Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.BoolProperty)));
    }

    [TestMethod]
    public void RaisePropertyChangedWhenStringProperyChangedFromDefault()
    {
        var testObject = new TestObservableObject
        {
            StringProperty = "a new value",
        };

        var expectedChangedCount = 1;

        Assert.AreEqual(expectedChangedCount, testObject.PropertiesChanged.Count(x => x == nameof(testObject.StringProperty)));
    }
}