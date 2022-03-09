using NewsDashboard.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;

namespace NewsDashboard.Preferences
{
    public class PrefWindow_VM : BaseViewModel
    {
        List<ISettingsGroup> settingGroups = new List<ISettingsGroup>();

        public PrefWindow_VM()
        {
            settingGroups.Add(new ThemeSettings());

            SelectedSettings = settingGroups[0];//Default view
        }


        public ICollectionView SettingGroups
        {
            get
            {
                var settingList= CollectionViewSource.GetDefaultView(settingGroups);
                
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
