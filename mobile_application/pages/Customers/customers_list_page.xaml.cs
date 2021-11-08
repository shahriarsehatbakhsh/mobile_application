using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.modules;
using System.Windows.Input;
using Expandable;
using mobile_application.Services.Models;
using mobile_application.Services;

namespace mobile_application.pages.Customers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_list_page : ContentPage
    {
        public customers_list_page()
        {
            InitializeComponent();
            this.BindingContext = new main_menu_list();
            List<vw_customers_list_get_code_shobe> Items = sp.Customers_list(1);
            CustomersList.ItemsSource = Items;
        }


        private async void btnCreateCustomer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.Customers.customer_add_new_page(), true);
        }

        //private ICommand _tapCommand;
        //public ICommand TapCommand => _tapCommand ?? (_tapCommand = new Command(p =>
        //{
        //    DisplayAlert("Tapped", p.ToString(), "Ok");
        //}));

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    expandableView.StatusChanged += OnStatusChanged;
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    expandableView.StatusChanged -= OnStatusChanged;
        //}

        //private async void OnStatusChanged(object sender, StatusChangedEventArgs e)
        //{
        //    var rotation = 0;
        //    switch (e.Status)
        //    {
        //        case ExpandStatus.Collapsing:
        //            break;
        //        case ExpandStatus.Expanding:
        //            rotation = 180;
        //            break;
        //        default:
        //            return;
        //    }

        //    await arrow.RotateTo(rotation, 200, Easing.CubicInOut);
        //}
    }
}