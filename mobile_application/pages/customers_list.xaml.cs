using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.modules;

namespace mobile_application.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class customers_list : ContentPage
    {
        public customers_list()
        {
            InitializeComponent();
            BindingContext = new main_menu_list();
        }
    }
}