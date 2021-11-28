using com.teenage_period.nedkely.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace com.teenage_period.nedkely.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}