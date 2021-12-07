using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.ServiceResponse;
using mobile_application.Helper;
using mobile_application.Models;
using Rg.Plugins.Popup.Extensions;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetail : ContentPage
    {
        public OrderDetail()
        {
            InitializeComponent();
        }

        private async void btnInsertOrder_Clicked(object sender, EventArgs e)
        {
            if (Header_Function.temp_header.Count == 0)
                return;

            var rHeader = Client.Insert_Order_Header(Static_Loading.central_BranchCode,
                                       Header_Function.temp_header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderCode,
                                       Header_Function.temp_header[0].TarikhBarge,
                                       Header_Function.temp_header[0].CodeMoshtari,
                                       Header_Function.temp_header[0].CodeForooshande,
                                       Header_Function.temp_header[0].CodeMosavabe,
                                       Header_Function.temp_header[0].NoeTasvie,
                                       Header_Function.temp_header[0].ModdateTasvie,
                                       Header_Function.temp_header[0].sp_GetAvailableCustomerJob,
                                       Header_Function.temp_header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial, 
                                       5,
                                       Header_Function.temp_header[0].CodeSupervisor, 
                                       Static_Loading.central_user_id,
                                       Header_Function.temp_header[0].TarikheRooz).GetAwaiter().GetResult();

            if (rHeader[0].result != "DONE")
            {
                Static_Loading.error_message = "Header Insert Error :" + rHeader[0].result;
                var pop = new mobile_application.controls.AppMessageBox("Header Insert Error", Static_Loading.error_message);
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                return;
            }
            else
                Header_Function.temp_header.Clear();

            for (int i = 0; i < Header_Function.temp_details.Count; i++)
            {
                Header_Function.temp_details[i].CodeKala = function_static.Create_Kala_Code(Header_Function.temp_details[i].CodeKala);
                var rDetail = Client.Insert_Order_Detail(Static_Loading.central_BranchCode,
                                           Header_Function.temp_details[i].ShomareBarge_Header, i + 1,
                                           Header_Function.temp_details[i].CodeAnbaar,
                                           Header_Function.temp_details[i].CodeKala,
                                           Header_Function.temp_details[i].Meghdar,
                                           Header_Function.temp_details[i].Nerkh,
                                           Header_Function.temp_details[i].Mablagh,
                                           Header_Function.temp_details[i].NoeBaste,
                                           Header_Function.temp_details[i].TedadBaste,
                                           Header_Function.temp_details[i].TedadDarHarBaste, 
                                           Static_Loading.central_user_id,
                                           Header_Function.temp_details[i].TarikhRooz,
                                           Header_Function.temp_details[i].MoshtariCode).GetAwaiter().GetResult();

                if (rDetail[0].result != "DONE")
                {
                    Static_Loading.error_message = "Detail Insert Error :" + rDetail[0].result;
                    var pop = new mobile_application.controls.AppMessageBox("Details Insert Error", Static_Loading.error_message);
                    await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                    return;
                }
            }
            Header_Function.temp_details.Clear();



        }

        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {

        }
    }
}