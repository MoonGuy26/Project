using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Models
{
    public abstract class AbstractBaseModel:IModel
    {
        public int Id { get; set; }
    }
}
