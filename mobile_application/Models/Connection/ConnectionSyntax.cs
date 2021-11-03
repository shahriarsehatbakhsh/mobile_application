
using System;
using System.Collections.Generic;
using mobile_application.Models.Connection;

namespace mobile_application.Models
{
    public static class ConnectionSyntax
    {

        #region [tb_Connection]

        #endregion

        public static bool Insert(string server, string username, string password, string database, int is_default)
        {
            try
            {
                DB_Context.Init();
                var new_connection = new tb_Connection
                {
                    server_name = server,
                    login = username,
                    password = password,
                    database = database,
                    is_default = is_default
                };

                _ = DB_Context.db.Insert(new_connection);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static bool Delete(int id)
        {
            try
            {
                DB_Context.Init();
                DB_Context.db.Delete<tb_Connection>(id);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Delete()
        {
            try
            {
                DB_Context.Init();
                DB_Context.db.DeleteAll<tb_Connection>();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Get_Active_Database_Connection_Id()
        {
            try
            {
                DB_Context.Init();
                return DB_Context.db.ExecuteScalar<int>("SELECT * FROM tb_Connection WHERE is_default=1 LIMIT 1");
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        //public static int Get_User_Id(string username, string password)
        //{
        //    DB_Context.Init();
        //    var result = DB_Context.db.ExecuteScalar<int>("select id from tb_Users where username='" + username + "' and password='" + password + "'");
        //    Console.WriteLine(string.Format("Found '{0}' stock items.", result));
        //    IPublic.user_ID = result;
        //    return result;
        //}

       
        public static List<tb_Connection> Get(int id)
        {
            try
            {
                DB_Context.Init();
                return DB_Context.db.Table<tb_Connection>().Where(o => o.Id == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Count()
        {
            try
            {
                DB_Context.Init();
                return DB_Context.db.ExecuteScalar<int>("SELECT COUNT(*) FROM tb_Connection");
            }
            catch (Exception)
            {
                //Console.WriteLine(string.Format("Found '{0}' stock items.", result));
                throw;
            }
        }

    }
}
