using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.pages.Popup_Pages;
using mobile_application.Service.Models;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class B_add_new_object_and_menu : TabbedPage
    {
        public B_add_new_object_and_menu()
        {
            InitializeComponent();
        }


        objects_search_list_popup_page frm = new objects_search_list_popup_page();
        private async void btnSearchObject_Clicked(object sender, EventArgs e)
        {

            frm = new objects_search_list_popup_page();
            frm.Search += Frm_Search;

            await Navigation.PushAsync(frm, true);
        }

        private void Frm_Search(object sender, List<vw_code_sharh> e)
        {
            this.txtObjCode.Text = e[0].Code.ToString();
            this.txtObjName.Text = e[0].Sharh.ToString();
        }

    }
}