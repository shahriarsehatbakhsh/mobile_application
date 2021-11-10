using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;

namespace mobile_application.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppMessageBox : PopupPage
    {
        public AppMessageBox(string Title,string Caption)
        {
            InitializeComponent();
            this.Title.Text = Title;
            this.Caption.Text = Caption;
        }

        private void btnConfirm_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopPopupAsync(true);
        }
    }
}