using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Services;
using mobile_application.Services.Models;
using System.Diagnostics;
using mobile_application.pages.Order_Pages;
using mobile_application.Helper;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class objects_search_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public objects_search_list_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;

            List<vw_objects_list_get_object_name> Items = sp.Objects_List_Get_Object_Names("");
            this.lstObjectsList.ItemsSource = Items;
        }

        private void btnCloseMe_Clicked(object sender, EventArgs e)
        {

        }


        public mobile_application.Helper.Item Item { get; set; }
        private async void btnSelectItem_Clicked(object sender, EventArgs e)
        {
            var item = this.lstObjectsList.SelectedItem;

            _navigationResut = item;
            await Navigation.PopModalAsync();
            
        }

        private void txtSearchObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                
                string objName = this.txtSearchObject.Text;
                List<vw_objects_list_get_object_name> Items = sp.Objects_List_Get_Object_Names(objName);
                this.lstObjectsList.ItemsSource = Items;
            }
            catch (Exception)
            {

                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}