using com.teenage_period.nedkely.Services;
using com.teenage_period.nedkely.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace com.teenage_period.nedkely
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
