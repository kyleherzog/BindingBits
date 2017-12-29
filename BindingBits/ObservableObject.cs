using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BindingBits
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, object> backingFieldValues = new Dictionary<string, object>();

        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (backingFieldValues.ContainsKey(propertyName))
            {
                return (T)backingFieldValues[propertyName];
            }
            else
            {
                return default(T);
            }
        }

        protected bool Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (! backingFieldValues.ContainsKey(propertyName))
            {
                backingFieldValues.Add(propertyName, default(T));
            }

            T field = (T)backingFieldValues[propertyName];
            var result = Set(ref field, value, propertyName);
            backingFieldValues[propertyName] = field;
            return result;

        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if(EqualityComparer<T>.Default.Equals(field, value))
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

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
