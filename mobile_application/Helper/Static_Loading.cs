using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using mobile_application.Models.Users;

namespace mobile_application.Helper
{
    public static class Static_Loading
    {
        public static string db_path => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "com.Paya.DB");

        

        public static int user_id;
        public static tb_Users current_user;


        public static int app_state = 0;

        public static string error_message;
        public static string done_message = "انجام عملیات موفقیت آمیز بود" ;
    }
}
