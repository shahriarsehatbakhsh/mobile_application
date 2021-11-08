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

namespace mobile_application.pages.Customers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customer_add_new_page : ContentPage
    {
        public customer_add_new_page()
        {
            InitializeComponent();
        }

        private void btnSaveCustomer_Clicked(object sender, EventArgs e)
        {
            ///save new customers syntax .....
            ToastNotification.TostMessage(mobile_application.Helper.Static_Loading.done_message);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

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
                    this.txt1.Text = e[0].Code.ToString();
                    this.lbl1.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem2":
                    this.txt2.Text = e[0].Code.ToString();
                    this.lbl2.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem3":
                    this.txt3.Text = e[0].Code.ToString();
                    this.lbl3.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem4":
                    this.txt4.Text = e[0].Code.ToString();
                    this.lbl4.Text = e[0].Sharh.ToString();
                    break;
                case "btnSelectItem5":
                    this.txt5.Text = e[0].Code.ToString();
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
    }
}