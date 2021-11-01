using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application.pages.Popup_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_list_popup_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        public customers_list_popup_page()
        {
            InitializeComponent();
        }
    }
}