using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using mobile_application.Services;
using mobile_application.Helper;

namespace mobile_application.pages.Popup_Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class add_object_popup_page : PopupPage
	{
		vw_code_sharh obj;
		public add_object_popup_page (vw_code_sharh SelectObj)
		{
			InitializeComponent ();

			obj = SelectObj;
			Loading();
		}

		
		private async void Loading()
		{
			var Nerkh = await Service.Object_Nerkh(Static_Loading.central_BranchCode, Header_Function.temp_header[0].CodeMosavabe, obj.Code);
			try
            {
				this.lblobjCode.Text = obj.Code.ToString();
				this.lblobjName.Text = obj.Sharh.ToString();

				
				this.lblNerkh.Text = Nerkh[0].Sharh.ToString();
			}
            catch (Exception ex)
            {
				if (Nerkh == null)
				{
					var pop = new mobile_application.controls.AppMessageBox("خطا", "کالای انتخاب شده دارای نرخ و اطلاعات قیمت نمیباشد.");
					await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
				}
				else
				{
					var pop = new mobile_application.controls.AppMessageBox("Loading", ex.Message);
					await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
				}
                throw;
            }
		}

		private async void btnCloseMe_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopPopupAsync(true);
		}

		private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
			if (Header_Function.temp_header[0] == null)
				return;

			Header_Function.Add_Detail_Temp(
				Header_Function.temp_header[0].CodeShobe,
				Static_Loading.central_BranchCode,
				this.lblobjCode.Text,
				this.lblobjName.Text,
				Static_Loading.central_user_id,
				Header_Function.temp_header[0].CodeShobe,
				Convert.ToDecimal(this.txtMablagh.Text),
				Convert.ToDecimal(this.txtMeghdar.Text),
				Header_Function.temp_header[0].CodeMoshtari.ToString(),
				Convert.ToSingle(this.lblNerkh.Text)
				);

			ToastNotification.TostMessage("کالای مربوطه به برگه سفارش اضافه شد");
			await Navigation.PopPopupAsync(true);
		}

        private void txtMeghdar_TextChanged(object sender, TextChangedEventArgs e)
        {
			if (!string.IsNullOrEmpty(this.txtMeghdar.Text))
			{
				var meghdar = Convert.ToInt64(this.txtMeghdar.Text);
				var nerkh = Convert.ToDecimal(this.lblNerkh.Text);
				var result = meghdar * nerkh;
				this.txtMablagh.Text = result.ToString("###,###");
			}
			else
			{
				this.txtMeghdar.Text = "0";
			}
        }
    }
}