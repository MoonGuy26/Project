using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Utils.Validations
{
    public class LengthValidationRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get ; set ; }

        public int Length { get; set; }

        public LengthValidationRule(string validationMessage,int length)
        {
            ValidationMessage = validationMessage;
            Length = length;
        }

        public bool Check(T value)
        {

            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return (str.Length >= Length);
        }
    }
}
