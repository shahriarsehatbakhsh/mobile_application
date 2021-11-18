//using System;
//using System.Collections.Generic;

//using mobile_application.Services.Models;
//using System.Data;
//using System.Data.SqlClient;
//using System.Threading.Tasks;

namespace mobile_application.Client
{
    public static class sp
    {


        //public static List<vw_customers_list_get_code_shobe> Customers_list(int shobe_code)
        //{
        //    try
        //    {
        //        string constring = Client.connection_string;
        //        List<vw_customers_list_get_code_shobe> result = new List<vw_customers_list_get_code_shobe>();
        //        using (SqlConnection con = new SqlConnection(constring))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("exec sp_customers_list_get_code_shobe @code_shobe", con))
        //            {
        //                cmd.Parameters.Add("@code_shobe", SqlDbType.Int);
        //                cmd.Parameters["@code_shobe"].Value = shobe_code;

        //                cmd.CommandType = CommandType.Text;
        //                con.Open();
        //                using (SqlDataReader sdr = cmd.ExecuteReader())
        //                {
        //                    while (sdr.Read())
        //                    {
        //                        result.Add(new vw_customers_list_get_code_shobe
        //                        {
        //                            Code = Convert.ToInt32(sdr["code"]),
        //                            Sharh = sdr["Sharh"].ToString(),
        //                            Job = sdr["Job"].ToString(),
        //                            Address = sdr["Address"].ToString(),
        //                            Tel = sdr["Tel"].ToString(),
        //                            Branch = Convert.ToInt16(sdr["Branch"])
        //                        });
        //                    }
        //                }
        //                con.Close();
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.Static_Loading.error_message = ex.Message;
        //        return null;
        //        throw;
        //    }
        //}


        //public static List<vw_objects_list_get_object_name> Objects_List_Get_Object_Names(string objName)
        //{
        //    string constring = Client.connection_string;
        //    List<vw_objects_list_get_object_name> result = new List<vw_objects_list_get_object_name>();
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("exec sp_objects_list_get_object_name @object_name", con))
        //        {
        //            cmd.Parameters.Add("@object_name", SqlDbType.NVarChar);
        //            cmd.Parameters["@object_name"].Value = objName;

        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    result.Add(new vw_objects_list_get_object_name
        //                    {
        //                        Code = Convert.ToInt32(sdr["code"]),
        //                        Sharh = sdr["Sharh"].ToString(),
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}


