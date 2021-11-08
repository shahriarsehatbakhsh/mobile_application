
using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application
{
    public partial class App : Application
    {
        public static object GlobalNavigation { get; internal set; }
        public static Context Context { get; internal set; }

        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new mobile_application.pages.home_page());
            Device.SetFlags(new[] {"MediaElement_Experimential","Brush_Experimential"});

            //var rootPage = new NavigationPage(new mobile_application.pages.home_page());
            //GlobalNavigation = rootPage.Navigation;
            //MainPage = rootPage;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}