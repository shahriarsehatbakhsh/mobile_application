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
    public partial class mosavabe_search_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public mosavabe_search_list_popup_page(List<vw_code_sharh> Items)
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;
            this.lstMosavabeList.ItemsSource = Items;
        }

        private async void Loadin_Form()
        {
            try
            {
                
                
                
            }
            catch (Exception ex)
            {
                var pop = new mobile_application.controls.AppMessageBox("خطا", ex.Message );
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                throw;
            }
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        public delegate void SearchDelegate(object sender, List<vw_code_sharh> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_code_sharh)this.lstMosavabeList.SelectedItem;
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
            await Navigation.PopPopupAsync();
        }

        private async void lstMosavabeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.lstMosavabeList.SelectedItem == null)
                return;

            var select_item = (vw_code_sharh)this.lstMosavabeList.SelectedItem;
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
            await Navigation.PopPopupAsync();
        }
    }
}