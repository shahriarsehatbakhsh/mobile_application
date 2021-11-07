using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Services.Models;
using mobile_application.Services;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class shobe_search_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public shobe_search_list_popup_page()
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;

            List<vw_shobe_list> Items = sp.Shobe_List(2, 2);
            this.lstList.ItemsSource = Items;
        }

        private void btnCloseMe_Clicked(object sender, EventArgs e)
        {

        }
    }
}