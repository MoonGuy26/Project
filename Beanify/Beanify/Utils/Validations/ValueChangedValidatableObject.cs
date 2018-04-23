using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Utils.Validations
{
    public class ValueChangedValidatableObject<T> : ValidatableObject<T>
    {
        public override T Value
        {
            get { return _value; }
            set
            {

                _value = value;
                OnPropertyChanged(nameof(Value));
                Validate();

            }
        }
    }
}
