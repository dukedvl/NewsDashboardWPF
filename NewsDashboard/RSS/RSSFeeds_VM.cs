using NewsDashboard.Common;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;

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
        } = "http://blog.cleancoder.com/atom.xml";

        public ObservableCollection<FeedItemModel> FeedItems
        {
            get;
            set;
        } = new ObservableCollection<FeedItemModel>();

        public FeedItemModel SelectedFeedItem
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
            FeedItems?.Clear();
            SelectedFeedItem = null;

            using (XmlReader reader = XmlReader.Create(FeedURL))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                //Next step, getting Images from Comic feeds/etc.
                foreach (SyndicationItem item in feed.Items)
                {
                    FeedItemModel model = new FeedItemModel()
                    {
                        FeedItem = item
                    };

                    model.ImageURL =
                        (from SyndicationElementExtension ext in item.ElementExtensions
                         let Extension = ext.GetObject<XElement>()
                         where Extension?.Name?.LocalName == "encoded" &&
                         !string.IsNullOrEmpty(Extension?.Value)
                         select Extension.Value).FirstOrDefault();

                    FeedItems.Add(model);
                }
            }

            OnPropertyChanged(nameof(FeedItems));

        }
        #endregion
      
    }
}
