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
using mobile_application.Services;
using mobile_application.Services.Models;
using mobile_application.Helper;

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
            Items = sp.Code_Sharh_List(sp.exec.sp_masir_list);
            _which_button = "btnSelectItem5";
            await Choose_Form();
        }

        private async void SelectItem4_Clicked(object sender, EventArgs e)
        {
            Items = sp.Code_Sharh_List(sp.exec.sp_mantaghe_list);
            _which_button = "btnSelectItem4";
            await Choose_Form();
        }

        private async void SelectItem3_Clicked(object sender, EventArgs e)
        {
            Items = sp.Code_Sharh_List(sp.exec.sp_shahr_list);
            _which_button = "btnSelectItem3";
            await Choose_Form();
        }

        private async void SelectItem2_Clicked(object sender, EventArgs e)
        {
            Items = sp.Code_Sharh_List(sp.exec.sp_ostan_list);
            _which_button = "btnSelectItem2";
            await Choose_Form();
        }

        private async void SelectItem1_Clicked(object sender, EventArgs e)
        {
            Items = sp.Code_Sharh_List(sp.exec.sp_pishe_list);
            _which_button = "btnSelectItem1";
            await Choose_Form();
        }

        shobe_search_list_popup_page frm_shobe_list;
        private async void btnSelectShobe_Clicked(object sender, EventArgs e)
        {
            views.show_list = sp.Shobe_List(2, 2);

            frm_shobe_list = new shobe_search_list_popup_page(views.show_list);
            frm_shobe_list.Search += Shobe_Search_Result;
            await Navigation.PushPopupAsync(frm_shobe_list, true);
        }
        private void Shobe_Search_Result(object sender, List<vw_shobe_list> e)
        {
            this.txtShobeCode.Text = e[0].Code.ToString();
            this.txtShobeName.Text = e[0].Sharh.ToString();
        }


        private async void btnSaveCustomer_Clicked(object sender, EventArgs e)
        {
            ///save new customers syntax .....
            IsBusy = true;
            

            int CodeShobe = Convert.ToInt32(this.txtShobeCode.Text);
            vw_customer_code_serial ccs = sp.Customer_Get_Code_Serial(CodeShobe)[0];

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

            await sp.Customer_Insert(CodeShobe, 
                                     sp_GetLatestAvailableCustomerCode_code, 
                                     Sharh, 
                                     sp_GetLatestAvailableCustomerCode_serial,
                                     CodeKarbareVaredShodeBeSystem,
                                     TairkheRooz, 
                                     CodePishe, 
                                     CodeOstan, 
                                     CodeShahr, 
                                     CodeMantaghe, 
                                     CodeMasir,
                                     Tel, 
                                     Mobile, 
                                     Address);


            ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);
            this.ReLoad_Form();
            IsBusy = false;
        }

        private void ReLoad_Form()
        {
            this.txtShobeCode.Text = "";
            this.txtShobeName.Text = "";
        }
    }
}