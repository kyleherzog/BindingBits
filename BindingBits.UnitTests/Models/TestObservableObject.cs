using System.Runtime.CompilerServices;

namespace BindingBits.UnitTests.Models;

public class TestObservableObject : ObservableObject
{
    public const string DefaultStringValue = "default value";

    private bool boolProperty;

    private string stringProperty = DefaultStringValue;

    public bool BoolProperty
    {
        get
        {
            return boolProperty;
        }

        set
        {
            Set(ref boolProperty, value);
        }
    }

    public bool BoolPropertyNoBacking
    {
        get
        {
            return Get<bool>();
        }

        set
        {
            Set(value);
        }
    }

    public SimpleObject ObjectPropertyNoBacking
    {
        get
        {
            return Get<SimpleObject>();
        }

        set
        {
            Set(value);
        }
    }

    public ICollection<string> PropertiesChanged { get; } = new List<string>();

    public string StringProperty
    {
        get
        {
            return stringProperty;
        }

        set
        {
            Set(ref stringProperty, value);
        }
    }

    public string StringPropertyNoBacking
    {
        get
        {
            return Get<string>();
        }

        set
        {
            Set(value);
        }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        PropertiesChanged.Add(propertyName);
    }
}