using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    public abstract class AbstractBaseModel:IModel
    {
        public string Id { get; set; }
    }
}
