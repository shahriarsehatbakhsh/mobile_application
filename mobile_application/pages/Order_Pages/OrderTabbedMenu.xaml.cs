using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using mobile_application.Helper;

namespace mobile_application.pages.Order_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderTabbedMenu : TabbedPage
    {

        OrderDetailObjects frm;
        public OrderTabbedMenu()
        {
            InitializeComponent();

            var frmOrderObjectList = new OrderObjectList();
            frmOrderObjectList.Title = "لیست کالاها";
            frmOrderObjectList.IconImageSource = "title01.png";
            this.Children.Add(frmOrderObjectList);

            var frmOrderDetailObjects = new OrderDetailObjects();
            frmOrderDetailObjects.Title = "کالاهای انتخاب شده";
            frmOrderDetailObjects.IconImageSource = "title02.png";
            this.Children.Add(frmOrderDetailObjects);

            var frmOrderDetail = new OrderDetail();
            frmOrderDetail.Title = "ثبت سفارش";
            frmOrderDetail.IconImageSource = "title03.png";
            this.Children.Add(frmOrderDetail);

            ToolbarItem tbi = new ToolbarItem();
            tbi.Text = "صفحه ثبت سفارش";
            tbi.IconImageSource = "search.png";
            tbi.Clicked += tbi_Clicked;
            this.ToolbarItems.Add(tbi);
        }

        private async void tbi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            //frm.OrderObjectsDetail_Refresh();
        }
    }
}