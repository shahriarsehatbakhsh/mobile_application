using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.pages.Popup_Pages;
using Rg.Plugins.Popup.Exceptions;
using System.ComponentModel;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class A_add_new_order : ContentPage
    {
        public A_add_new_order()
        {
            InitializeComponent();
        }

        private async void btnMain_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

        private async void btnNext_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new B_add_new_object_and_menu(), true);
        }

        private async void btnSelectCustomer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new customers_search_list_popup_page(), true);
        }

        private async void btnSelectSeller_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new seller_list_search_popup_page(), true);
        }

        private async void btnSelectShobe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new shobe_search_list_popup_page(), true);
        }
    }
}