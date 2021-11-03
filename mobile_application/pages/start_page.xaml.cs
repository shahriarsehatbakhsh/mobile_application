using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.pages.Users_Pages;
using mobile_application.Models;
using mobile_application.Services;

namespace mobile_application.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class start_page : ContentPage
    {
        public start_page()
        {
            InitializeComponent();

            var r = ConnectionSyntax.Count();
            if (r == 0)
            {
                this.lblConnection.IsVisible = true;
            }
            else
            {
                var a = ConnectionSyntax.Get_Active_Database_Connection_Id();
                Client.Set_Connection_String(r);
            }
        }

        private async void btnStart_Clicked(object sender, EventArgs e)
        {
            //this.IsBusy = true;
            //System.Threading.Thread.Sleep(2000);
            //this.IsBusy = false;

            var count = UsersSyntax.Count();

            if (count == 0)
                //App.Current.MainPage = new user_create_new();
                await Navigation.PushAsync(new user_create_new(),true);
            
            else
                //App.Current.MainPage = new user_login_page();
                await Navigation.PushAsync(new user_login_page(),true);

            //string a = string.Format("Found '{0}' stock items.", count);
            //App.Current.MainPage = new NavigationPage(new user_login_page());
            //await Navigation.PushAsync(new user_login_page(), true);
        }
    }
}