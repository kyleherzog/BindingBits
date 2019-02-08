using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BindingBits
{
    public static class StructExentions
    {
        public static bool IsDefault<T>(this T value)
            where T : struct
        {
            return value.Equals(default(T));
        }
    }

    public abstract class ObservableObject : INotifyPropertyChanged
    {
        private Lazy<List<KeyValuePair<string, object>>> backingFieldValues = new Lazy<List<KeyValuePair<string, object>>>();

        protected List<KeyValuePair<string, object>> BackingFields { get => backingFieldValues.Value; }

        public event PropertyChangedEventHandler PropertyChanged;

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

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
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
                RaisePropertyChanged(propertyName);
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
                RaisePropertyChanged(propertyName);
                return true;
            }
        }
    }
}