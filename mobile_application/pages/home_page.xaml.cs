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

            mnusqlCommand = new Command(connection_setting_page_click);
        }

        public ICommand mnusqlCommand { private set; get; }

        private  void connection_setting_page_click()
        {
        }

        private async void btnMenu01_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.Order_Pages.OrderHeader());
        }

        private async void profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.Users_Pages.user_change_password_page());
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