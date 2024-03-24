using NewsDashboard.Common;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.Windows.Input;
using System.Xml;

namespace NewsDashboard.RSS
{
    public class News_VM : BaseViewModel
    {
        #region Properties

        public string Title
        {
            get;
            set;
        } = "News";

        public string FeedURL
        {
            get;
            set;
        } = "https://rss.nytimes.com/services/xml/rss/nyt/World.xml";

        public string FeedImg
        {
            get;
            set;
        }

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

        //Prepopulated Comics:
        // http://comicfeeds.chrisbenard.net/view/dilbert/default
        // CommitStrip
        //
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

                Title = feed.Title.Text;
                FeedImg = feed?.ImageUrl?.AbsoluteUri;
                //Next step, getting Images from Comic feeds/etc.
                foreach (SyndicationItem item in feed.Items)
                {
                    FeedItems.Add(FeedItemModel.FromSyndicationItem(item));
                }
            }

            OnPropertyChanged(nameof(FeedItems));

        }
        #endregion

    }
}
