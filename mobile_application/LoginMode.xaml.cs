using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginMode : ContentPage
    {
        public LoginMode()
        {
            InitializeComponent();
        }

        private async void LoginClick(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new HomeMode());
            await Navigation.PushAsync(new HomeMode(), true);
        }
    }
}