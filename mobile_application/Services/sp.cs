using System;
using System.Collections.Generic;
using System.Text;

using mobile_application.Services;
using mobile_application.Services.Models;
using System.Data;
using System.Data.SqlClient;

namespace mobile_application.Services
{
    public static class sp
    {
        public static IList<vw_customers_list_get_code_shobe> Customers_list(int shobe_code)
        {
            string constring = Client.connection_string;
            IList<vw_customers_list_get_code_shobe> customers = new List<vw_customers_list_get_code_shobe>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("exec customers_list_get_code_shobe @code_shobe", con))
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
    }
}
