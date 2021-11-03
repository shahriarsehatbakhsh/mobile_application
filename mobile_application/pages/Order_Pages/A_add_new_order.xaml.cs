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

        private void btnMain_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new B_add_new_object_and_menu(), true);
        }

        private void btnSelectCustomer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new customers_search_list_popup_page(), true);
        }
    }
}