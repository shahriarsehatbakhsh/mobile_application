using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using Xamarin.Essentials;
using mobile_application.SQLite.Models;
using mobile_application.pages.Users_Pages;

namespace mobile_application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AnimateCarousel();


            var r = ConnectionSyntax.Count();
            if (r == 0)
            {
                //this.lblConnection.IsVisible = true;
                Client.Is_Set_ConnectionString = false;
            }
            else
            {
                var a = ConnectionSyntax.Get_Active_Database_Connection_Id();
                Client.Set_Connection_String(a);
                Client.Is_Set_ConnectionString = true;
            }
        }

        Timer timer;

        private void AnimateCarousel()
        {
            
            timer = new Timer(5000) { AutoReset = true, Enabled = true };
            timer.Elapsed += (s, e) =>
            {
                if (BgVideo.CurrentState != Xamarin.CommunityToolkit.UI.Views.MediaElementState.Playing)
                    BgVideo.Play();

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (this.cvOnboarding.Position == 2)
                    {
                        this.cvOnboarding.Position = 0;
                        return;
                    }

                    this.cvOnboarding.Position += 1;

                });

            };
            //throw new NotImplementedException();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            //this.IsBusy = true;
            //System.Threading.Thread.Sleep(2000);
            //this.IsBusy = false;

            var count = UsersSyntax.Count();

            if (count == 0)
                //App.Current.MainPage = new user_create_new();
                await Navigation.PushAsync(new user_create_new(), true);

            else
                //App.Current.MainPage = new user_login_page();
                await Navigation.PushAsync(new user_login_page(), true);

            //string a = string.Format("Found '{0}' stock items.", count);
            //App.Current.MainPage = new NavigationPage(new user_login_page());
            //await Navigation.PushAsync(new user_login_page(), true);
        }

        private async void btnSingout_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.paya.ws/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}