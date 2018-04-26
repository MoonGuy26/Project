using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    public class ForgotPasswordBindingModel : IModel
    {
        public string Email { get; set; }
    }
}
