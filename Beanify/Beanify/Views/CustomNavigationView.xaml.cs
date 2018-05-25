using Beanify.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views
{
	public partial class CustomNavigationView : CustomNavigationPage
	{
        
        public CustomNavigationView(Page page) : base(page)
        {
            

            InitializeComponent();
        }
    }
}