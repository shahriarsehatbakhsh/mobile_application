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

            if (Header_Function.temp_details == null)
                return;

            this.lblBranchName.Text = "شعبه : " + Static_Loading.central_BranchName;
            this.lblShomareSefaresh.Text = "شماره سفارش : " + Header_Function.temp_header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderCode.ToString();
            this.lblTarikhBarge.Text = "تاریخ برگه : " + Header_Function.temp_header[0].TarikhBarge.ToString();
            this.lblCustomerInfo.Text = "مشتری : " + Header_Function.temp_header[0].CodeMoshtari.ToString();

            this.lstDetails.ItemsSource = Header_Function.temp_details;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (Header_Function.temp_header.Count == 0)
                return;


            var result = Header_Function.Save_Header();
            if (result != "DONE")
            {
                Static_Loading.error_message = "Header Insert Error :" + result;
                var pop = new mobile_application.controls.AppMessageBox("Header Insert Error", Static_Loading.error_message);
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                return;
            }
            else
                Header_Function.temp_header.Clear();

            
            Header_Function.Save_Details();
        }
    }
}