        //public static List<vw_shobe_list> Shobe_List(int code_karbar,int code_karbar_per)
        //{
        //    string constring = Client.connection_string;
        //    List<vw_shobe_list> result = new List<vw_shobe_list>();
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("exec sp_shobe_list @code_karbar,@code_karbar_per", con))
        //        {
        //            cmd.Parameters.Add("@code_karbar", SqlDbType.Int);
        //            cmd.Parameters["@code_karbar"].Value = code_karbar;

        //            cmd.Parameters.Add("@code_karbar_per", SqlDbType.NVarChar);
        //            cmd.Parameters["@code_karbar_per"].Value = code_karbar_per;

        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    result.Add(new vw_shobe_list
        //                    {
        //                        Code = Convert.ToInt32(sdr["code"]),
        //                        Sharh = sdr["Sharh"].ToString(),
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}


        //public static List<vw_seller_list> Seller_List(int shobe_code,int code_karbar)
        //{
        //    string constring = Client.connection_string;
        //    List<vw_seller_list> result = new List<vw_seller_list>();
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("exec sp_seller_list @code_karbar,@code_shobe", con))
        //        {
        //            cmd.Parameters.Add("@code_karbar", SqlDbType.Int);
        //            cmd.Parameters["@code_karbar"].Value = code_karbar;

        //            cmd.Parameters.Add("@code_shobe", SqlDbType.Int);
        //            cmd.Parameters["@code_shobe"].Value = shobe_code;

        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    result.Add(new vw_seller_list
        //                    {
        //                        Code = Convert.ToInt32(sdr["code"]),
        //                        Sharh = sdr["Sharh"].ToString(),
        //                        Job = sdr["Job"].ToString(),
        //                        Address = sdr["Address"].ToString(),
        //                        Tel = sdr["Tel"].ToString(),
        //                        Branch = Convert.ToInt16(sdr["Branch"])
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}


        //public static List<vw_supervizer_list> Supervizer_List(int shobe_code, int code_karbar)
        //{
        //    string constring = Client.connection_string;
        //    List<vw_supervizer_list> result = new List<vw_supervizer_list>();
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("exec sp_supervizer_list @code_karbar,@code_shobe", con))
        //        {
        //            cmd.Parameters.Add("@code_karbar", SqlDbType.Int);
        //            cmd.Parameters["@code_karbar"].Value = code_karbar;

        //            cmd.Parameters.Add("@code_shobe", SqlDbType.Int);
        //            cmd.Parameters["@code_shobe"].Value = shobe_code;

        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    result.Add(new vw_supervizer_list
        //                    {
        //                        Code = Convert.ToInt32(sdr["code"]),
        //                        Sharh = sdr["Sharh"].ToString(),
        //                        Job = sdr["Job"].ToString(),
        //                        Address = sdr["Address"].ToString(),
        //                        Tel = sdr["Tel"].ToString(),
        //                        Branch = Convert.ToInt16(sdr["Branch"])
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}


        //public static List<vw_customer_code_serial> Customer_Get_Code_Serial(int shobe_code)
        //{
        //    string constring = Client.connection_string;
        //    List<vw_customer_code_serial> result = new List<vw_customer_code_serial>();
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("exec sp_GetLatestAvailableCustomerCode @BranchCode", con))
        //        {
        //            cmd.Parameters.Add("@BranchCode", SqlDbType.Int);
        //            cmd.Parameters["@BranchCode"].Value = shobe_code;

        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    result.Add(new vw_customer_code_serial
        //                    {
        //                        CustomerCode = Convert.ToInt32(sdr["CustomerCode"]),
        //                        CustomerSerial = Convert.ToInt32(sdr["CustomerSerial"])
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}

        //public static async Task<bool> Customer_Insert(int CodeShobe, int sp_GetLatestAvailableCustomerCode_code,string Sharh,int sp_GetLatestAvailableCustomerCode_serial,
        //                                   int CodeKarbareVaredShodeBeSystem,
        //                                   string TairkheRooz,int CodePishe,int CodeOstan,int CodeShahr,int CodeMantaghe,int CodeMasir,
        //                                   string Tel,string Mobile,string Address)
        //{
        //    string constring = Client.connection_string;
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("exec sp_customer_insert @CodeShobe," +
        //                                                                    "@sp_GetLatestAvailableCustomerCode_code," +
        //                                                                    "@Sharh," +
        //                                                                    "@sp_GetLatestAvailableCustomerCode_serial," +
        //                                                                    "@CodeKarbareVaredShodeBeSystem," +
        //                                                                    "@TairkheRooz," +
        //                                                                    "@CodePishe," +
        //                                                                    "@CodeOstan," +
        //                                                                    "@CodeShahr," +
        //                                                                    "@CodeMantaghe," +
        //                                                                    "@CodeMasir," +
        //                                                                    "@Tel," +
        //                                                                    "@Mobile," +
        //                                                                    "@Address", con))
        //        {
        //            try
        //            {
        //                //var Factoryparam = !string.IsNullOrEmpty(Factory) ? new SqlParameter("factory", Factory) : new SqlParameter("factory", DBNull.Value);
        //                var CodeShobe_param = new SqlParameter("@CodeShobe", CodeShobe);
        //                var sp_GetLatestAvailableCustomerCode_code_param = new SqlParameter("@sp_GetLatestAvailableCustomerCode_code", sp_GetLatestAvailableCustomerCode_code);
        //                var Sharh_param = new SqlParameter("@Sharh", Sharh);
        //                var sp_GetLatestAvailableCustomerCode_serial_param = new SqlParameter("@sp_GetLatestAvailableCustomerCode_serial", sp_GetLatestAvailableCustomerCode_serial);
        //                var CodeKarbareVaredShodeBeSystem_param = new SqlParameter("@CodeKarbareVaredShodeBeSystem", CodeKarbareVaredShodeBeSystem);
        //                var TairkheRooz_param = new SqlParameter("@TairkheRooz", TairkheRooz);
        //                var CodePishe_param = new SqlParameter("@CodePishe", CodePishe);
        //                var CodeOstan_param = new SqlParameter("@CodeOstan", CodeOstan);
        //                var CodeShahr_param = new SqlParameter("@CodeShahr", CodeShahr);
        //                var CodeMantaghe_param = new SqlParameter("@CodeMantaghe", CodeMantaghe);
        //                var CodeMasir_param = new SqlParameter("@CodeMasir", CodeMasir);
        //                var Tel_param = new SqlParameter("@Tel", Tel);
        //                var Mobile_param = new SqlParameter("@Mobile", Mobile);
        //                var Address_param = new SqlParameter("@Address", Address);

        //                cmd.Parameters.Add(CodeShobe_param);
        //                cmd.Parameters.Add(sp_GetLatestAvailableCustomerCode_code_param);
        //                cmd.Parameters.Add(Sharh_param);
        //                cmd.Parameters.Add(sp_GetLatestAvailableCustomerCode_serial_param);
        //                cmd.Parameters.Add(CodeKarbareVaredShodeBeSystem_param);
        //                cmd.Parameters.Add(TairkheRooz_param);
        //                cmd.Parameters.Add(CodePishe_param);
        //                cmd.Parameters.Add(CodeOstan_param);
        //                cmd.Parameters.Add(CodeShahr_param);
        //                cmd.Parameters.Add(CodeMantaghe_param);
        //                cmd.Parameters.Add(CodeMasir_param);
        //                cmd.Parameters.Add(Tel_param);
        //                cmd.Parameters.Add(Mobile_param);
        //                cmd.Parameters.Add(Address_param);


        //                cmd.CommandType = CommandType.Text;
        //                con.Open();
        //                var R = cmd.ExecuteNonQueryAsync();
        //                con.Close();

        //                return true;
        //            }
        //            catch (Exception)
        //            {
        //                return false;
        //                throw;
        //            }
        //        }
        //    }
        //}






        #region [Code_Sharh_List].

        //public enum exec
        //{
        //    sp_pishe_list,
        //    sp_ostan_list,
        //    sp_shahr_list,
        //    sp_mantaghe_list,
        //    sp_masir_list
        //}

        //public static List<vw_code_sharh> Code_Sharh_List(exec exec)
        //{
        //    string constring = Client.connection_string;
        //    List<vw_code_sharh> objects = new List<vw_code_sharh>();
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        string query;
        //        switch (exec)
        //        {
        //            case exec.sp_pishe_list:
        //                query = "exec sp_pishe_list";
        //                break;
        //            case exec.sp_ostan_list:
        //                query = "exec sp_ostan_list";
        //                break;
        //            case exec.sp_shahr_list:
        //                query = "exec sp_shahr_list";
        //                break;
        //            case exec.sp_mantaghe_list:
        //                query = "exec sp_mantaghe_list";
        //                break;
        //            case exec.sp_masir_list:
        //                query = "exec sp_masir_list";
        //                break;
        //            default:
        //                query = "";
        //                break;
        //        }
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    objects.Add(new vw_code_sharh
        //                    {
        //                        Code = Convert.ToInt32(sdr["code"]),
        //                        Sharh = sdr["Sharh"].ToString(),
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return objects;
        //}

        #endregion

    }

}
