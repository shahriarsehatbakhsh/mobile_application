﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.pages.Popup_Pages;
using Rg.Plugins.Popup.Exceptions;
using System.ComponentModel;
using Rg.Plugins.Popup.Extensions;
using mobile_application.Services.Models;
using mobile_application.Services;
using mobile_application.Helper;

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
            await Navigation.PushAsync(new B_add_new_object_and_menu(), true);
        }


        customers_search_list_popup_page frm_customer_list;
        private async void btnSelectCustomer_Clicked(object sender, EventArgs e)
        {
            frm_customer_list = new customers_search_list_popup_page();
            frm_customer_list.Search += Customer_Search_Result;
            await Navigation.PushPopupAsync(frm_customer_list, true);
        }
        private void Customer_Search_Result(object sender, List<vw_customers_list_get_code_shobe> e)
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


        shobe_search_list_popup_page frm_shobe_list ;
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


        private void txtShobeCode_Focused(object sender, FocusEventArgs e)
        {
            
        }

        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void btnNextObject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new B_add_new_object_and_menu(), true);
        }

        private void txtShobeCode_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}