using System;
using System.Collections.Generic;
using System.Text;
using Beanify.ViewModels;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Beanify.Serialization
{
    public static class LocalStorageSettings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault("Email", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Email", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string LastViewModel
        {
            get
            {
                return AppSettings.GetValueOrDefault("LastViewModel","HomeCarouselViewModel");
            }
            set
            {
                AppSettings.AddOrUpdateValue("LastViewModel", value);
            }
        }

    }
        
}
