using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beanify.iOS.Utils.Renderers;
using Beanify.Utils.Controls;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace Beanify.iOS.Utils.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as CustomViewCell;
            if(view.IsSelectable)
            {
                cell.SelectedBackgroundView = new UIView
                {
                    BackgroundColor = view.SelectedBackgroundColor.ToUIColor(),
                };  
            }
            else
            {
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            }


            return cell;
        }
    }
}