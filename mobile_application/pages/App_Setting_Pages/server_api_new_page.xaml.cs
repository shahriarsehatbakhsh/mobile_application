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

            if (server_list.count() != 0)
            {

            }
        }

        private void btnSaveUser_Clicked(object sender, EventArgs e)
        {
            server_list.Add(this.txtApiName.Text, this.txtApiIP.Text, this.txtApiPort.Text, this.chkDefaul.IsChecked);
            ToastNotification.TostMessage(Static_Loading.done_message);
        }
    }
}