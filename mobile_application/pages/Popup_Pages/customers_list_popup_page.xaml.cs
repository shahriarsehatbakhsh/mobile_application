using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.pages.Order_Pages;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public customers_list_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;
        }

        private void btnCloseMe_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new A_add_new_order();
        }
    }
}