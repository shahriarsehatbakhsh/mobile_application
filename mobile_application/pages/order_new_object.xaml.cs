using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_application.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class order_new_object : ContentPage
    {

        public Command BackCommand { get; }


        public order_new_object()
        {
            InitializeComponent();

            BackCommand = new Command(backPage);
        }

        private void backPage(object obj)
        {
            App.Current.MainPage = new order_new_object();
        }
    }



}