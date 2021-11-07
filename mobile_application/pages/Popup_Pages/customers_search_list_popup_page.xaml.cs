using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Services.Models;
using mobile_application.Services;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_search_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public customers_search_list_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;

            List<vw_customers_list_get_code_shobe> Items = sp.Customers_list(1);
            this.lstCustomersList.ItemsSource = Items;
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public delegate void SearchDelegate(object sender, List<vw_customers_list_get_code_shobe> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_customers_list_get_code_shobe)this.lstCustomersList.SelectedItem;
            List<vw_customers_list_get_code_shobe> item = new List<vw_customers_list_get_code_shobe>();
            item.Add
                (
                    new vw_customers_list_get_code_shobe
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopAsync();
        }
    }
}