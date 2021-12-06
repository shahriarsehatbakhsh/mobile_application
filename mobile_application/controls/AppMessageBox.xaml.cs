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
        public AppMessageBox(string Title,string Caption, BgColor color = BgColor.Defult)
        {
            InitializeComponent();
            this.Title.Text = Title;
            this.Caption.Text = Caption;

            if (color == BgColor.Defult)
                return;

            this.btnConfirm.BackgroundColor = GetColor(color);
        }

        Color GetColor(BgColor color)
        {
            Color result;
            if (color == BgColor.Red)
                result = Color.Red;
            else if (color == BgColor.Green)
                result = Color.Green;
            else if (color == BgColor.Yellow)
                result = Color.Yellow;
            else
                result = Color.Green;

            return result;
        }

        public enum BgColor
        { 
            Green,
            Red,
            Yellow,
            Defult
        }

        private void btnConfirm_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopPopupAsync(true);
        }
    }
}