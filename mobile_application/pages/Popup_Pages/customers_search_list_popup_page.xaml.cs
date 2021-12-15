using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Models;
using Rg.Plugins.Popup.Extensions;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using mobile_application.Helper;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_search_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        
        public customers_search_list_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;
            Loadin_Form();
        }

        private async void Loadin_Form()
        {
            var result = await Services.Service.Customers_List(Static_Loading.central_BranchCode);
            List<vw_customers_list> Items = result;
            this.lstCustomersList.ItemsSource = Items;
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        public delegate void SearchDelegate(object sender, List<vw_customers_list> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_customers_list)this.lstCustomersList.SelectedItem;
            List<vw_customers_list> item = new List<vw_customers_list>();
            item.Add
                (
                    new vw_customers_list
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync();
        }

        private async void lstCustomersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.lstCustomersList.SelectedItem == null)
                return;
            var select_item = (vw_customers_list)this.lstCustomersList.SelectedItem;
            List<vw_customers_list> item = new List<vw_customers_list>();
            item.Add
                (
                    new vw_customers_list
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync();
        }

        private void txtSearchObject_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}