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
using mobile_application.Helper;
using Newtonsoft.Json;
using System.Net.Http;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderObjectList : ContentPage
    {
        IList<vw_code_sharh> items;
        public OrderObjectList()
        {
            InitializeComponent();
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

        anbar_search_list_popup_page frm_anbar_list;
        private async void btnSelectAnbar_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(Static_Loading.api_url() + "List/anbar_list BranchCode=" + Static_Loading.central_BranchCode) ;
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
            views.show_list = result;

            frm_anbar_list = new anbar_search_list_popup_page(views.show_list);
            frm_anbar_list.Search += Anbar_Search_Result;
            await Navigation.PushPopupAsync(frm_anbar_list, true);
        }
        private void Anbar_Search_Result(object sender, List<vw_code_sharh> e)
        {
            this.txtCodeAnbar.Text = e[0].Code.ToString();
            this.txtNameAnbar.Text = e[0].Sharh.ToString();

            items = Client.Objects_List(1).GetAwaiter().GetResult();
            this.collObjectList.ItemsSource = items;

            this.lblAnbarName.Text += this.txtNameAnbar.Text;
        }
    }
}