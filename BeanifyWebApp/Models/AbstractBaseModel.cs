using System;
using System.Collections.Generic;
using System.Text;

namespace BeanifyWebApp.Models
{
    public abstract class AbstractBaseModel:IModel
    {
        public int Id { get; set; }
    }
}
