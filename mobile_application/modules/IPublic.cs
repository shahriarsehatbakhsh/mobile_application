
using System;
using System.IO;
using mobile_application.Models;

namespace mobile_application.modules
{
    public static class IPublic
    {
        /// <summary>
        /// data base file path .
        /// </summary>
        public static string db_path => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mobile_application.DB");
        //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"db.SQlite");
        //Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "db.SQlite");

        /// <summary>
        /// if user_id == 0 then run application start page and frist time .
        /// </summary>
        public static int user_ID;

        public static int app_state = 0;

        public static string error_message;


    }
}