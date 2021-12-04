using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_application.Service.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using mobile_application.ServiceResponse;
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
			this.lblobjCode.Text = obj.Code.ToString();
			this.lblobjName.Text = obj.Sharh.ToString();

			var Nerkh = await Client.Object_Nerkh(Static_Loading.central_BranchCode, Static_Loading.Header[0].CodeMosavabe, obj.Code);
			this.lblNerkh.Text = Nerkh[0].Sharh.ToString();
		}

		private async void btnCloseMe_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopPopupAsync(true);
		}

		private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
			if (Static_Loading.Header[0] == null)
				return;

			Static_Loading.Details.Add(new Fakes.F_dSefareshSeller
			{
				BranchCode = Static_Loading.Header[0].CodeShobe ,
				CodeAnbaar = Static_Loading.central_BranchCode ,
				CodeKala = this.lblobjCode.Text ,
				NameKala = this.lblobjName.Text ,
				CodeKarbar = Static_Loading.central_user_id ,
				CodeShobe = Static_Loading.Header[0].CodeShobe ,
				Mablagh = Convert.ToDecimal(this.txtMablagh.Text) ,
				Meghdar = Convert.ToDecimal(this.txtMeghdar.Text) ,
				MoshtariCode = Static_Loading.Header[0].CodeMoshtari.ToString() ,
				Nerkh = 200 ,
				ShomareRadif = Static_Loading.Details.Count + 1 ,
				NoeBaste = 1 ,
				TarikhRooz = Static_Loading.today_date ,
				TedadBaste = 1 ,
				ShomareBarge_Header = Static_Loading.Header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderCode ,
				TedadDarHarBaste = 1 
			});

			ToastNotification.TostMessage("کالای مربوطه به برگه سفارش اضافه شد");
			await Navigation.PopPopupAsync(true);
		}
    }
}