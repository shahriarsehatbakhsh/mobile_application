using System;
using System.Collections.Generic;

using mobile_application.Services.Models;
using System.Data;
using System.Data.SqlClient;

namespace mobile_application.Services
{
    public static class sp
    {
        public static List<vw_customers_list_get_code_shobe> Customers_list(int shobe_code)
        {
            string constring = Client.connection_string;
            List<vw_customers_list_get_code_shobe> customers = new List<vw_customers_list_get_code_shobe>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("exec sp_customers_list_get_code_shobe @code_shobe", con))
                {
                    cmd.Parameters.Add("@code_shobe", SqlDbType.Int);
                    cmd.Parameters["@code_shobe"].Value = shobe_code;
                    
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new vw_customers_list_get_code_shobe
                            {
                                Code = Convert.ToInt32(sdr["code"]),
                                Sharh = sdr["Sharh"].ToString(),
                                Job = sdr["Job"].ToString(),
                                Address = sdr["Address"].ToString(),
                                Tel = sdr["Tel"].ToString(),
                                Branch = Convert.ToInt16(sdr["Branch"])
                            });
                        }
                    }
                    con.Close();
                }
            }
            return customers;
        }






        public static List<vw_objects_list_get_object_name> Objects_List_Get_Object_Names(string objName)
        {
            string constring = Client.connection_string;
            List<vw_objects_list_get_object_name> objects = new List<vw_objects_list_get_object_name>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("exec sp_objects_list_get_object_name @object_name", con))
                {
                    cmd.Parameters.Add("@object_name", SqlDbType.NVarChar);
                    cmd.Parameters["@object_name"].Value = objName;

                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            objects.Add(new vw_objects_list_get_object_name
                            {
                                Code = Convert.ToInt32(sdr["code"]),
                                Sharh = sdr["Sharh"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }
            return objects;
        }



        public static List<vw_shobe_list> Shobe_List(int code_karbar,int code_karbar_per)
        {
            string constring = Client.connection_string;
            List<vw_shobe_list> objects = new List<vw_shobe_list>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("exec sp_shobe_list @code_karbar,@code_karbar_per", con))
                {
                    cmd.Parameters.Add("@code_karbar", SqlDbType.Int);
                    cmd.Parameters["@code_karbar"].Value = code_karbar;

                    cmd.Parameters.Add("@code_karbar_per", SqlDbType.NVarChar);
                    cmd.Parameters["@code_karbar_per"].Value = code_karbar_per;

                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            objects.Add(new vw_shobe_list
                            {
                                Code = Convert.ToInt32(sdr["code"]),
                                Sharh = sdr["Sharh"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }
            return objects;
        }



        public static List<vw_seller_list> Seller_List(int shobe_code,int code_karbar)
        {
            string constring = Client.connection_string;
            List<vw_seller_list> customers = new List<vw_seller_list>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("exec sp_seller_list @code_karbar,@code_shobe", con))
                {
                    cmd.Parameters.Add("@code_karbar", SqlDbType.Int);
                    cmd.Parameters["@code_karbar"].Value = code_karbar;

                    cmd.Parameters.Add("@code_shobe", SqlDbType.Int);
                    cmd.Parameters["@code_shobe"].Value = shobe_code;

                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new vw_seller_list
                            {
                                Code = Convert.ToInt32(sdr["code"]),
                                Sharh = sdr["Sharh"].ToString(),
                                Job = sdr["Job"].ToString(),
                                Address = sdr["Address"].ToString(),
                                Tel = sdr["Tel"].ToString(),
                                Branch = Convert.ToInt16(sdr["Branch"])
                            });
                        }
                    }
                    con.Close();
                }
            }
            return customers;
        }
    }
}
