using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.ViewModels
{
    public class SecondPageViewModel:BaseViewModel
    {
        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public SecondPageViewModel()
        {
            Text = "Test test tes. Test test tes. Test test tes. Test test tes. " +
                "Test test tes. Test test tes. Test test tes. Test test tes. " +
                "Test test tes. Test test tes. Test test tes. Test test tes. " +
                "Test test tes. Test test tes. Test test tes. Test test tes. " +
                "Test test tes. Test test tes. Test test tes. Test test tes. " +
                "Test test tes. Test test tes. Test test tes. Test test tes. ";
            ImagePath = "Lightstart1.jpg";
        }
    }
}
