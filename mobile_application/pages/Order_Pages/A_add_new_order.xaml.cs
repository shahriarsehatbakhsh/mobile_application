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
            App.Current.MainPage = new AppShell();
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new B_add_new_object_and_menu();
        }

        private void btnSelectCustomer_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new customers_list_popup_page();
        }
    }
}