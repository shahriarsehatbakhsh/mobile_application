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
using mobile_application.ServiceResponse;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class seller_list_search_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public seller_list_search_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;

            Loadin_Form();
        }

        private async void Loadin_Form()
        {
            var result = Client.Seller_List(Static_Loading.central_user_id,Static_Loading.central_BranchCode).GetAwaiter().GetResult() ;
            this.lstSellerList.ItemsSource = result;
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private void txtSearchObject_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public delegate void SearchDelegate(object sender, List<vw_seller_list> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_seller_list)this.lstSellerList.SelectedItem;
            List<vw_seller_list> item = new List<vw_seller_list>();
            item.Add
                (
                    new vw_seller_list
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync();
        }

        private async void lstSellerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.lstSellerList.SelectedItem == null)
                return;

            var select_item = (vw_seller_list)this.lstSellerList.SelectedItem;
            List<vw_seller_list> item = new List<vw_seller_list>();
            item.Add
                (
                    new vw_seller_list
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync();
        }
    }
}