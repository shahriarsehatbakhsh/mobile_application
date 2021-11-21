using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Helper;
using mobile_application.SQLite.Models.Users;

namespace mobile_application.pages.Users_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_change_password_page : ContentPage
    {
        public user_change_password_page()
        {
            InitializeComponent();

            this.txtUsername.Text = Static_Loading.current_user.username;
        }

        private void btnChangePassword_Clicked(object sender, EventArgs e)
        {
            if (this.txtOldPassword.Text != Static_Loading.current_user.password)
            {
                DisplayAlert("", "خطا در گذرواژه قدیم", "تایید");
                this.txtOldPassword.Text = "";
                return;
            }

            if (this.txtNewPassword.Text != this.txtConfirmPassword.Text || this.txtNewPassword.Text == "")
            {
                DisplayAlert("", "خطا در انتخاب گذرواژه جدید", "تایید");
                this.txtNewPassword.Text = this.txtConfirmPassword.Text = "";
                return;
            }


            //UsersSyntax.Delete(Static_Loading.user_id);
            //_ = UsersSyntax.Insert(Static_Loading.current_user.username, this.txtConfirmPassword.Text, Static_Loading.current_user.is_admin);
            //UsersSyntax.Get(Static_Loading.user_id);
            ToastNotification.TostMessage(" ثبت موفقیت آمیز بود");
        }
    }
}