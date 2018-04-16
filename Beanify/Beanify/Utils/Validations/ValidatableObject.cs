using Beanify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beanify.Utils.Validations
{
    public class ValidatableObject<T> : ObservableProperty, IValidity
    {
        protected ICollection<IValidationRule<T>> _validations;
        protected T _value;
        private bool _isValid;
        private ICollection<string> _errors;

        public T Value
        {
            get { return _value; }
            set
            {

                _value = value;
                OnPropertyChanged(nameof(Value));
                Validate();

            }
        }

        public ICollection<string> Errors
        {
            get { return _errors; }
            set
            {

                _errors = value;
                OnPropertyChanged(nameof(Errors));

            }
        }

        public bool IsValid
        {
            get { return _isValid; }
            set
            {

                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public ICollection<IValidationRule<T>> Validations { get => _validations; set => _validations = value; }

        public ValidatableObject()
        {
            Validations = new List<IValidationRule<T>>();
            Errors = new List<string>();
        }

        public bool Validate()
        {
            Errors.Clear();
            IEnumerable<string> errors = _validations
                .Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;

        }
    }
}
