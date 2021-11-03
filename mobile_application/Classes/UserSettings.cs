
//using System;
//using System.Collections.Generic;
//using System.Text;

//using Plugin.Settings;
//using Plugin.Settings.Abstractions;

//namespace mobile_application.Classes
//{
//    public static class UserSettings
//    {
//        static ISettings AppSettings
//        {
//            get
//            {
//                return CrossSettings.Current;
//            }
//        }
//        public static string UserName
//        {
//            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
//            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
//        }
//        public static string MobileNumber
//        {
//            get => AppSettings.GetValueOrDefault(nameof(MobileNumber), string.Empty);
//            set => AppSettings.AddOrUpdateValue(nameof(MobileNumber), value);
//        }
//        public static string Email
//        {
//            get => AppSettings.GetValueOrDefault(nameof(Email), string.Empty);
//            set => AppSettings.AddOrUpdateValue(nameof(Email), value);
//        }
//        public static string Password
//        {
//            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
//            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
//        }
//        public static void ClearAllData()
//        {
//            AppSettings.Clear();
//        }
//    }
//}
