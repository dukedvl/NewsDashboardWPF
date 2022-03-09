using NewsDashboard.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml.Linq;

namespace NewsDashboard.Common
{
    public class FeedItemModel
    {
        public SyndicationItem FeedItem
        {
            get;
            set;
        }

        public DateTime ItemTime
        {
            get
            {
                if (FeedItem.LastUpdatedTime.LocalDateTime != DateTime.MinValue)
                {
                    return FeedItem.LastUpdatedTime.LocalDateTime;
                }
                else
                {
                    return FeedItem.PublishDate.LocalDateTime;
                }
            }
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


        public static FeedItemModel FromSyndicationItem(SyndicationItem item)
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

            if (model.ImageURL == null)
            {
                try
                {
                    model.ImageURL = ((TextSyndicationContent)item?.Content)?.Text;
                }
                catch
                {

                }
            }
            return model;
        }
    }
}
