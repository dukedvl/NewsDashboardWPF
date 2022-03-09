using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewsDashboard.News
{
    /// <summary>
    /// Interaction logic for News_View.xaml
    /// </summary>
    public partial class News_View : UserControl
    {
        public News_View()
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

        private void browser_Loaded(object sender, LoadingStateChangedEventArgs e)
        {
            browser.ExecuteScriptAsyncWhenPageLoaded(
                $"document.body.style.color = '#{App.Current.Resources["Text"].ToString().Substring(3,6)}';" +
                $"document.a.style.color = 'green';");
            //{App.Current.Resources["Text"]}
        }
    }
}
