using Foundation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using XamarinMvvmLightSample.Core.ViewModels;
using GalaSoft.MvvmLight.Helpers;

namespace XamarinMvvmLightSample.iOS
{
	partial class HelloViewController : ControllerBase
	{
        public HelloViewModel ViewModel
        {
            get; private set;
        }

		public HelloViewController (IntPtr handle) : base (handle)
        {
            ViewModel = ServiceLocator.Current.GetInstance<HelloViewModel>();
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            ViewModel.Name = NavigationParameter.ToString();

            this.SetBinding(() => ViewModel.Name, () => Name.Text);
        }
    }
}
