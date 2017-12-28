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

#### ObservableObject Methods

##### bool Set\<T\>(ref T field, T value, string propertyName) 
Sets the field to the value specified and if changed, raises PropertyChanged event with the propertyName specified.  If no property name is specified then the calling property name is used.

## License
[Apache 2.0](LICENSE)