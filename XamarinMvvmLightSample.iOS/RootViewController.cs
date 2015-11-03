using System;
using System.Drawing;

using Foundation;
using UIKit;
using XamarinMvvmLightSample.Core.ViewModels;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Helpers;

namespace XamarinMvvmLightSample.iOS
{
    public partial class RootViewController : UIViewController
    {
        public RootViewController(IntPtr handle) : base(handle)
        {
            ViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
        }

        public MainViewModel ViewModel
        {
            get;private set;
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
            this.SetBinding(() => Name.Text).
                UpdateSourceTrigger("EditingChanged").
                WhenSourceChanges(() => ViewModel.Name = Name.Text);


            Send.SetCommand("TouchUpInside", ViewModel.Send);
        }


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}