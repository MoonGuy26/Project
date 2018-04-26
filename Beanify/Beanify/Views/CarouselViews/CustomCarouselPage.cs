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

        private static string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sit amet egestas dui, vel ornare justo. Morbi euismod orci id massa iaculis, sit amet auctor justo interdum. Phasellus et nulla orci. Duis volutpat mattis vehicula. Donec lectus sem, suscipit eget tempus luctus, pharetra quis ante. Nulla euismod risus metus, ut volutpat urna auctor vel. Duis sit amet convallis ipsum, placerat pharetra lacus. Aliquam quis tellus sit amet magna luctus fringilla molestie et lectus. Fusce nec mollis lorem.";
        private static string img = "@drawable/Lightstart2";

        public CustomCarouselPage()
        {
            var pages = GetPages();

            NavigationPage.SetHasNavigationBar(this, false);

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
                contentPage.FinalStack.Children.Add(new CarouselPageIndicator(currentPage, totalPages, "@drawable/selected_circle.png", "@drawable/unselected_circle.png"));
            }
        }

        private ContentPage[] GetPages()
        {
            var pages = new ContentPage[] {
                new SimplePage(text,img),
                new SimplePage(text,img),
                new LastPage(text,img)
            };
            return pages;
        }
    }
}
