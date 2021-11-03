
using System;
using System.Data;
using System.Data.SqlClient;

using mobile_application.Models;
using mobile_application.modules;

namespace mobile_application.Services
{
    public static class Client
    {
        
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter da = new SqlDataAdapter();

        public static void Init()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
        }


        public static string con_server = "";
        public static string con_database = "";
        public static string con_username = "";
        public static string con_password = "";

        
        public static string connection_string = "";


        public static void Set_Connection_String(string datasource, string username, string password, string db)
        {
            con_server = datasource;
            con_username = username;
            con_password = password;
            con_database = db;

            Set_Connection_String();
        }

        public static void Set_Connection_String(int connection_id)
        {
            var r = ConnectionSyntax.Get_Active_Database_Connection_Id();
            var connection = ConnectionSyntax.Get(r);

            con_server = connection[0].server_name;
            con_username = connection[0].login;
            con_password = connection[0].password;
            con_database = connection[0].database;

            Set_Connection_String();
        }

        public static void Set_Connection_String()
        {
            connection_string = "Data Source=" + con_server + ";Initial Catalog=" + con_database + ";Persist Security Info=True;User ID=" + con_username + ";Password=" + con_password + "";
            con.Close();
            con.ConnectionString = connection_string;
        }

        /// <summary>
        /// if connection is close then connection=open else connection=close .
        /// </summary>
        /// <returns>connection state</returns>
        public static bool Server_Connection()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;

                    return true;
                }
                else if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                    cmd.Connection.Close();
                    cmd.Dispose();
                }

                return false;
            }
            catch (System.Exception ex)
            {

                IPublic.error_message = ex.Message;
                return false;
            }
        }

    }
}