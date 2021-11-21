
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using mobile_application.Service.Models;
using System.Collections.Generic;
using mobile_application.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace mobile_application.ServiceResponse
{
    public static class Client
    {
        public static async Task<IList<vw_Resault>> Check_User_Name_Password(string Username, string Password)
        {
            try
            {
                IList<vw_Resault> Result = null;
                HttpClient client_users = new HttpClient();
                string url = Static_Loading.api_url() + "Users/CentralLogin Username=" + Username + ",Password=" + Password;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_Resault>>(Json.Result);
                }
                return Result;
            }
            catch (System.Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<IList<vw_customer_cart_result>> Customer_Cart_New(int BranchCode, int CustomerCode, int UserCode)
        {
            try
            {
                //HttpClient client = new HttpClient();
                //var url = Static_Loading.api_url() + "Customers/Customer_Cart_New BranchCode=" + BranchCode + ",CustomerCode=" + CustomerCode + ",UserCode=" + UserCode;
                //var json = await client.GetStringAsync(url);
                //List<vw_customer_cart_result> result = JsonConvert.DeserializeObject<List<vw_customer_cart_result>>(json);
                //return result;


                IList<vw_customer_cart_result> Result = null;
                HttpClient client_users = new HttpClient();
                var url = Static_Loading.api_url() + "Customers/Customer_Cart_New BranchCode=" + BranchCode + ",CustomerCode=" + CustomerCode + ",UserCode=" + UserCode;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_customer_cart_result>>(Json.Result);
                }
                return Result;
            }
            catch (System.Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }


        public static async Task<IList<vw_code_sharh>> ObjectCodeName_Search(string object_name)
        {
            try
            {
                IList<vw_code_sharh> Result = null;
                HttpClient client_users = new HttpClient();
                string url = Static_Loading.api_url() + "List/ObjectCodeName object_name=" + object_name;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(Json.Result);
                }

                return Result;
            }
            catch (System.Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }


    }
}