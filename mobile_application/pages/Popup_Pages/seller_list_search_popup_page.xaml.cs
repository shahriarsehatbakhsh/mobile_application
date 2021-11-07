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
    public partial class seller_list_search_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public seller_list_search_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;

            List<vw_seller_list> Items = sp.Seller_List(2,1);
            this.lstSellerList.ItemsSource = Items;
        }

        private void btnCloseMe_Clicked(object sender, EventArgs e)
        {

        }

        private void txtSearchObject_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSelectItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}