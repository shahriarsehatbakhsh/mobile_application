﻿using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using SQLite; //u can get more help = >  https://github.com/praeclarum/sqlite-net
using mobile_application.SQLite.Models.Users;
using mobile_application.SQLite.Models.Connection;

namespace mobile_application.SQLite.Models
{
    public static class DB_Context
    {
        public static SQLiteConnection db;

        public static void Init()
        {

            if (db != null)
                return;


            var DatabasePath = mobile_application.Helper.Static_Loading.db_path;
            bool ex = File.Exists(DatabasePath);



            //var options = new SQLiteConnectionString(DatabasePath, true, key: "Paya@321?"); 
            //db = new SQLiteAsyncConnection(options); 
            db = new SQLiteConnection(DatabasePath);


            if (ex)
                return;

            ///Create Database Tables.
            db.CreateTable<tb_Users>();
            db.CreateTable<tb_Connection>();
        }
    }
}