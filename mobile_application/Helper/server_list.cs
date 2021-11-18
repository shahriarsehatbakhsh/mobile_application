using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;

namespace mobile_application.Helper
{
    public static class server_list
    {

        public static string ds_path => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "list.xml");

        public static DataSet api_server_list;


        static string table_name = "api";
        public static void Init()
        {
            api_server_list = new DataSet();
            api_server_list.Tables.Add(table_name);

            api_server_list.Tables[table_name].Columns.Add("id");
            api_server_list.Tables[table_name].Columns.Add("Name");
            api_server_list.Tables[table_name].Columns.Add("IP");
            api_server_list.Tables[table_name].Columns.Add("Port");
            api_server_list.Tables[table_name].Columns.Add("Default");

            Read();
        }

        public static bool Write()
        {
            api_server_list.Tables[table_name].WriteXml(ds_path);
            return true;
        }

        public static bool Read()
        {
            if (File.Exists(ds_path))
            {
                api_server_list.Tables[table_name].ReadXml(ds_path);
                return true;
            }
            else
            {
                Write();
                Read();
                return true;
            }
        }

        public static int count()
        {
            return api_server_list.Tables[table_name].Rows.Count;
        }


        public static bool Add(string name,string ip,string port,bool defaul)
        {
            try
            {
                var r = api_server_list.Tables[table_name].Rows.Count - 1;


                api_server_list.Tables[table_name].Rows.Add
                    (
                    new api_table 
                    { 
                        id = r, 
                        Name = name,
                        IP = ip, 
                        Port = port ,
                        Default = defaul
                    });

                Write();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }

    public class api_table
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public bool Default { get; set; }
    }
}
