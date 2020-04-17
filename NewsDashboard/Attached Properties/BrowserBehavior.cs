using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace NewsDashboard.AttachedProperties
{
    /// <summary>
    /// This class was copied from: https://stackoverflow.com/questions/2585782/displaying-html-from-string-in-wpf-webbrowser-control
    /// 
    /// Attached Properties--The bulk of what this class does, since we have a "ChromiumBrowser"contains a "Web Browser" control, and allows "Load HTML"
    /// as a method, but does not provide a dependency property to bind to,  this Attached Property essentially
    /// registers a customized Dependency Property which can be databound / dynamically changed.
    /// 
    /// In this application only, we're dynamically binding the web content of the RSS Feeds to the Chromium on the RSS
    /// Viewer control.
    /// 
    /// Attached properties can be used to extend controls/add customized behaviors.. 
    /// 
    /// Update:  Complications with the WPF WebBrowser(IE) lends to me switching to a Chromium Browser..
    /// 
    /// </summary>
    public static class BrowserBehavior
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(BrowserBehavior),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        [AttachedPropertyBrowsableForType(typeof(ChromiumWebBrowser))]
        public static string GetHtml(ChromiumWebBrowser d)
        {
            return (string)d.GetValue(HtmlProperty);
        }

        [AttachedPropertyBrowsableForType(typeof(ChromiumWebBrowser))]
        public static void SetHtml(ChromiumWebBrowser d, string value)
        {
            d.LoadHtml(value);
        }

        static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && d != null)
            {
                ChromiumWebBrowser chromium = d as ChromiumWebBrowser;
                string html = e.NewValue as string;

                chromium.LoadHtml(html);
            }
        }
    }
}
