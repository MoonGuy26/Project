using Beanify.Models;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.DataTemplateSelectors
{
    public class CarouselDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ButtonPageTemplate { get; set; }
        public DataTemplate CommonPageTemplate{ get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            ButtonPageTemplate = new DataTemplate(typeof(CarouselCellView));
            CommonPageTemplate = new DataTemplate(typeof(CarouselCellView));
            return (item is ButtonCarouselPageModel) ? ButtonPageTemplate : CommonPageTemplate;
        }
    }
}
