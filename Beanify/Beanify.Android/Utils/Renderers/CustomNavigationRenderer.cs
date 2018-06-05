using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Beanify.Droid.Utils.Renderers;
using Beanify.Utils.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Support = Android.Support.V7.Widget;

//[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationRenderer))]
namespace Beanify.Droid.Utils.Renderers
{
    public class CustomNavigationRenderer : NavigationPageRenderer
    {

        private Support.Toolbar _toolbar;
        AppCompatTextView _titleTextView;
        LinearLayout _titleViewLayout;
        Android.Widget.FrameLayout _parentLayout;

        Drawable _originalDrawable;
        Drawable _originalToolbarBackground;
        Drawable _originalWindowContent;
        ColorStateList _originalColorStateList;
        Typeface _originalFont;

        public CustomNavigationRenderer(Context context) : base(context)
        {
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Support.Toolbar))
            {
                var lastPage = Element?.Navigation?.NavigationStack?.Last();

                /*if (_toolbar !=null)
                {
                    _toolbar.ChildViewAdded -= OnToolbarChildViewAdded;
                    var lPage = Element?.Navigation?.NavigationStack?.Last();
                    lPage.PropertyChanged -= LastPage_PropertyChanged;
                }*/

                _toolbar = (Android.Support.V7.Widget.Toolbar)child;
                _originalToolbarBackground = _toolbar.Background;

                var originalContent = (Context as Activity)?.Window?.DecorView?.FindViewById<FrameLayout>(Window.IdAndroidContent);
                if (originalContent != null)
                {
                    _originalWindowContent = originalContent.Foreground;
                }

                _parentLayout = new Android.Widget.FrameLayout(_toolbar.Context)
                {
                    LayoutParameters = new Android.Widget.FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
                };

                //Create custom title view layout
                _titleViewLayout = new Android.Widget.LinearLayout(_parentLayout.Context)
                {
                    Orientation = Android.Widget.Orientation.Vertical,
                    LayoutParameters = new Android.Widget.FrameLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent)
                };

                _titleTextView = new AppCompatTextView(_parentLayout.Context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent)
                };

                //Add title/subtitle to title view layout
                _titleViewLayout.AddView(_titleTextView);


                //Add title view layout to main layout
                _parentLayout.AddView(_titleViewLayout);

                //Add main layout to toolbar
                _toolbar.AddView(_parentLayout);

                _toolbar.ChildViewAdded += OnToolbarChildViewAdded;

                lastPage.PropertyChanged += LastPage_PropertyChanged;
            }
        }

        private void LastPage_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var page = sender as Page;

            if (e.PropertyName == CustomNavigationPage.TitleFontTypeProperty.PropertyName)
            {
                UpdateToolbarTextFontType(_titleTextView, CustomNavigationPage.GetTitleFontType(page));

            }

        }

        void UpdateToolbarTextFontType(AppCompatTextView textView, string customFont)
        {
            if (customFont != null)
            {
                var typeFace = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.ApplicationContext.Assets, customFont);
                textView.Typeface = typeFace;
            }

        }

        void UpdateToolbarTextColor(AppCompatTextView textView, Xamarin.Forms.Color? titleColor, ColorStateList defaultColorStateList)
        {
            if (titleColor != null)
            {
                textView.SetTextColor(titleColor?.ToAndroid() ?? Android.Graphics.Color.White);
            }
            else
            {
                textView.SetTextColor(defaultColorStateList);
            }
        }

        public override void OnViewRemoved(Android.Views.View child)
        {
            base.OnViewRemoved(child);
            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                if (_toolbar != null)
                {
                    var lastPage = Element?.Navigation?.NavigationStack?.Last();
                    //_toolbar.ChildViewAdded -= OnToolbarChildViewAdded;
                    lastPage.PropertyChanged -= LastPage_PropertyChanged;
                }
            }
        }

        private void OnToolbarChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            var view = e.Child.GetType();

            if (e.Child.GetType() == typeof(AppCompatTextView))
            {

                var textView = (AppCompatTextView)e.Child;
                textView.Visibility = ViewStates.Gone;
                _originalDrawable = textView.Background;
                _originalFont = textView.Typeface;
                _originalColorStateList = textView.TextColors;

                var lastPage = Element?.Navigation?.NavigationStack?.Last();
                SetupToolbarCustomization(lastPage);



            }
        }

        void SetupToolbarCustomization(Page lastPage)
        {

            if (lastPage != null && _titleViewLayout != null)
            {

                UpdateToolbarTitle(lastPage, _titleTextView, _originalFont, _originalColorStateList);


            }
        }

        void UpdateToolbarTitle(Page lastPage, AppCompatTextView titleTextView, Typeface originalFont, ColorStateList defaultColorStateList)
        {
            //Update main title color
            UpdateToolbarTextColor(titleTextView, CustomNavigationPage.GetTitleColor(lastPage), defaultColorStateList);

            UpdateToolbarTextFontType(titleTextView, CustomNavigationPage.GetTitleFontType(lastPage));
        }


    }
}