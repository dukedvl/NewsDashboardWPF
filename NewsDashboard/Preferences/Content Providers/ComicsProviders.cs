using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDashboard.Preferences
{
    public class ComicsProviders : ISettingsGroup
    {
        public string GroupName => "Content Providers";

        public string Name => "Comics";

        public List<ComicProvider> Providers { get; set; }

        public ComicProvider Default { get; set; }

    }

    public struct ComicProvider
    {
        public string Label { get; set; }

        public string URL { get; set; }
    }
}
