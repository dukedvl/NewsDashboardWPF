using NewsDashboard.Common;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;

namespace NewsDashboard.RSS
{
    public class FeedItemModel
    {
        public SyndicationItem FeedItem
        {
            get;
            set;
        }

        public bool HasImage
        {
            get => !string.IsNullOrEmpty(ImageURL);
        }

        public string ImageURL
        {
            get;
            set;
        }

    }
}
