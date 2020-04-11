using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace NewsDashboard.AttachedProperties
{
    /// <summary>
    /// This class was copied from: https://stackoverflow.com/questions/2585782/displaying-html-from-string-in-wpf-webbrowser-control
    /// 
    /// The method of what this code does, since WPF contains a "Web Browser" control, and allows "Navigate to String"
    /// as a method, but does not provide a dependency property to bind to,  this Attached Property essentially
    /// registers a customized Dependency Property which can be databound / dynamically changed.
    /// 
    /// In this application only, we're dynamically binding the web content of the RSS Feeds to the WebBrowser on the RSS
    /// Viewer control.
    /// 
    /// Attached properties can be used to extend controls/add customized behaviors.. Just so happens I didn't have to custom
    /// build my own. 
    /// </summary>
    public static class BrowserBehavior
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(BrowserBehavior),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtml(WebBrowser d)
        {
            return (string)d.GetValue(HtmlProperty);
        }

        public static void SetHtml(WebBrowser d, string value)
        {
            d.SetValue(HtmlProperty, value);
        }

        static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser wb = d as WebBrowser;
            if (wb != null)
            {
                wb.NavigateToString(e.NewValue as string);
            }
        }
    }
}
