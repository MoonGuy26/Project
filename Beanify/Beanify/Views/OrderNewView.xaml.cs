using Beanify.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderNewView : ContentPage
	{

        static private int capacity = 100;
        private List<int> picker_list = new List<int>(capacity);

        public OrderNewView ()
		{
			InitializeComponent ();
            picker_list = ListInitializer(picker_list);
            quantity_picker.ItemsSource = picker_list;
            
		}

        private List<int> ListInitializer(List<int> list)
        {
            for (int i = 1; i <= capacity; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}