using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Models;
using Rg.Plugins.Popup.Extensions;
using mobile_application.Helper;
using mobile_application.Services;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class supervizer_list_search_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public supervizer_list_search_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;
            Loadin_Form();
        }

        private async void Loadin_Form()
        {
            var result = await Service.Supervizer_List(Static_Loading.central_user_id, Static_Loading.central_BranchCode);
            List<vw_supervizer_list> Items = result;
            this.lstSupervizerList.ItemsSource = Items;
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        public delegate void SearchDelegate(object sender, List<vw_supervizer_list> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_supervizer_list)this.lstSupervizerList.SelectedItem;
            List<vw_supervizer_list> item = new List<vw_supervizer_list>();
            item.Add
                (
                    new vw_supervizer_list
                    {
                        Code = select_item.Code,
                        Sharh = select_item.Sharh
                    }
                );
            Search(sender, item);
            await Navigation.PopPopupAsync();
        }

        private async void lstSupervizerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.lstSupervizerList.SelectedItem == null)
                return;

            var select_item = (vw_supervizer_list)this.lstSupervizerList.SelectedItem;
            List<vw_supervizer_list> item = new List<vw_supervizer_list>();
            item.Add
                (
                    new vw_supervizer_list
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