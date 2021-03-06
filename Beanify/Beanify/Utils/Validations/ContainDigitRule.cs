﻿using System;
using System.Linq;

namespace Beanify.Utils.Validations
{
    public class ContainDigitRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set ; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return str.Any(ch => Char.IsDigit(ch));
        }
    }
}
