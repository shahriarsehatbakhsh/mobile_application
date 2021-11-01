

using Android.Content;
using Xamarin.Forms;

namespace mobile_application
{
    public partial class App : Application
    {
        public static object GlobalNavigation { get; internal set; }
        public static Context Context { get; internal set; }

        public App()
        {
            InitializeComponent();
            MainPage = new mobile_application.pages.start_page();
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