using NewsDashboard.Common;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Windows.Input;
using System.Xml;

namespace NewsDashboard.RSS
{
    public class RSSFeeds_VM : BaseViewModel
    {
        #region Properties

        public string Title => "RSS Feeds";

        public string FeedURL
        {
            get;
            set;
        }= "http://blog.cleancoder.com/atom.xml";

        public List<SyndicationItem> FeedItems
        {
            get;
            set;
        }
        
        public SyndicationItem SelectedFeedItem
        {
            get;
            set;
        }

        #endregion

        #region Commands

        private ICommand _loadFeed;

        public ICommand LoadFeed
        {
            get
            {
                return _loadFeed ?? (_loadFeed = new DelegateCommand(() => LoadAction()));
            }
        }

        private void LoadAction()
        {
            using (XmlReader reader = XmlReader.Create(FeedURL))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                FeedItems = feed.Items.ToList();
            }
            
        }
        #endregion

    }
}
