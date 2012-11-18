using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windows.UI.Xaml.Data;

namespace Metro.LL.Common
{
    public class BaseViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }                
                catch( InvalidComObjectException e) 
                {
                    // no idea why it is throwing this when when an app is restored
                }
            }
        }

        public string ApplicationTitle { get; set; }

        private string _pageTitle = "";
        public string PageTitle
        {
            get { return _pageTitle; }
            set { _pageTitle = value; OnPropertyChanged("PageTitle"); }
        }

    }
}
