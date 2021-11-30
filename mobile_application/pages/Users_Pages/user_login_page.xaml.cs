using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using mobile_application.Helper;
using Xamarin.Essentials;
using mobile_application.ServiceResponse;
using Rg.Plugins.Popup.Extensions;
using System.Threading.Tasks;

namespace mobile_application.pages.Users_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_login_page : ContentPage
    {
        public user_login_page()
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
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
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


                    Static_Loading.user_id = Data[0].id;
                    Navigation.PopAsync();
                    await Navigation.PopAsync();
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

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                Debug.WriteLine("Failed to Load Item");
            }
            Entry txtUsername = sender as Entry;
            string Username = txtUsername.Text;
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

        private void txtSetting_Click(object sender, EventArgs e)
        {

        }
    }
}