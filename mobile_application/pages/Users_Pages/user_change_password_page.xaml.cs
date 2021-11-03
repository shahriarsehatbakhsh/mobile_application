using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application.pages.Users_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_change_password_page : ContentPage
    {
        public user_change_password_page()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Clicked(object sender, EventArgs e)
        {
            ToastNotification.TostMessage(" ثبت موفقیت آمیز بود");
        }
    }
}