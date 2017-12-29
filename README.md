# Binding Bits

[![Build status](https://ci.appveyor.com/api/projects/status/gmvrjms5y52fl8gw?svg=true)](https://ci.appveyor.com/project/kyleherzog/bindingbits)

This library is available from [NuGet.org](https://www.nuget.org/packages/BindingBits/)
or download from the [CI build feed](https://ci.appveyor.com/nuget/BindingBits).

--------------------------

A .NET Standard class library with helpers to assist with bindings in an MVVM environment.

See the [changelog](CHANGELOG.md) for changes and roadmap.

## Classes

### ObservableObject
A base class implementing INotifyPropertyChanged, simplifying implementing this critical interface. 

#### ObservableObject Properties Using Backing Fields

If a property in a class that inherits from ObservableObject has a private member setup as a backing field, the Set method can be used, passing in the backing field by reference.  If the value has changed, PropertyChanged will be raised.

```c#
private bool _isCool;

public bool IsCool
{
	get
	{
		return _isCool;
	}
	set
	{
		Set(ref _isCool, value);
	}
}
```

#### ObservableObject Properties Without Backing Fields
The ObservableObject base class can also be used without setting up property backing fields.  This just requires using the Get\<T\> method, and eliminates the need to pass in a variable by reference when calling Set.

```c#
public bool IsHot
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
```


## License
[Apache 2.0](LICENSE)