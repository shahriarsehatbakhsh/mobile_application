using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Helper;

namespace mobile_application.pages.App_Setting_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class server_api_list_page : ContentPage
    {
        public server_api_list_page()
        {
            InitializeComponent();
            lstApiServerList.ItemsSource = server_list.servers_list;
        }

        private void btnDefault_Clicked(object sender, EventArgs e)
        {
            var item = (api_table)lstApiServerList.SelectedItem;
            server_list.Change_Default(item);
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            var item = (api_table)lstApiServerList.SelectedItem;
            server_list.Delete(item);
        }

        private async void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            Static_Loading.api_url(server_list.defaul_server.IP, server_list.defaul_server.Port);
            await Navigation.PopAsync(true);
        }
    }
}