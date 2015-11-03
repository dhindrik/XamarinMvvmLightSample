using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using XamarinMvvmLightSample.Core;
using Autofac;
using XamarinMvvmLightSample.Core.ViewModels;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Helpers;

namespace XamarinMvvmLightSample.Droid
{
    [Activity(Label = "XamarinMvvmLightSample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ActivityBase
    {
        private static bool _isInitialized;

        public MainViewModel ViewModel { get; private set; }

        public EditText Text { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if(!_isInitialized)
            {
                var nav = new NavigationService();            
                nav.Configure(Core.Views.Main.ToString(), typeof(MainActivity));
                nav.Configure(Core.Views.Hello.ToString(), typeof(HelloActivity));

                var builder = new ContainerBuilder();
                builder.RegisterInstance<INavigationService>(nav);

                builder.RegisterType<MainViewModel>();
                builder.RegisterType<HelloViewModel>();

                var container = builder.Build();

                var serviceLocator = new AutofacServiceLocator(container);

                ServiceLocator.SetLocatorProvider(() => serviceLocator);
            }

            ViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.send);
            Text = FindViewById <EditText>(Resource.Id.name);

            this.SetBinding(() => ViewModel.Name,() => Text.Text, BindingMode.TwoWay);
            button.SetCommand("Click", ViewModel.Send);
            
        }
    }
}

