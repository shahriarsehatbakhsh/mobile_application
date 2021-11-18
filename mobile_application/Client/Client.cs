
using System;
using System.Data;
using System.Data.SqlClient;
using mobile_application.SQLite.Models.Connection;
using mobile_application.SQLite.Models.Users;
using mobile_application.Helper;

namespace mobile_application.Client
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


        public static string con_name = "";
        public static string con_server = "";
        public static string con_login = "";
        public static string con_password = "";
        public static string con_database = "";

        public static bool Is_Set_ConnectionString;
        public static string connection_string = "";


        public static void Set_Connection_String(string datasource, string username, string password, string db)
        {
            con_server = datasource;
            con_login = username;
            con_password = password;
            con_database = db;

            Set_Connection_String();
        }

        public static void Set_Connection_String(int connection_id)
        {
            var connection = ConnectionSyntax.Get(connection_id);

            con_name = connection[0].name;
            con_server = connection[0].server;
            con_login = connection[0].login;
            con_password = connection[0].password;
            con_database = connection[0].database;

            Set_Connection_String();
        }

        public static void Set_Connection_String()
        {
            connection_string = "Data Source=" + con_server + ";Initial Catalog=" + con_database + ";Persist Security Info=True;User ID=" + con_login + ";Password=" + con_password + ";Connect Timeout=5";
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

                Static_Loading.error_message = ex.Message;
                return false;
            }
        }

    }
}