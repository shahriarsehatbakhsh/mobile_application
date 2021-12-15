using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using mobile_application.Helper;
using Xamarin.Essentials;
using mobile_application.Services;
using Rg.Plugins.Popup.Extensions;
using System.Threading.Tasks;
using mobile_application.pages.App_Setting_Pages;

namespace mobile_application.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command Login_Command { get; }

        public LoginViewModel()
        {
            Login_Command = new Command(LoginButton_Clicked);
        }

        private async void LoginButton_Clicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            try
            {
                IsBusy = true;

                server_list.Init();
                if (server_list.defaul_server == null)
                {
                    Static_Loading.Is_Set_ConnectionString = false;
                }
                else
                {
                    Service.set_api_url(server_list.defaul_server.IP, server_list.defaul_server.Port);
                    Static_Loading.Is_Set_ConnectionString = true;
                }



                var Data = await Service.Check_User_Name_Password(Username, Password);

                if (Data == null || Data[0].result == "E")
                {
                    var pop = new mobile_application.controls.AppMessageBox("خطا", "نام کاربری یا رمز ورود به سیستم اشتباه میباشید");
                    await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                }
                else
                {
                    Static_Loading.central_user_id = Convert.ToInt64(Data[0].result);
                    //var rootPage = new NavigationPage(new mobile_application.AppShell());
                    App.Current.MainPage = new mobile_application.AppShell();
                }
                IsBusy = false;
                return;
            }
            catch (Exception)
            {
                var pop = new mobile_application.controls.AppMessageBox("Error", Static_Loading.error_message);
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                throw;
            }
        }



        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
    }
}
