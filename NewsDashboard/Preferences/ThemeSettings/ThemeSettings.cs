using NewsDashboard.Common;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NewsDashboard.Preferences
{
    public class ThemeSettings : BaseViewModel, ISettingsGroup
    {
        public string GroupName
        {
            get => "Themes";
        }

        public string Name
        {
            get => "Theme";
        }

        public List<string> Themes
        {
            get;
            set;
        } = new List<string> { "Light", "Dark" };

        public string SelectedTheme
        {
            get;
            set;
        }

        private ICommand _applyTheme;
        public ICommand ApplyTheme
        {
            get
            {
                return _applyTheme ?? (_applyTheme = new DelegateCommand(() => applyThemeAction()));
            }
        }

        private void applyThemeAction()
        {
            string themeURI;
            if (SelectedTheme == "Light")
            {
                themeURI = "Styles/Themes/LightTheme.xaml";
            }
            else
            {
                themeURI = "Styles/Themes/DarkTheme.xaml";
            }
            var app = (App)Application.Current;
            app.ChangeTheme(new Uri(themeURI, UriKind.Relative));
          
        }
    }
}

