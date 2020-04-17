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

namespace NewsDashboard.RSS
{
    /// <summary>
    /// Interaction logic for RSSFeeds.xaml
    /// </summary>
    public partial class RSSFeeds_View : UserControl
    {
        public RSSFeeds_View()
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
    }
}
