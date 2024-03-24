using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using NewsDashboard.Preferences;

namespace NewsDashboard
{
    public class MainWindow_VM
    {
        public PrefWindow_VM Preferences
        {
            get;
            set;
        }= new PrefWindow_VM();

        #region Commands
        private ICommand _showPreferences;

        public ICommand ShowPreferences
        {
            get
            {
                //Show a form... Comic list, Blog list, News List, color skin pref?
                return _showPreferences ?? (_showPreferences = new DelegateCommand(() => showPrefAction()));
            }
        }

        public void showPrefAction()
        {
            PrefWindow_View pref = new PrefWindow_View()
            {
                DataContext = Preferences,
                Owner = App.Current.MainWindow,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
            };

            pref.ShowDialog();
        }
        

        private ICommand _exitProgram;

        public ICommand ExitProgram
        {
            get
            {
                return _exitProgram ?? (_exitProgram = new DelegateCommand(() => Environment.Exit(0)));
            }
        }
        #endregion
    }
}
