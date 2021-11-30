
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

        public static async Task<IList<vw_result>> Check_User_Name_Password(string Username, string Password)
        {
            try
            {
                IList<vw_result> Result = null;
                HttpClient client_users = new HttpClient();
                string url = Static_Loading.api_url() + "Users/CentralLogin Username=" + Username + ",Password=" + Password;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_result>>(Json.Result);
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

        public static async Task<IList<vw_result>> Customer_Cart_Pishe_State(int BranchCode, int CustomerCode, string BargeDate)
        {
            try
            {
                //HttpClient client = new HttpClient();
                //var url = Static_Loading.api_url() + "Customers/Customer_Cart_New BranchCode=" + BranchCode + ",CustomerCode=" + CustomerCode + ",UserCode=" + UserCode;
                //var json = await client.GetStringAsync(url);
                //List<vw_customer_cart_result> result = JsonConvert.DeserializeObject<List<vw_customer_cart_result>>(json);
                //return result;


                IList<vw_result> Result = null;
                HttpClient client_users = new HttpClient();
                BargeDate = BargeDate.Replace("/", "D");
                var url = Static_Loading.api_url() + "Customers/customer_state BranchCode=" + BranchCode + ",CustomerCode=" + CustomerCode + ",BargeDate=" + BargeDate;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_result>>(Json.Result);
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

        public static async Task<IList<vw_code_sharh>> Objects_List()
        {
            try
            {
                IList<vw_code_sharh> Result = null;
                HttpClient client_users = new HttpClient();
                string url = Static_Loading.api_url() + "Objects/ObjectsList";
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

        public static async Task<IList<vw_code_sharh>> Object_Nerkh(int BranchCode, int MosavabeCode, int ObjectCode)
        {
            try
            {
                IList<vw_code_sharh> Result = null;
                HttpClient client_users = new HttpClient();
                string url = Static_Loading.api_url() + "Objects/ObjectNerkh BranchCode=" + BranchCode + ",MosavabeCode=" + MosavabeCode + ",ObjectCode=" + ObjectCode;
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

        public static async Task<IList<vw_header_CodeSerial>> Header_Code_Serial(int BranchCode)
        {
            try
            {
                IList<vw_header_CodeSerial> Result = null;
                HttpClient client_users = new HttpClient();
                string url = Static_Loading.api_url() + "SefareshSeller/HeaderCodeSerial BranchCode=" + BranchCode ;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_header_CodeSerial>>(Json.Result);
                }
                return Result;
            }
            catch (System.Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }


        
        public static async Task<IList<vw_JobNo>> Customer_Job_No(int BranchCode, int CustomerCode, string SefareshDate)
        {
            try
            {
                IList<vw_JobNo> Result = null;
                HttpClient client_users = new HttpClient();
                SefareshDate = SefareshDate.Replace("/", "D");
                string url = Static_Loading.api_url() + "Customers/GetAvailableCustomerJob BranchCode=" + BranchCode + ",CustomerCode=" + CustomerCode + ",SefareshDate=" + SefareshDate;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_JobNo>>(Json.Result);
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