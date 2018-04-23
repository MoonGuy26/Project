using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beanify.Utils.Validations
{
    public class ContainUppercaseRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set ; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return str.Any(ch => Char.IsUpper(ch));
        }
    }
}
