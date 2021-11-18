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
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using mobile_application.Service.Models;

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
            //Items = sp.Code_Sharh_List(sp.exec.sp_masir_list);
            var json = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "Lists/Masir");
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
            Items = result;
            _which_button = "btnSelectItem5";
            await Choose_Form();
        }

        private async void SelectItem4_Clicked(object sender, EventArgs e)
        {
            //Items = sp.Code_Sharh_List(sp.exec.sp_mantaghe_list);
            var json = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "Lists/Mantaghe");
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
            Items = result;
            _which_button = "btnSelectItem4";
            await Choose_Form();
        }

        private async void SelectItem3_Clicked(object sender, EventArgs e)
        {
            //Items = sp.Code_Sharh_List(sp.exec.sp_shahr_list);
            var json = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "Lists/Shahr");
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
            Items = result;
            _which_button = "btnSelectItem3";
            await Choose_Form();
        }

        private async void SelectItem2_Clicked(object sender, EventArgs e)
        {
            //Items = sp.Code_Sharh_List(sp.exec.sp_ostan_list);
            var json = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "Lists/Ostan");
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
            Items = result;

            _which_button = "btnSelectItem2";
            await Choose_Form();
        }

        private async void SelectItem1_Clicked(object sender, EventArgs e)
        {
            //Items = sp.Code_Sharh_List(sp.exec.sp_pishe_list);
            var json = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "Lists/Pishe");
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);

            _which_button = "btnSelectItem1";
            await Choose_Form();
        }

        shobe_search_list_popup_page frm_shobe_list;
        private async void btnSelectShobe_Clicked(object sender, EventArgs e)
        {
            var json = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "List/Shobe code_karbar=" + Static_Loading.central_user_id + ",code_karbar_per=" + Static_Loading.central_user_per);
            List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);

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
            ///save new customers syntax .....
            IsBusy = true;


            //Customers / GetLatestAvailableCustomerCode BranchCode = 1
            int CodeShobe = Convert.ToInt32(this.txtShobeCode.Text);
            var json = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "Customers/GetLatestAvailableCustomerCode BranchCode=" + CodeShobe);
            List<vw_customer_code_serial> result = JsonConvert.DeserializeObject<List<vw_customer_code_serial>>(json);
            vw_customer_code_serial ccs = result[0];

            int sp_GetLatestAvailableCustomerCode_code = ccs.CustomerCode;
            string Sharh = this.txtSharh.Text;
            int sp_GetLatestAvailableCustomerCode_serial = ccs.CustomerSerial;

            int CodeKarbareVaredShodeBeSystem = Helper.Static_Loading.central_user_id;
            string TairkheRooz = Helper.Static_Loading.today_date;
            int CodePishe = Convert.ToInt32(this.txtCodePishe.Text);

            int CodeOstan = Convert.ToInt32(this.txtCodeOstan.Text);
            int CodeShahr = Convert.ToInt32(this.txtCodeShahr.Text);
            int CodeMantaghe = Convert.ToInt32(this.txtCodeMantaghe.Text);
            int CodeMasir = Convert.ToInt32(this.txtCodeMasir.Text);

            string Tel = this.txtTel.Text;
            string Mobile = this.txtMobile.Text;
            string Address = this.txtAddress.Text;


            //Customers/Insert code_shobe=1,sp_GetLatestAvailableCustomerCode_code=967,Sharh=%D9%85%D8%B4%D8%AA%D8%B1%DB%8C%20%D8%B9%D9%84%DB%8C%20%D8%AD%D8%B3%DB%8C%D9%86%DB%8C%20%D8%AC%D8%AF%DB%8C%D8%AF,sp_GetLatestAvailableCustomerCode_serial=13,CodeKarbareVaredShodeBeSystem=1,TairkheRooz=1400%2F08%2F08,CodePishe=1,CodeOstan=1,CodeShahr=1,CodeMantaghe=1,CodeMasir=1,Tel=1,Mobile=1,Address=1?CodeShobe=1
            var json_insert = await Static_Loading.client.GetStringAsync(Static_Loading.api_url() + "Customers/Insert code_shobe=" + CodeShobe + ",sp_GetLatestAvailableCustomerCode_code=" + sp_GetLatestAvailableCustomerCode_code + ",Sharh=" + Sharh + "," +
                "sp_GetLatestAvailableCustomerCode_serial=" + sp_GetLatestAvailableCustomerCode_serial + "," +
                "CodeKarbareVaredShodeBeSystem=" + CodeKarbareVaredShodeBeSystem + "," +
                "TairkheRooz=" + TairkheRooz + "," +
                "CodePishe=" + CodePishe + "," +
                "CodeOstan=" + CodeOstan + "," +
                "CodeShahr=" + CodeShahr + "," +
                "CodeMantaghe=" + CodeMantaghe + "," +
                "CodeMasir=" + CodeMasir + "," +
                "Tel=" + Tel + "," +
                "Mobile=" + Mobile + ",Address=" + Address + "?CodeShobe=1");
            List<ErrorResult> result_insert = JsonConvert.DeserializeObject<List<ErrorResult>>(json_insert);

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