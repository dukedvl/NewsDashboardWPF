using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NewsDashboard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {

            //Initialize WebBrowser
            if (!Cef.IsInitialized)
            {
                var settings = new CefSettings()
                {
                    CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                             "CefSharp\\Cache")
                };
                settings.CefCommandLineArgs.Add("prefers-color-scheme", "true");
                settings.CefCommandLineArgs.Add("default-encoding", "UTF-8");
                
                Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            }
        }

        public void ChangeTheme(Uri uri)
        {
            ResourceDictionary themeSwap = (from ResourceDictionary rd in Application.Current.Resources.MergedDictionaries where rd.Source.OriginalString.Contains("Theme") select rd).First();
            Application.Current.Resources.MergedDictionaries.Remove(themeSwap);
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }
    }

}
