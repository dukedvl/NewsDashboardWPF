using NewsDashboard.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace NewsDashboard.Preferences
{
    public class PrefWindow_VM : BaseViewModel
    {
        List<ISettingsGroup> settingGroups = new List<ISettingsGroup>();

        PreferencesSerializer serializer = new PreferencesSerializer();

        readonly string _preferencesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NewsDashboard", "Settings.json");

        public PrefWindow_VM()
        {
            //Load from file if possible
            if (File.Exists(_preferencesPath))
            {

            }
            else //Initialize default
            {
                settingGroups.Add(new ThemeSettings());
                settingGroups.AddRange(new List<ISettingsGroup> { new BlogProviders(), new ComicsProviders(), new NewsProviders() });
            }

            SelectedSettings = settingGroups[0];//Default view
        }


        public ICollectionView SettingGroups
        {
            get
            {
                var settingList = CollectionViewSource.GetDefaultView(settingGroups);

                settingList.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));

                return settingList;
            }
        }

        public ISettingsGroup SelectedSettings
        {
            get;
            set;
        }

    }
}
