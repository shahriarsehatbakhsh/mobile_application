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
            if (Static_Loading.Header.Count == 0)
                return;

            var rHeader = Client.Insert_Order_Header(Static_Loading.central_BranchCode, 
                                       Static_Loading.Header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderCode, 
                                       Static_Loading.Header[0].TarikhBarge, 
                                       Static_Loading.Header[0].CodeMoshtari, 
                                       Static_Loading.Header[0].CodeForooshande, 
                                       Static_Loading.Header[0].CodeMosavabe, 
                                       Static_Loading.Header[0].NoeTasvie, 
                                       Static_Loading.Header[0].ModdateTasvie, 
                                       Static_Loading.Header[0].sp_GetAvailableCustomerJob, 
                                       Static_Loading.Header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial, 
                                       5, 
                                       Static_Loading.Header[0].CodeSupervisor, 
                                       Static_Loading.central_user_id, 
                                       Static_Loading.Header[0].TarikheRooz).GetAwaiter().GetResult();

            if (rHeader[0].result != "DONE")
            {
                Static_Loading.error_message = "Header Insert Error :" + rHeader[0].result;
                var pop = new mobile_application.controls.AppMessageBox("Header Insert Error", Static_Loading.error_message);
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                return;
            }
            else
                Static_Loading.Header.Clear();

            for (int i = 0; i < Static_Loading.Details.Count; i++)
            {
                Static_Loading.Details[i].CodeKala = function_static.Create_Kala_Code(Static_Loading.Details[i].CodeKala);
                var rDetail = Client.Insert_Order_Detail(Static_Loading.central_BranchCode, 
                                           Static_Loading.Details[i].ShomareBarge_Header, i + 1, 
                                           Static_Loading.Details[i].CodeAnbaar, 
                                           Static_Loading.Details[i].CodeKala, 
                                           Static_Loading.Details[i].Meghdar, 
                                           Static_Loading.Details[i].Nerkh, 
                                           Static_Loading.Details[i].Mablagh, 
                                           Static_Loading.Details[i].NoeBaste, 
                                           Static_Loading.Details[i].TedadBaste, 
                                           Static_Loading.Details[i].TedadDarHarBaste, 
                                           Static_Loading.central_user_id, 
                                           Static_Loading.Details[i].TarikhRooz, 
                                           Static_Loading.Details[i].MoshtariCode).GetAwaiter().GetResult();

                if (rDetail[0].result != "DONE")
                {
                    Static_Loading.error_message = "Detail Insert Error :" + rDetail[0].result;
                    var pop = new mobile_application.controls.AppMessageBox("Details Insert Error", Static_Loading.error_message);
                    await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                    return;
                }
            }
            Static_Loading.Details.Clear();



        }

        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {

        }
    }
}