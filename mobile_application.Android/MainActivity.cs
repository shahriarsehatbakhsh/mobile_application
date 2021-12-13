﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;


namespace mobile_application.Droid
{
    [Activity(Label = "mobile_application", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //installing my plugin .
            //Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            
            //------------------------------------------------------

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //installing my plugin .
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            //-----------------------------------------------------------------
            Rg.Plugins.Popup.Popup.Init(this);
            LoadApplication(new App());
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {

            }
            else
            { 

            }
        }
    }
}