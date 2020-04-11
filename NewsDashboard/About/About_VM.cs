using NewsDashboard.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsDashboard.About
{
    public class About_VM : BaseViewModel
    {
        public string Title => "News Dashboard";

        public string Author => "Jeff Byrd, 2020";

        public List<string> Proficiencies
        {
            get => new List<string>
            {
                ".NET / C#",
                "Windows Presentation Foundation (WPF)",
                "Model-View-ViewModel Architecture"
            };
        }
    }
}
