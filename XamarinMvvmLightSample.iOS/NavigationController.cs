using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinMvvmLightSample.iOS
{
	partial class NavigationController : UINavigationController
	{
		public NavigationController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationBar.Translucent = false;
            NavigationBar.BarTintColor = UIColor.LightGray;
            
        }
    }
}
