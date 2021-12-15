using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using mobile_application.pages.Popup_Pages;
using mobile_application.Helper;
using mobile_application.Services;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using mobile_application.Models;

namespace mobile_application.pages.Customers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customer_add_new_page : ContentPage
    {
        public customer_add_new_page()
        {
            InitializeComponent();
        }

        code_sharh_search_list_popup_page frm ;
        List<vw_code_sharh> Items;
        private async Task Choose_Form()
        {
            frm = new code_sharh_search_list_popup_page(Items);
            frm.Search += Frm_Search;
            await Navigation.PushPopupAsync(frm, true);
        }

        string _which_button ;
        private void Frm_Search(object sender, List<vw_code_sharh> e)
        {
            var code = "";
            var sharh = "";
            switch (_which_button)
            {
                case "btnSelectItem1":
                    this.txtCodePishe.Text = e[0].Code.ToString();
                    this.lbl1.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem2":
                    this.txtCodeOstan.Text = e[0].Code.ToString();
                    this.lbl2.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem3":
                    this.txtCodeShahr.Text = e[0].Code.ToString();
                    this.lbl3.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem4":
                    this.txtCodeMantaghe.Text = e[0].Code.ToString();
                    this.lbl4.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem5":
                    this.txtCodeMasir.Text = e[0].Code.ToString();
                    this.lbl5.Text = e[0].Sharh.ToString();
                    break;
                default:
                    code = "" ;
                    sharh = "" ;
                    break;
            }
            
        }

        private async void SelectItem5_Clicked(object sender, EventArgs e)
        {
            var result = await Service.Masir_List();
            Items = result;
            _which_button = "btnSelectItem5";
            await Choose_Form();
        }

        private async void SelectItem4_Clicked(object sender, EventArgs e)
        {
            var result = await Service.Mantaghe_List();
            Items = result;
            _which_button = "btnSelectItem4";
            await Choose_Form();
        }

        private async void SelectItem3_Clicked(object sender, EventArgs e)
        {
            var result = await Service.Shahr_List();
            Items = result;
            _which_button = "btnSelectItem3";
            await Choose_Form();
        }

        private async void SelectItem2_Clicked(object sender, EventArgs e)
        {
            var result = await Service.Ostan_List();
            Items = result;

            _which_button = "btnSelectItem2";
            await Choose_Form();
        }

        private async void SelectItem1_Clicked(object sender, EventArgs e)
        {
            var result = await Service.Pishe_List();
            Items = result;
            _which_button = "btnSelectItem1";
            await Choose_Form();
        }

        shobe_search_list_popup_page frm_shobe_list;
        private async void btnSelectShobe_Clicked(object sender, EventArgs e)
        {
            var result = await Service.Branch_List(Static_Loading.central_user_id, Static_Loading.central_user_per);
            views.show_list = result;

            frm_shobe_list = new shobe_search_list_popup_page(views.show_list);
            frm_shobe_list.Search += Shobe_Search_Result;
            await Navigation.PushPopupAsync(frm_shobe_list, true);
        }
        private void Shobe_Search_Result(object sender, List<vw_code_sharh> e)
        {
            this.txtShobeCode.Text = e[0].Code.ToString();
            this.txtShobeName.Text = e[0].Sharh.ToString();
        }


        private async void btnSaveCustomer_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;
            int BranchCode = Convert.ToInt32(this.txtShobeCode.Text);
            var result = await Service.GetLatestAvailableCustomerCode(BranchCode);
            vw_customer_code_serial ccs = result[0];

            int sp_GetLatestAvailableCustomerCode_code = ccs.CustomerCode;
            string Sharh = this.txtSharh.Text;
            int sp_GetLatestAvailableCustomerCode_serial = ccs.CustomerSerial;

            long CodeKarbareVaredShodeBeSystem = Helper.Static_Loading.central_user_id;
            string TairkheRooz = Helper.Static_Loading.today_date;
            int CodePishe = Convert.ToInt32(this.txtCodePishe.Text);

            int CodeOstan = Convert.ToInt32(this.txtCodeOstan.Text);
            int CodeShahr = Convert.ToInt32(this.txtCodeShahr.Text);
            int CodeMantaghe = Convert.ToInt32(this.txtCodeMantaghe.Text);
            int CodeMasir = Convert.ToInt32(this.txtCodeMasir.Text);

            string Tel = this.txtTel.Text;
            string Mobile = this.txtMobile.Text;
            string Address = this.txtAddress.Text;


            var result_insert = await Service.Customer_Insert(BranchCode, sp_GetLatestAvailableCustomerCode_code,Sharh,sp_GetLatestAvailableCustomerCode_serial,CodeKarbareVaredShodeBeSystem,TairkheRooz,CodePishe,CodeOstan,CodeShahr,CodeMantaghe,CodeMasir,Tel,Mobile,Address);

            if (result_insert == null)
            {
                ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);
                this.ReLoad_Form();
                IsBusy = false;
            }
            else 
            { 
                //something wrong
            }

            
        }

        private void ReLoad_Form()
        {
            this.txtShobeCode.Text = "";
            this.txtShobeName.Text = "";
        }
    }
}