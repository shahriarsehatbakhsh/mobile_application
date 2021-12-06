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
            this.lblTitle.Text = "لیست کالاهای موجود";
        }

        vw_code_sharh _select_item;
        private async void txtObject_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var objCode = items.Where(o => o.Sharh == label.Text).FirstOrDefault().Code;

            _select_item = new vw_code_sharh { Code = objCode, Sharh = label.Text };
            await Navigation.PushPopupAsync(new add_object_popup_page(_select_item), true);
        }

       
        private async Task OpenAnimation(View view, uint length = 250)
        {
            view.RotationX = -90;
            view.IsVisible = true;
            view.Opacity = 0;
            _ = view.FadeTo(1, length);
            await view.RotateXTo(0, length);
        }

        private async Task CloseAnimation(View view, uint length = 250)
        {
            _ = view.FadeTo(0, length);
            await view.RotateXTo(-90, length);
            view.IsVisible = false;
        }

        private async void MainExpander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Xamarin.CommunityToolkit.UI.Views.Expander;
            var imgView = expander.FindByName<Grid>("ImageView");
            var detailsView = expander.FindByName<Grid>("DetailsView");



            if (expander.IsExpanded)
            {
                await OpenAnimation(imgView);
                await OpenAnimation(detailsView);
            }
            else
            {
                await CloseAnimation(detailsView);
                await CloseAnimation(imgView);
            }
        }

        private async void btnSelectObject_Clicked(object sender, EventArgs e)
        {
            var btn = sender as ImageButton;
            var code = btn.CommandParameter;
            var name = items.Where(o => o.Code == Convert.ToInt16(code)).FirstOrDefault();
            await Navigation.PushPopupAsync(new add_object_popup_page(name), true);
        }
    }
}