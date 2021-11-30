using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.pages.Popup_Pages;
using Rg.Plugins.Popup.Extensions;
using mobile_application.ServiceResponse;
using mobile_application.Service.Models;
using mobile_application.Helper;
using Newtonsoft.Json;
using System.Net.Http;
using mobile_application.Fakes;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class A_add_new_order : ContentPage
    {
        public A_add_new_order()
        {
            InitializeComponent();
        }

        private async void btnMain_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

        private async void btnNext_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderMenuTabbedPage(), true);
        }


        customers_search_list_popup_page frm_customer_list;
        private async void btnSelectCustomer_Clicked(object sender, EventArgs e)
        {
            frm_customer_list = new customers_search_list_popup_page();
            frm_customer_list.Search += Customer_Search_Result;
            await Navigation.PushPopupAsync(frm_customer_list, true);
        }
        private void Customer_Search_Result(object sender, List<vw_customers_list> e)
        {
            this.txtCustomerCode.Text = e[0].Code.ToString();
            this.txtCustomerName.Text = e[0].Sharh.ToString();
        }


        seller_list_search_popup_page frm_seller_list;
        private async void btnSelectSeller_Clicked(object sender, EventArgs e)
        {
            frm_seller_list = new seller_list_search_popup_page();
            frm_seller_list.Search += Seller_Search_Result;
            await Navigation.PushPopupAsync(frm_seller_list, true);
        }
        private void Seller_Search_Result(object sender, List<vw_seller_list> e)
        {
            this.txtSellerCode.Text = e[0].Code.ToString();
            this.txtSellerName.Text = e[0].Sharh.ToString();
        }


        supervizer_list_search_popup_page frm_supervizer_list;
        private async void btnSelectSoupervizer_Clicked(object sender, EventArgs e)
        {
            frm_supervizer_list = new supervizer_list_search_popup_page();
            frm_supervizer_list.Search += Supervizer_Search_Result;
            await Navigation.PushPopupAsync(frm_supervizer_list, true);
        }
        private void Supervizer_Search_Result(object sender, List<vw_supervizer_list> e)
        {
            this.txtSupervizerCode.Text = e[0].Code.ToString();
            this.txtSupervizerName.Text = e[0].Sharh.ToString();
        }


        shobe_search_list_popup_page frm_shobe_list;
        private async void btnSelectShobe_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(Static_Loading.api_url() + "List/Shobe code_karbar=" + Static_Loading.central_user_id + ",code_karbar_per=" + Static_Loading.central_user_per);
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
            views.show_list = result;

            frm_shobe_list = new shobe_search_list_popup_page(views.show_list);
            frm_shobe_list.Search += Shobe_Search_Result;
            await Navigation.PushPopupAsync(frm_shobe_list, true);
        }
        private void Shobe_Search_Result(object sender, List<vw_code_sharh> e)
        {
            this.txtShobeCode.Text = e[0].Code.ToString();
            Static_Loading.central_BranchCode = Convert.ToInt32(this.txtShobeCode.Text);
            this.txtShobeName.Text = e[0].Sharh.ToString();
        }


        private void txtShobeCode_Focused(object sender, FocusEventArgs e)
        {

        }
        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void txtShobeCode_Unfocused(object sender, FocusEventArgs e)
        {

        }

        mosavabe_search_list_popup_page frmMosavabe;
        private async void btnSelectMosavabe_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var strDate = this.txtDate.ShamsiDateString.Replace("/", "D");
            var url = Static_Loading.api_url() + "List/mosavabe_list Fhmo05=" + strDate + ",Fdmb02=" + Static_Loading.central_BranchCode;
            var json = await client.GetStringAsync(url);
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);

            frmMosavabe = new mosavabe_search_list_popup_page(result);
            frmMosavabe.Search += Mosavabe_Search_Result;
            await Navigation.PushPopupAsync(frmMosavabe, true);
        }
        private void Mosavabe_Search_Result(object sender, List<vw_code_sharh> e)
        {
            this.txtMosavabeCode.Text = e[0].Code.ToString();
            this.txtMosavabeName.Text = e[0].Sharh.ToString();
        }

        private void btnRefreshCustCart_Clicked(object sender, EventArgs e)
        {
            Customer_Cart_New();
        }

        private void txtCustomerCode_Unfocused(object sender, FocusEventArgs e)
        {
            Customer_Cart_New();
        }

        //1 = OK
        //2 = Message
        //3 = Error
        private vw_result pishe;
        private void Customer_Cart_New()
        {
            if (string.IsNullOrEmpty(this.txtCustomerCode.Text))
            {
                this.lblCastCartPrice.Text = "0";
                this.lblCastCartText.Text = "";
                this.lblCustCartState.Text = "";
                return;
            }

            IsBusy = true;
            var CustCode = Convert.ToInt32(this.txtCustomerCode.Text);
            var BranchCode = Static_Loading.central_BranchCode;
            var UserCode = Static_Loading.central_user_id;
            var resut = Client.Customer_Cart_New(BranchCode, CustCode, UserCode);

            var BalancePrice = resut.GetAwaiter().GetResult()[0].BalancePrice;
            if (BalancePrice > 0) //bedehkar
            {
                this.lblCustCartState.Text = "بدهکار";
                this.ColorCustCardState.BackgroundColor = Color.Green;
            }
            else if (BalancePrice == 0)
            {
                this.lblCustCartState.Text = "بدون مانده";
                this.ColorCustCardState.BackgroundColor = Color.Yellow;
            }
            else if (BalancePrice < 0)
            {
                this.lblCustCartState.Text = "بستانکار";
                this.ColorCustCardState.BackgroundColor = Color.Red;
            }

            this.lblCastCartPrice.Text = BalancePrice.ToString("###,###");
            this.lblCastCartText.Text = "ریال";
            var R = Client.Customer_Cart_Pishe_State(BranchCode, CustCode, this.txtDate.Text).GetAwaiter().GetResult();
            if (R == null)
                pishe.result = "1";
            else
                pishe = R[0];

            IsBusy = false;
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private async void btnNextObject_Clicked(object sender, EventArgs e)
        {
            //1 = OK
            //2 = Message
            //3 = Error
            if (pishe.result == "3")
            {
                var pop = new mobile_application.controls.AppMessageBox("توجه", "پیشه شماره 3");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                return;
            }
            else if (pishe.result == "2")
            {
                var pop = new mobile_application.controls.AppMessageBox("توجه", "پیشه شماره 2");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
            }
            else if (pishe.result == "1")
            { 

            }
            //await Navigation.PushAsync(new B_Order_Menu_TabbedPage(), true);

            var HeaderCodeSerial = Client.Header_Code_Serial(Convert.ToInt32(this.txtShobeCode.Text)).GetAwaiter().GetResult()[0];
            var Customer_JobNo = Client.Customer_Job_No(Convert.ToInt32(this.txtShobeCode.Text), Convert.ToInt32(this.txtCustomerCode.Text), this.txtDate.Text).GetAwaiter().GetResult()[0];

            Static_Loading.Header.Clear();
            Static_Loading.Header.Add(new F_hSefareshSeller
            {   
                CodeForooshande = Convert.ToInt32(this.txtSellerCode.Text) ,
                CodeKarbar = Static_Loading.central_user_id , 
                CodeMosavabe = Convert.ToInt32(this.txtMosavabeCode.Text) ,
                CodeMoshtari = Convert.ToInt32(this.txtCustomerCode.Text) ,
                CodeShobe = Convert.ToInt16(this.txtShobeCode.Text) ,
                CodeSupervisor = Convert.ToInt32(this.txtSupervizerCode.Text) ,
                ModdateTasvie = Convert.ToInt32(this.txtEtebar.Text) , 
                NoeTasvie = Convert.ToInt32(this.txtNoeTasvie.SelectedIndex) ,
                Supervisor = 5 , 
                TarikhBarge = this.txtDate.ShamsiDateString , 
                TarikheRooz = Static_Loading.today_date , 
                sp_GetAvailableCustomerJob = Customer_JobNo.JobNo ,
                sp_GetLatestAvailableSefareshHeaderCode_HeaderCode = HeaderCodeSerial.HeaderCode ,
                sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial = HeaderCodeSerial.HeaderSerial
            });


            App.Current.MainPage = new OrderMenuTabbedPage();
        }
        

        private void txtCustomerCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            Customer_Cart_New();
        }
    }
}