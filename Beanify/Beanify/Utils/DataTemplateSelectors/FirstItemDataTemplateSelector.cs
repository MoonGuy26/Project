using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.DataTemplateSelectors
{
    public class FirstItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ValidTemplate { get; set; }
        public DataTemplate InvalidTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((AbstractBaseModel)item).IsFirst ? ValidTemplate : InvalidTemplate;
        }
    }
}
