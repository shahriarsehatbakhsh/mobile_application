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
                //this.txtIP.Text = Client.con_server;
                //this.txtUsername.Text = Client.con_username;
                //this.txtPassword.Text = Client.con_password;
                //this.txtDBName.Text = Client.con_database;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtIP.Text))
            {
                DisplayAlert("ثبت", "آدرس آی پی سرور را وارد کنید", "خطا");
                this.txtIP.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtDBName.Text))
            {
                DisplayAlert("ثبت", "نام دوره با بانک را وارد کنید", "خطا");
                this.txtDBName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtUsername.Text))
            {
                DisplayAlert("ثبت", "نام کاربری را وارد کنید", "خطا");
                this.txtUsername.Focus();
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

            Client.Set_Connection_String(this.txtIP.Text, this.txtUsername.Text, this.txtPassword.Text, this.txtDBName.Text);
            _ = ConnectionSyntax.Insert(Client.con_server, Client.con_username, Client.con_password, Client.con_database, is_admin);
            DisplayAlert("ثبت", "ثبت با موفقیت انجام شد", "تایید");
        }

        private void btnTextConnection_Clicked(object sender, EventArgs e)
        {
            Client.Set_Connection_String(this.txtIP.Text, this.txtUsername.Text, this.txtPassword.Text, this.txtDBName.Text);
            var r = Client.Server_Connection();
            if (r)
            {
                this.lblConnectionState.TextColor = Color.Green;
                this.lblConnectionState.Text = "Connection test successfull .";
            }
            else
            {
                this.lblConnectionState.TextColor = Color.Red;
                this.lblConnectionState.Text = "Connection is close .";
            }
        }
    }
}