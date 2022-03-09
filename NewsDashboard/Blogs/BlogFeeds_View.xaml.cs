using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace NewsDashboard.RSS
{
    /// <summary>
    /// Interaction logic for BlogFeeds_View.xaml
    /// </summary>
    public partial class BlogFeeds_View : UserControl
    {
        public BlogFeeds_View()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(
                new ProcessStartInfo("cmd", $"/c start {e.Uri.AbsoluteUri}")
                {
                    CreateNoWindow = true
                });
            e.Handled = true;

        }

        private void chromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(
              $"document.body.style.color = '#{App.Current.Resources["Text"].ToString().Substring(3, 6)}';" +
              $"document.a.style.color = 'green';");
            //{App.Current.Resources["Text"]}
        }
    }
}
