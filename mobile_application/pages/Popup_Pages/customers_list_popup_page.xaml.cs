using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.pages.Order_Pages;

using mobile_application.Services;
using mobile_application.Services.Models;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {

        //public IList<vw_customers_list_get_code_shobe> customers_list { get; private set; }

        public customers_list_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;

            IList<vw_customers_list_get_code_shobe> Items = sp.Customers_list(1);
            //foreach (var item in Items)
            //{
            //    customers_list.Add
            //        (
            //            new vw_customers_list_get_code_shobe {  }
            //        );
            //}
            this.lst.ItemsSource = Items ;
        }

        private void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new A_add_new_order();
        }
    }
}