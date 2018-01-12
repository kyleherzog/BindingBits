using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingBits
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        private ConcurrentDictionary<string, object> backingFieldValues = new ConcurrentDictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            return (T)backingFieldValues.GetOrAdd(propertyName, default(T));
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            var valueChanged = false;
            backingFieldValues.AddOrUpdate(
            propertyName,
            (k) =>
            {
                valueChanged = !EqualityComparer<T>.Default.Equals(default(T), (T)value);
                return value;
            }, (k, original) =>
            {
                valueChanged = !EqualityComparer<T>.Default.Equals((T)original, (T)value);
                return value;
            });

            if (valueChanged)
            {
                RaisePropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
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