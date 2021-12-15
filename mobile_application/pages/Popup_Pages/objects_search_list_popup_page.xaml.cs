using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Models;
using System.Diagnostics;
using mobile_application.pages.Order_Pages;
using Rg.Plugins.Popup.Extensions;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using mobile_application.Helper;
using mobile_application.Services;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class objects_search_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public objects_search_list_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;
        }

        private async void Loadin_Form()
        {
            this.lstObjectsList.ItemsSource = Service.ObjectCodeName_Search(this.txtSearchObject.Text).GetAwaiter().GetResult(); 
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }


        public delegate void SearchDelegate(object sender, List<vw_code_sharh> e);
        public event SearchDelegate Search;
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var select_item = (vw_code_sharh)this.lstObjectsList.SelectedItem;
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



        private async void txtSearchObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string objName = this.txtSearchObject.Text;
                var result = await Service.Objects_List(objName);
                this.lstObjectsList.ItemsSource = result;
            }
            catch (Exception)
            {

                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void lstObjectsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.lstObjectsList.SelectedItem == null)
                return;

            var select_item = (vw_code_sharh)this.lstObjectsList.SelectedItem;
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