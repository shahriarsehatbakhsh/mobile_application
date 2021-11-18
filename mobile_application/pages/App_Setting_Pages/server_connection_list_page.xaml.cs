using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Client;
using mobile_application.SQLite.Models.Connection;

namespace mobile_application.pages.App_Setting_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class server_connection_list_page : ContentPage
    {
        public server_connection_list_page()
        {
            InitializeComponent();

            fill_connection_list_view();
        }

        private void fill_connection_list_view()
        {
            List<tb_Connection> Items = ConnectionSyntax.Gets();
            this.lstServerList.ItemsSource = Items;
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                var select_item = (tb_Connection)this.lstServerList.SelectedItem;
                ConnectionSyntax.Delete(select_item.Id);
                ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDefault_Clicked(object sender, EventArgs e)
        {
            try
            {
                var select_item = (tb_Connection)this.lstServerList.SelectedItem;
                ConnectionSyntax.Set_DeActive_All();
                ConnectionSyntax.Set_Active_Connection(select_item.Id);

                //Client.Set_Connection_String(select_item.Id);

                ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);

                fill_connection_list_view();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}