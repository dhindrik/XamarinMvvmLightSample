using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinMvvmLightSample.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public RelayCommand Send
        {
            get
            {
                return new RelayCommand(() =>
                {
                        var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                        nav.NavigateTo(Views.Hello.ToString(), Name);                    
                });
            }
        }
    }
}
