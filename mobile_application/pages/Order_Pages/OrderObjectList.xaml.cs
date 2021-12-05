using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.ServiceResponse;
using Rg.Plugins.Popup.Extensions;
using mobile_application.Models;
using mobile_application.pages.Popup_Pages;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderObjectList : ContentPage
    {
        IList<vw_code_sharh> items;
        public OrderObjectList()
        {
            InitializeComponent();
            items = Client.Objects_List().GetAwaiter().GetResult();
            //this.collView.ItemsSource = items;
            this.collObjectList.ItemsSource = items;
        }

        vw_code_sharh _select_item;
        private async void txtObject_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var objCode = items.Where(o => o.Sharh == label.Text).FirstOrDefault().Code;

            _select_item = new vw_code_sharh { Code = objCode, Sharh = label.Text };
            await Navigation.PushPopupAsync(new add_object_popup_page(_select_item), true);
        }


        private async void collObjectList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var select_item = (vw_code_sharh)this.collObjectList.SelectedItem;
            await Navigation.PushPopupAsync(new add_object_popup_page(select_item), true);
        }
    }
}