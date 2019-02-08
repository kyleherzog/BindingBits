using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BindingBits.Extensions;

namespace BindingBits
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        private readonly Lazy<List<KeyValuePair<string, object>>> backingFieldValues = new Lazy<List<KeyValuePair<string, object>>>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected List<KeyValuePair<string, object>> BackingFields { get => backingFieldValues.Value; }

        protected T Get<T>([CallerMemberName] string propertyName = null)
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
}
