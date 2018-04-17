using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Views.CarouselViews
{
    class CustomCarouselPage : CarouselPage
    {
        private int totalPages;
        private int currentPage;

        public CustomCarouselPage()
        {
            var pages = GetPages();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetMenu(this, new Menu());

            totalPages = pages.Length;

            this.ChildAdded += MyCarouselPage_ChildAdded;

            for (int i = 0; i < totalPages; i++)
            {
                currentPage = i;
                this.Children.Add(pages[i]);
            }
        }

        void MyCarouselPage_ChildAdded(object sender, ElementEventArgs e)
        {
            var contentPage = e.Element as ICarouselable;

            if (contentPage != null)
            {
                contentPage.FinalStack.Children.Add(new CarouselPageIndicator(currentPage, totalPages, "https://xamarinhelp.com/wp-content/uploads/2016/04/selected_circle.png", "https://xamarinhelp.com/wp-content/uploads/2016/04/unselected_circle.png"));
            }
        }

        private ContentPage[] GetPages()
        {
            var pages = new ContentPage[] { new Page1(), new Page2(), new Page1(), new Page2(), new Page3() };
            return pages;
        }
    }
}
