﻿using Beanify.Views;
using System;

namespace Beanify.Models
{

    public class DashboardNavigationViewMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Action OnClicked { get; set; }
        public Type TargetType { get; set; }

        public DashboardNavigationViewMenuItem()
        {
            TargetType = typeof(DashboardNavigationViewDetail);
        }
        
    }
}