using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDashboard.Preferences
{
    public class BlogProviders : ISettingsGroup
    {
        public string GroupName => "Content Providers";

        public string Name => "Blogs";

        public List<BlogProvider> Providers { get; set; }

        public BlogProvider Default { get; set; }
    }

    public struct BlogProvider
    {
        public string Label { get; set; }

        public string URL { get; set; }
    }
}

