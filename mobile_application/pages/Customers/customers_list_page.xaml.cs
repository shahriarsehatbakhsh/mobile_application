using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Expandable;
using mobile_application.Helper;
using mobile_application.Service.Models;
using Rg.Plugins.Popup.Extensions;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;

namespace mobile_application.pages.Customers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_list_page : ContentPage
    {
        public customers_list_page()
        {
            InitializeComponent();
            this.BindingContext = new main_menu_list();

            Loadin_Form();
        }

        private async void Loadin_Form()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(Static_Loading.api_url() + "Customers/List code_shobe=" + Static_Loading.central_BranchCode);
            List<vw_customers_list> result = JsonConvert.DeserializeObject<List<vw_customers_list>>(json);
            List<vw_customers_list> Items = result;
            if (Items == null)
            {
                var pop = new mobile_application.controls.AppMessageBox("ارتباط با سرور", "در ارتباط با سرور مشکلی بوجود آمده است");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
            }
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