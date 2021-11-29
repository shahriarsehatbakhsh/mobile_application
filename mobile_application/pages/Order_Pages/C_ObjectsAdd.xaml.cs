using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.ServiceResponse;

namespace mobile_application.pages.Order_Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class C_ObjectsAdd : ContentPage
	{
		public C_ObjectsAdd ()
		{
			InitializeComponent ();
			var objList = Client.Objects_List();
			this.collView.ItemsSource = objList.GetAwaiter().GetResult();
		}

        private void lblAddObject_Click(object sender, EventArgs e)
        {

        }
    }
}