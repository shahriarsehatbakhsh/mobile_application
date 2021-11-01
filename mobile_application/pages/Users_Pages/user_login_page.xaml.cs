using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using mobile_application.Services;
using mobile_application.modules;

namespace mobile_application.pages.Users_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_login_page : ContentPage
    {
        public user_login_page()
        {
            InitializeComponent();
        }


        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            //this.IsBusy = true;


            //string username = txtUsername.Text;
            //string password = txtPassword.Text;
            // _ = IDataBase.users_Get_ID(username,password);
            //System.Threading.Thread.Sleep(2000);



            //this.IsBusy = false;
            //if (IPublic.user_ID == 0)
            //{
            //    DisplayAlert("Error", "username or password is incorrect !!!", "again");
            //    this.txtUsername.Text = this.txtPassword.Text = "";
            //}
            //else
            //    App.Current.MainPage = new AppShell();



            App.Current.MainPage = new AppShell();
            //App.Current.MainPage = new NavigationPage(new home_page());
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                Debug.WriteLine("Failed to Load Item");
            }
            Entry txtUsername = sender as Entry;
            string Username = txtUsername.Text;
        }

    }
}