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



namespace mobile_application.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home_page : ContentPage
    {
        public home_page()
        {
            InitializeComponent();

            if (Static_Loading.current_user == null)
            {
                Navigation.PushAsync(new mobile_application.pages.start_page());
                return;
            }

            //this.BindingContext = new main_menu_list();

            mnusqlCommand = new Command(connection_setting_page_click);

            Navigation.RemovePage(new start_page());
            Navigation.RemovePage(new Users_Pages.user_login_page());
        }

        private void btnOpenForm_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Forms.AddNewOrder());
            Button btn = sender as Button;
            string FormTitle = btn.Text;

            switch (FormTitle)
            {
                case "ثبت سفارشات":
                    {
                        //await Navigation.PushAsync(new mobile_application.pages.Order_Pages.A_add_new_order(), true);
                        App.Current.MainPage = new mobile_application.pages.Order_Pages.A_add_new_order();
                        break;
                    }
                case "لیست مشتری ها":
                    {
                        //await Navigation.PushAsync(new customers_list(), true);
                        break;
                    }
                case "لیست کالاها":
                    {
                        //await Navigation.PushAsync(new objects_list(), true);
                        break;
                    }
                case "گزارشات":
                    {
                        //App.Current.MainPage = new Page1();
                        break;
                    }
                case "اعلانات":
                    {
                        //App.Current.MainPage = new objects_list();
                        break;
                    }
                default:
                    break;
            }
        }


        public ICommand mnusqlCommand { private set; get; }

        private async void connection_setting_page_click()
        {
            await Navigation.PushAsync(new mobile_application.pages.App_Setting_Pages.server_connection_setting_page());
        }

        private async void btnMenu01_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new mobile_application.pages.Order_Pages.A_add_new_order();
            await Navigation.PushAsync(new mobile_application.pages.Order_Pages.A_add_new_order());
        }

        private async void mnusql_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.App_Setting_Pages.server_connection_setting_page());
        }

        private async void profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.Users_Pages.user_change_password_page());
        }

        private async void create_profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.Users_Pages.user_create_new());
        }

        private async void btnMenu02_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void btnMenu03_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.Customers.customers_list_page());
        }

        private async void btnMenu04_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.Objects.objects_list_page());
        }
    }
}