using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BindingBits.Tests.Models
{
    public class TestObservableObject : ObservableObject
    {
        public const string DefaultStringValue = "default value";

        private bool _boolProperty;

        private string _stringProperty = DefaultStringValue;

        public bool BoolProperty
        {
            get
            {
                return _boolProperty;
            }
            set
            {
                Set(ref _boolProperty, value);
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

        public ICollection<string> PropertiesChanged { get; } = new List<string>();

        public string StringProperty
        {
            get
            {
                return _stringProperty;
            }

            set
            {
                Set(ref _stringProperty, value);
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

        protected override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            PropertiesChanged.Add(propertyName);
        }
    }
}