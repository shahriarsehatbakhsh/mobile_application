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
    public partial class server_api_new_page : ContentPage
    {

        public server_api_new_page()
        {
            InitializeComponent();

            server_list.Init();

            if (server_list.defaul_server == null)
                return;

            this.txtApiName.Text = server_list.defaul_server.Name;
            this.txtApiIP.Text = server_list.defaul_server.IP;
            this.txtApiPort.Text = server_list.defaul_server.Port;
            this.chkDefaul.IsChecked = server_list.defaul_server.Default;
        }

        private void btnSaveUser_Clicked(object sender, EventArgs e)
        {
            server_list.Add(this.txtApiName.Text, this.txtApiIP.Text, this.txtApiPort.Text, this.chkDefaul.IsChecked);
            ToastNotification.TostMessage(Static_Loading.done_message);
        }

        private async void btnListServer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mobile_application.pages.App_Setting_Pages.server_api_list_page());
        }
    }
}