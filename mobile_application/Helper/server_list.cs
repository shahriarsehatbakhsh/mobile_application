using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;
using mobile_application.Services;

namespace mobile_application.Helper
{
    public static class server_list
    {


        public static string ds_path => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "list.xml");
        public static DataSet ds_api_server_list;


        static string table_name = "api";


        public static void Init()
        {
            //File.Delete(ds_path);
            create();

            if (File.Exists(ds_path))
            {
                Read_xml();
                servers_list = fill_list();
                set_default_server();
            }
            else
            {
                Write_xml();
            }
        }

        public static void create()
        {
            ds_api_server_list = new DataSet();
            ds_api_server_list.Tables.Add(table_name);

            ds_api_server_list.Tables[table_name].Columns.Add("id");
            ds_api_server_list.Tables[table_name].Columns.Add("Name");
            ds_api_server_list.Tables[table_name].Columns.Add("IP");
            ds_api_server_list.Tables[table_name].Columns.Add("Port");
            ds_api_server_list.Tables[table_name].Columns.Add("Default");

            servers_list = new List<api_table>();
        }

        public static List<api_table> fill_list()
        {
            List<api_table> result = new List<api_table>();
            for (int i = 0; i < ds_api_server_list.Tables[table_name].Rows.Count; i++)
            {
                var id = ds_api_server_list.Tables[table_name].Rows[i][0];
                var Name = ds_api_server_list.Tables[table_name].Rows[i][1];
                var IP = ds_api_server_list.Tables[table_name].Rows[i][2];
                var Port = ds_api_server_list.Tables[table_name].Rows[i][3];
                var Default = ds_api_server_list.Tables[table_name].Rows[i][4];

                result.Add(
                        new api_table
                        {
                            id = Convert.ToInt32(id),
                            Name = Name.ToString(),
                            IP = IP.ToString(),
                            Port = Port.ToString(),
                            Default = Convert.ToBoolean(Default)
                        }
                    ) ;
            }
            return result;
        }

        public static bool Write_xml()
        {
            try
            {
                ds_api_server_list.Clear();
                int r = 0;
                foreach (var item in servers_list)
                {
                    ds_api_server_list.Tables[table_name].Rows.Add();

                    ds_api_server_list.Tables[table_name].Rows[r]["id"] = r+1;
                    ds_api_server_list.Tables[table_name].Rows[r]["Name"] = item.Name;
                    ds_api_server_list.Tables[table_name].Rows[r]["IP"] = item.IP;
                    ds_api_server_list.Tables[table_name].Rows[r]["Port"] = item.Port;
                    ds_api_server_list.Tables[table_name].Rows[r]["Default"] = item.Default;

                    r += 1;
                }
                ds_api_server_list.WriteXml(ds_path);
                return true;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                return false;
                throw;
            }
        }

        public static bool Read_xml()
        {
            try
            {
                ds_api_server_list.ReadXml(ds_path);
                return true;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                return false;
                throw;
            }
        }

        public static int count()
        {
            try
            {
                return ds_api_server_list.Tables[table_name].Rows.Count;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                return 0;
                throw;
            }
        }

        public static api_table defaul_server;
        public static List<api_table> servers_list = new List<api_table>();
        public static void set_default_server()
        {
            defaul_server = servers_list.Find(o => o.Default == true);
            if (defaul_server == null)
            {
                servers_list.Add(new api_table { id = 1, Name = "Default", IP = "127.0.0.1", Port = "21", Default = true });
                defaul_server = servers_list.Find(o => o.Default == true);
            }
            Service.set_api_url(server_list.defaul_server.IP, server_list.defaul_server.Port);
        }


        public static bool Delete(api_table item)
        {
            try
            {
                //servers_list.Find(o => o.id == id)
                servers_list.Remove(item);
                return true;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                Write_xml();
                return false;
                throw;
            }
        }

        public static bool Change_Default(api_table default_item)
        {
            try
            {
                foreach (var item in servers_list)
                {
                    item.Default = false;
                }
                servers_list.Find(o => o.id == default_item.id).Default = true;
                Write_xml();
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }


        public static bool Add(string name, string ip, string port, bool defaul)
        {
            try
            {
                servers_list.Add(new api_table
                {
                    id = servers_list.Count - 1,
                    Name = name,
                    IP = ip,
                    Port = port,
                    Default = defaul
                });

                Write_xml();
                return true;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
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