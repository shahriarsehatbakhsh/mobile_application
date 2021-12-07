using mobile_application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailObjects : ContentPage
    {
        public OrderDetailObjects()
        {
            InitializeComponent();
        }

        private void collObjectList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Header_Function.temp_details == null)
                return;

            this.lstDetails.ItemsSource = Header_Function.temp_details;
        }
    }
}