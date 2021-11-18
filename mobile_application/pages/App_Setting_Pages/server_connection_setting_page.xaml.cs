using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.SQLite.Models.Connection;
using mobile_application.Helper;

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
                this.txtName.Text = Static_Loading.server_name;
                this.txtApi_Ip.Text = Static_Loading.api_ip;
                this.txtApi_Port.Text = Static_Loading.api_port;
                this.txtApi_Username.Text = Static_Loading.api_username;
                this.txtApi_Password.Text = Static_Loading.api_password;
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

            if (string.IsNullOrEmpty(this.txtApi_Ip.Text))
            {
                DisplayAlert("ثبت", "آدرس آی پی سرور را وارد کنید", "خطا");
                this.txtApi_Ip.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtApi_Port.Text))
            {
                DisplayAlert("ثبت", "شماره پورت برای اتصال به سرور را وارد کنید", "خطا");
                this.txtApi_Port.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtApi_Username.Text))
            {
                DisplayAlert("ثبت", "نام کاربری را وارد کنید", "خطا");
                this.txtApi_Username.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtApi_Password.Text))
            {
                DisplayAlert("ثبت", "گذرواژه را وارد کنید", "خطا");
                this.txtApi_Password.Focus();
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


            Static_Loading.api_url(this.txtApi_Ip.Text, this.txtApi_Port.Text);
            //_ = ConnectionSyntax.Delete();
            _ = ConnectionSyntax.Insert(this.txtName.Text,this.txtApi_Ip.Text, this.txtApi_Username.Text, this.txtApi_Password.Text, this.txtApi_Port.Text, is_admin);


            ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);
        }

        private void btnTextConnection_Clicked(object sender, EventArgs e)
        {
            //Client.Set_Connection_String(this.txtServer.Text, this.txtLogin.Text, this.txtPassword.Text, this.txtDatabase.Text);
            Static_Loading.api_url(this.txtApi_Ip.Text, this.txtApi_Port.Text);

            var r = true;
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