
using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application
{
    public partial class App : Application
    {
        public static Context Context { get; internal set; }
        public static INavigation GlobalNavigation { get; private set; }

        public App()
        {
            InitializeComponent();
            
            Device.SetFlags(new[] {"MediaElement_Experimential","Brush_Experimential"});
            Device.SetFlags(new string[] { "Markup_Experimental" });

            var rootPage = new NavigationPage(new Login());
            GlobalNavigation = rootPage.Navigation;
            MainPage = rootPage;
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