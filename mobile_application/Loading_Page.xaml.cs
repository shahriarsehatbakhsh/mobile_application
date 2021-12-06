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
using mobile_application.pages.Users_Pages;
using mobile_application.Helper;
using mobile_application.pages.App_Setting_Pages;

namespace mobile_application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AnimateCarousel();


            //var r = ConnectionSyntax.Count();
            server_list.Init();
            if (server_list.defaul_server == null)
            {
                //this.lblConnection.IsVisible = true;
                Static_Loading.Is_Set_ConnectionString = false;
                this.btnSingout.BackgroundColor = Color.Red;
            }
            else
            {
                //var a = ConnectionSyntax.Get_Active_Database_Connection_Id();
                //Client.Set_Connection_String(a);
                //Static_Loading.api_ip = server_list.defaul_server.IP;
                //Static_Loading.api_port = server_list.defaul_server.Port;

                Static_Loading.api_url(server_list.defaul_server.IP, server_list.defaul_server.Port);
                Static_Loading.Is_Set_ConnectionString = true;
                this.btnSingout.BackgroundColor = Color.White;
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


            //var count = UsersSyntax.Count();
            var count = server_list.count(); //load count of service api list

            //if (count == 0)
            //{ }
            //else
            //    await Navigation.PushAsync(new user_login_page(), true);

            //string a = string.Format("Found '{0}' stock items.", count);
            //App.Current.MainPage = new NavigationPage(new user_login_page());
            //await Navigation.PushAsync(new user_login_page(), true);
        }

        private async void btnSingout_Clicked(object sender, EventArgs e)
        {
            //try
            //{
            //    await Browser.OpenAsync("https://www.paya.ws/", BrowserLaunchMode.SystemPreferred);
            //}
            //catch (Exception ex)
            //{
            //    // An unexpected error occured. No browser may be installed on the device.
            //}
            await Navigation.PushAsync(new server_api_new_page(), true);

        }
    }
}