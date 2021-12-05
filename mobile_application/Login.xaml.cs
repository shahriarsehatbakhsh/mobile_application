using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using mobile_application.Helper;
using Xamarin.Essentials;
using mobile_application.ServiceResponse;
using Rg.Plugins.Popup.Extensions;
using System.Threading.Tasks;

namespace mobile_application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            bool s = Preferences.Get("save-password", false);
            string username = Preferences.Get("username", "");
            string password = Preferences.Get("password", "");

            this.chkSavePassword.IsChecked = s;

            if (s)
            {
                this.txtUsername.Text = username;
                this.txtPassword.Text = password;
            }
            else
            {
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
            }

            //--------------------------------------------------------------------------------------
            server_list.Init();
            if (server_list.defaul_server == null)
            {
                Static_Loading.Is_Set_ConnectionString = false;
                this.lblSetting.BackgroundColor = Color.Red;
            }
            else
            {
                Static_Loading.api_url(server_list.defaul_server.IP, server_list.defaul_server.Port);
                Static_Loading.Is_Set_ConnectionString = true;
            }
        }

        private async void LoginClick(object sender, EventArgs e)
        {
            try
            {
                this.IsBusy = true;
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                var Data = await Client.Check_User_Name_Password(this.txtUsername.Text, this.txtPassword.Text);

                if (Data == null || Data[0].result == "E")
                {
                    var pop = new mobile_application.controls.AppMessageBox("خطا", "نام کاربری یا رمز ورود به سیستم اشتباه میباشید");
                    await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                }
                else
                {
                    bool savePassword = this.chkSavePassword.IsChecked;
                    if (savePassword)
                    {
                        Preferences.Set("username", this.txtUsername.Text);
                        Preferences.Set("password", this.txtPassword.Text);
                    }
                    else
                    {
                        Preferences.Set("username", "");
                        Preferences.Set("password", "");
                    }


                    Static_Loading.central_user_id = Convert.ToInt64(Data[0].result);
                    
                    var rootPage = new NavigationPage(new mobile_application.pages.home_page());
                    //App.Current.MainPage = new mobile_application.pages.home_page();
                    App.Current.MainPage = rootPage;
                    this.IsBusy = false;
                    return;
                }
            }
            catch (Exception)
            {
                var pop = new mobile_application.controls.AppMessageBox("Error", Static_Loading.error_message);
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                throw;
            }
        }

        private void chkSavePassword_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Set("save-password", this.chkSavePassword.IsChecked);
            if (!this.chkSavePassword.IsChecked)
            {
                Preferences.Set("username", "");
                Preferences.Set("password", "");
            }
        }
    }
}