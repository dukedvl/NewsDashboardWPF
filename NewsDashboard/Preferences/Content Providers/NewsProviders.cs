using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDashboard.Preferences
{
    public class NewsProviders : ISettingsGroup
    {
        public string GroupName => "Content Providers";

        public string Name => "News";

        public List<NewsProvider> Providers { get; set; }

        public NewsProvider Default { get; set; }
    }

    public struct NewsProvider
    {
        public string Label { get; set; }

        public string URL { get; set; }
    }
}
