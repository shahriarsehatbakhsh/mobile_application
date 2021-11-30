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
    public partial class DetailsObjectsList : ContentPage
    {
        public DetailsObjectsList()
        {
            InitializeComponent();
            this.lstDetails.ItemsSource = Static_Loading.Details;
        }

        private void collObjectList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {

        }
    }
}