using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Services;
using mobile_application.Helper;
using Rg.Plugins.Popup.Extensions;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetail : ContentPage
    {
        public OrderDetail()
        {
            InitializeComponent();

            this.load_data();
        }

        async void load_data()
        {
            if (Header_Function.temp_details == null)
                return;


            var Customer_Information = await Service.customer_Information(Static_Loading.Customer_Code, Static_Loading.central_BranchCode);

            if (Customer_Information.Count > 0)
            {
                this.lblBranchName.Text = "شعبه : " + Customer_Information[0].Shobe;
                this.lblShomareSefaresh.Text = "شماره سفارش : " + Header_Function.temp_header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderCode.ToString();
                this.lblTarikhBarge.Text = "تاریخ برگه : " + Header_Function.temp_header[0].TarikhBarge.ToString();

                this.lblCustomerInfo.Text = "مشتری : " + Static_Loading.Customer_Code + " - کد مشتری : " + Static_Loading.Customer_Name;
                this.lblCustomerState.Text = "قبول";
                this.lblCustomerMessage.Text = Customer_Information[0].Message;

                this.lblCustomerTell.Text = Customer_Information[0].Tell;
                this.lblCustomerMobile.Text= Customer_Information[0].Mobile;

                this.lblCustomerAddress.Text = Customer_Information[0].Address;

                this.lblCustomerOstan.Text = Customer_Information[0].NameOstan;
                this.lblCustomerCity.Text = Customer_Information[0].NameShahr;

                this.lblCustomerMantaghe.Text = Customer_Information[0].NameMantaghe;
                this.lblCustomerMasir.Text = Customer_Information[0].NameMasir;
            }
            this.lstObjectDetails.ItemsSource = Header_Function.temp_details;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (Header_Function.temp_header.Count == 0)
                return;


            var hResult = Header_Function.Save_Header();
            if (hResult != "DONE")
            {
                Static_Loading.error_message = "Header Insert Error :" + hResult;
                var pop = new mobile_application.controls.AppMessageBox("Header Insert Error", Static_Loading.error_message);
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                return;
            }
            else
                Header_Function.temp_header.Clear();


            for (int i = 0; i < Header_Function.temp_details.Count; i++)
            {
                Header_Function.temp_details[i].CodeKala = function_static.Create_Kala_Code(Header_Function.temp_details[i].CodeKala);

                var dResult = Service.Insert_Order_Detail(Static_Loading.central_BranchCode,
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
                                           Header_Function.temp_details[i].MoshtariCode);
            }
        }
    }
}