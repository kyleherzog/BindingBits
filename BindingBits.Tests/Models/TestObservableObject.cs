using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BindingBits.Tests.Models
{
    public class TestObservableObject : ObservableObject
    {
        public const string DefaultStringValue = "default value";

        public ICollection<string> PropertiesChanged { get; } = new List<string>();

        protected override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            PropertiesChanged.Add(propertyName);
        }

        private bool _boolProperty;

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

        private string _stringProperty = DefaultStringValue;

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
    }
}
