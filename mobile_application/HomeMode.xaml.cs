using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Helper;
using mobile_application.pages.Order_Pages;
using mobile_application.pages.App_Setting_Pages;
using mobile_application.pages.Users_Pages;

namespace mobile_application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMode : ContentPage
    {
        public HomeMode()
        {
            InitializeComponent();

            if (Static_Loading.current_user == null)
            {
                Navigation.PushAsync(new MainPage());
                return;
            }

            //this.BindingContext = new main_menu_list();
            mnusqlCommand = new Command(connection_setting_page_click);
            Navigation.RemovePage(new MainPage());
            Navigation.RemovePage(new user_login_page());
        }

        public ICommand mnusqlCommand { private set; get; }
        private async void connection_setting_page_click()
        {
            await Navigation.PushAsync(new server_connection_setting_page());
        }

        private async void lblNewOrder_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new A_add_new_order());
        }
    }
}