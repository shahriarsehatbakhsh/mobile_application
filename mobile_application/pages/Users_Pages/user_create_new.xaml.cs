using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.SQLite.Models;
using mobile_application.SQLite.Models.Users;

namespace mobile_application.pages.Users_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_create_new : ContentPage
    {
        public user_create_new()
        {
            InitializeComponent();
        }

        private void btnSaveUser_Clicked(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtPasswordConfirm.Text)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                int is_admin = 0;
                if (this.chkAdmin.IsChecked)
                    is_admin = 1;
                else
                    is_admin = 0;

                _ = UsersSyntax.Insert(username, password, is_admin);

                ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);
            }
            else
            {
                DisplayAlert("خطا", "عدم تطابق گذرواژه", "تایید");
                return;
            }
        }

    }
}