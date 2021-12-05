using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class code_sharh_search_list_popup_page : PopupPage
    {

        List<vw_code_sharh> _Items;
        public code_sharh_search_list_popup_page(List<vw_code_sharh> Items)
        {
            InitializeComponent();

            this.CloseWhenBackgroundIsClicked = true;

            _Items = Items;
            this.lstShobeList.ItemsSource = _Items;
        }


        public delegate void SearchDelegate(object sender, List<vw_code_sharh> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_code_sharh)lstShobeList.SelectedItem;
            List<vw_code_sharh> item = new List<vw_code_sharh>();
            item.Add
                (
                    new vw_code_sharh
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync(true);
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }

        private async void lstShobeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.lstShobeList.SelectedItem == null)
                return;

            var select_item = (vw_code_sharh)lstShobeList.SelectedItem;
            List<vw_code_sharh> item = new List<vw_code_sharh>();
            item.Add
                (
                    new vw_code_sharh
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync(true);
        }
    }
}