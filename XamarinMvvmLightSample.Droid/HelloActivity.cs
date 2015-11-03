using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinMvvmLightSample.Core.ViewModels;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;

namespace XamarinMvvmLightSample.Droid
{
    [Activity(Label = "HelloActivity")]
    public class HelloActivity : ActivityBase
    {
        public HelloViewModel ViewModel { get; private set; }

        public TextView Text { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ViewModel = ServiceLocator.Current.GetInstance<HelloViewModel>();
            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            var param = nav.GetAndRemoveParameter<string>(Intent);
            ViewModel.Name = param;

            SetContentView(Resource.Layout.Hello);

            Text = FindViewById<TextView>(Resource.Id.name);
            this.SetBinding(() => ViewModel.Name, () => Text.Text);
            
        }
    }
}