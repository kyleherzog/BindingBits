using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using BindingBits.Extensions;

namespace BindingBits;

/// <summary>
/// A base class to facilitate implementing INotifyPropertyChanged.
/// </summary>
[DataContract]
public abstract class ObservableObject : INotifyPropertyChanged
{
    private readonly Lazy<List<KeyValuePair<string, object>>> backingFieldValues = new Lazy<List<KeyValuePair<string, object>>>();

    /// <summary>
    /// Notifies clients that a property value has changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Gets a list of property values that are stored when setting a property without passing a field to set as a parameter.
    /// </summary>
    [NotMapped]
    protected List<KeyValuePair<string, object>> BackingFields { get => backingFieldValues.Value; }

    /// <summary>
    /// Gets the specified property value from the BackingFields.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the property value to be retrieved.</typeparam>
    /// <param name="propertyName">The name of the property to retrieve.</param>
    /// <returns>The value in the BackingFields stored with the given property name.</returns>
    protected T Get<T>([CallerMemberName] string propertyName = null)
    {
        lock (BackingFields)
        {
            var matchingItem = BackingFields.FirstOrDefault(x => x.Key == propertyName);

            if (matchingItem.IsDefault())
            {
                return default(T);
            }
            else
            {
                return (T)matchingItem.Value;
            }
        }
    }

    /// <summary>
    /// Called when a property value changes.
    /// </summary>
    /// <param name="propertyName">Name of the property that changed.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Saves a value into the BackingFields with a key value of the given property name. If the property value changed, OnPropertyChanged will be called.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the value being saved.</typeparam>
    /// <param name="value">The property value object being saved.</param>
    /// <param name="propertyName">The property name.</param>
    /// <returns><c>true</c> if the property value changed, otherwise <c>false</c>.</returns>
    protected bool Set<T>(T value, [CallerMemberName] string propertyName = null)
    {
        lock (BackingFields)
        {
            var matchingItem = BackingFields.FirstOrDefault(x => x.Key == propertyName);
            if (!matchingItem.IsDefault())
            {
                // is the value being set the same as what we already have persisted?
                if (EqualityComparer<T>.Default.Equals((T)matchingItem.Value, value))
                {
                    return false;
                }
                else
                {
                    // the value has changed.  so, let's remove the current persisted value from the list.
                    BackingFields.Remove(matchingItem);
                }
            }
            else
            {
                // is this the default value that is being set?  if so, nothing changed.
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    return false;
                }
            }

            // is this the default value that is being set?  if so, no need to persist it in the list.
            if (!EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                BackingFields.Add(new KeyValuePair<string, object>(propertyName, value));
            }

            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// Sets the field passed in to the given value. If the value being set is different than the current value of the field, OnProperyChanged will be called.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the value being saved.</typeparam>
    /// <param name="field">The field to be set with the given value.</param>
    /// <param name="value">The property value object being saved.</param>
    /// <param name="propertyName">The property name.</param>
    /// <returns><c>true</c> if the property value changed, otherwise <c>false</c>.</returns>
    protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }
        else
        {
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}