using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;
using mobile_application.Services;
using mobile_application.Models;
using mobile_application.Models.Connection;

namespace mobile_application.pages.App_Setting_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class server_connection_setting_page : ContentPage
    {
        public server_connection_setting_page()
        {
            InitializeComponent();

            try
            {
                this.txtName.Text = Client.con_name;
                this.txtServer.Text = Client.con_server;
                this.txtLogin.Text = Client.con_login;
                this.txtPassword.Text = Client.con_password;
                this.txtDatabase.Text = Client.con_database;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                DisplayAlert("ثبت", "نام سرور را وارد کنید", "خطا");
                this.txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtServer.Text))
            {
                DisplayAlert("ثبت", "آدرس آی پی سرور را وارد کنید", "خطا");
                this.txtServer.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtDatabase.Text))
            {
                DisplayAlert("ثبت", "نام دوره با بانک را وارد کنید", "خطا");
                this.txtDatabase.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtLogin.Text))
            {
                DisplayAlert("ثبت", "نام کاربری را وارد کنید", "خطا");
                this.txtLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                DisplayAlert("ثبت", "گذرواژه را وارد کنید", "خطا");
                this.txtPassword.Focus();
                return;
            }



            
            int is_admin = 0;
            if (this.chkIsDefaul.IsChecked)
            {
                is_admin = 1;
            }
            else 
            {
                is_admin = 0;
            }


            Client.Set_Connection_String(this.txtServer.Text, this.txtLogin.Text, this.txtPassword.Text, this.txtDatabase.Text);
            //_ = ConnectionSyntax.Delete();
            _ = ConnectionSyntax.Insert(this.txtName.Text,this.txtServer.Text, Client.con_login, Client.con_password, Client.con_database, is_admin);


            ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);
        }

        private void btnTextConnection_Clicked(object sender, EventArgs e)
        {
            Client.Set_Connection_String(this.txtServer.Text, this.txtLogin.Text, this.txtPassword.Text, this.txtDatabase.Text);
            var r = Client.Server_Connection();
            if (r)
            {
                this.lblConnectionState.TextColor = Color.Green;
                this.lblConnectionState.Text = "آزمایش ارتباط با موفقیت انجام شد.";
            }
            else
            {
                this.lblConnectionState.TextColor = Color.Red;
                this.lblConnectionState.Text = "برقراری ارتباط با سرور با مشکل مواجه شد.";
            }
        }

        private async void btnMainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnServerList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.App_Setting_Pages.server_connection_list_page());
        }
    }
}