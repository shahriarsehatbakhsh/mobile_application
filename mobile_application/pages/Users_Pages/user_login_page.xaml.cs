﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using mobile_application.Services;
using mobile_application.modules;
using mobile_application.Models;
using System.IO;
using Xamarin.Essentials;

namespace mobile_application.pages.Users_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_login_page : ContentPage
    {
        public user_login_page()
        {
            InitializeComponent();


            bool s = Preferences.Get("save-password", false);
            string username = Preferences.Get("username", "");
            string password = Preferences.Get("password", "");

            this.chkSavePassword.IsChecked = s;

            if (s)
            {
                this.txtUsername.Text = username;
                this.txtPassword.Text = password;
            }
            else
            {
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
            }
        }


        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;


            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var r = UsersSyntax.Get_Id(username, password);




            System.Threading.Thread.Sleep(3000);
            this.IsBusy = false;
            if (r == 0)
            {
                DisplayAlert("Error", "username or password is incorrect !!!", "again");
                this.Focus();
                return;
            }
            else
            {
                bool savePassword = this.chkSavePassword.IsChecked;
                if (savePassword)
                {
                    Preferences.Set("username", this.txtUsername.Text);
                    Preferences.Set("password", this.txtPassword.Text);
                }
                else
                {
                    Preferences.Set("username", "");
                    Preferences.Set("password", "");
                }


                IPublic.user_ID = r;
                //App.Current.MainPage = new AppShell();
                Navigation.PopAsync();
                Navigation.PopAsync();
                return;
            }                


            //App.Current.MainPage = new AppShell();
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

        private void chkSavePassword_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Set("save-password", this.chkSavePassword.IsChecked);
            if (!this.chkSavePassword.IsChecked)
            {
                Preferences.Set("username", "");
                Preferences.Set("password", "");
            }
        }
    }
}