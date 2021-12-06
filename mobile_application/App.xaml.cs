
using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application
{
    public partial class App : Application
    {
        public static Context Context { get; internal set; }

        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new mobile_application.pages.home_page());
            Device.SetFlags(new[] {"MediaElement_Experimential","Brush_Experimential"});
            Device.SetFlags(new string[] { "Markup_Experimental" });


            MainPage = new Login();
            //MainPage = new mobile_application.Interfaces.Master();


            //MainPage = new Page1();
            //MainPage = new LoginMode();
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