using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Services.Models;
using mobile_application.Services;
using Rg.Plugins.Popup.Extensions;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class shobe_search_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        List<vw_shobe_list> _Items;
        public shobe_search_list_popup_page(List<vw_shobe_list> Items)
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;

            _Items = Items;
            this.lstShobeList.ItemsSource = _Items;
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        public delegate void SearchDelegate(object sender, List<vw_shobe_list> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_shobe_list)lstShobeList.SelectedItem;
            List<vw_shobe_list> item = new List<vw_shobe_list>();
            item.Add
                (
                    new vw_shobe_list
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync();
        }

        private void lstShobeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}