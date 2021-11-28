using com.teenage_period.nedkely.ViewModels;
using com.teenage_period.nedkely.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace com.teenage_period.nedkely
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
