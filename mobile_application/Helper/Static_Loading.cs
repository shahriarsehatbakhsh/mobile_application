using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Net.Http;
using System.Data;
using mobile_application.Models;

namespace mobile_application.Helper
{
    public static class Static_Loading
    {
        public static string db_path => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "com.Paya.DB");



        public static long central_user_id = 0;
        public static int central_user_per = 2;
        public static int central_BranchCode ;
        public static String central_BranchName ;
        public static String central_BargeDate;
        public static int Customer_Code;
        public static string Customer_Name;
        public static string today_date = "1400/08/14";


        public static bool Is_Set_ConnectionString;


        public static int app_state = 0;

        public static string error_title;
        public static string error_message;
        public static string done_message = "انجام عملیات موفقیت آمیز بود" ;


        public static bool connection_internet;
        public static bool connection_service;




        
        
        
        


    }
}
