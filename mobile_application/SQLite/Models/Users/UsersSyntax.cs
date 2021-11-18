
using System;
using System.Collections.Generic;
using mobile_application.Helper;

namespace mobile_application.SQLite.Models.Users
{
    public static class UsersSyntax
    {

        #region [Users_Table_Syntax]

        /// <summary>
        /// insert one user in users table .
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Is_Admin"></param>
        public static bool Insert(string username, string password, int Is_Admin)
        {
            try
            {
                DB_Context.Init();
                var new_user = new tb_Users
                {
                    username = username,
                    password = password,
                    is_admin = Is_Admin
                };

                Static_Loading.user_id = DB_Context.db.Insert(new_user);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// delete user by user id field .
        /// </summary>
        /// <param name="id"></param>
        public static bool Delete(int id)
        {
            try
            {
                DB_Context.Init();
                DB_Context.db.Delete<tb_Users>(id);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// return user id by get only username .
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int Get_Id(string username)
        {
            try
            {
                return DB_Context.db.ExecuteScalar<int>("SELECT id FROM tb_Users WHERE username='" + username + "'");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// return user id by get username and password .
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Get_Id(string username, string password)
        {
            try
            {
                DB_Context.Init();
                return DB_Context.db.ExecuteScalar<int>("SELECT id FROM tb_Users WHERE username='" + username + "' AND password='" + password + "'");
            }
            catch (Exception)
            {
                //Console.WriteLine(string.Format("Found '{0}' stock items.", result));
                throw;
            }
        }

        /// <summary>
        /// return all users in list .
        /// </summary>
        /// <returns></returns>
        public static List<tb_Users> Gets()
        {
            try
            {
                DB_Context.Init();
                return DB_Context.db.Table<tb_Users>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static tb_Users Get(int id)
        {
            try
            {
                DB_Context.Init();
                return DB_Context.db.Table<tb_Users>().Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// return users count field .
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            try
            {
                DB_Context.Init();
                return DB_Context.db.ExecuteScalar<int>("SELECT COUNT(*) FROM tb_Users");
            }
            catch (Exception)
            {
                //Console.WriteLine(string.Format("Found '{0}' stock items.", result));
                throw;
            }
        }

        #endregion

    }
}