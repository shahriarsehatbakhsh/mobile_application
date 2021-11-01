using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data;
using System.IO;
using System.Dynamic;
using System.Collections.ObjectModel;
using mobile_application.Services;
using mobile_application.modules;



namespace mobile_application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        async Task AddCommand()
        {
            var Username = await App.Current.MainPage.DisplayPromptAsync("title", "get username", "ok");
            var Password = await App.Current.MainPage.DisplayPromptAsync("title", "get password", "ok");
        }

        async Task RemoveCommand()
        {
            //await IDataBase.users_delete(1);
        }

        async Task RefreshCommand()
        {
            this.IsBusy = true;
            await Task.Delay(2000);


            //Users_tb.ReferenceEquals
            


            this.IsBusy = true;
        }





        //public List<Users_tb> Users;
        

        //public AsyncCommand refreshCommand { get; }

        public Page1()
        {
            InitializeComponent();

            //var Users = IDataBase.users_get();
            //this.BindingContext = Users;


            //Content = new StackLayout
            //{
            //    Children =
            //    {
            //        new Label
            //        {
            //            Text = "this is test for new label",
            //            BackgroundColor = Color.Red,
            //        }
            //    }
            //};
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "file.txt");

            string strLocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string strAppPath = "";
            


            //Label lbl1 = sender as Label;
            //lbl1.Text = strLocalApplicationData;
            
            txt1.Text = strLocalApplicationData;
            txt1.Text = file;


        }

        
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //var Username = txtUsername.Text;
            //var Password = txtPassword.Text;

            //_ = IDataBase.users_insert(Username, Password, 1);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //var result  = IDataBase.users_Get_ID(txtUsername.Text);
            //DisplayAlert("result", result.ToString(), "username"); 
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            // File.Delete(IPublic.db_path);
            //DisplayAlert("delete", "Success", "OK"); ;
        }
    }
}