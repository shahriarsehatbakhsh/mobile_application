
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using mobile_application.Models;
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

        public static async Task<IList<vw_customer_cart_result>> Customer_Cart_New(int BranchCode, int CustomerCode, long UserCode)
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

        public static async Task<IList<vw_code_sharh>> Objects_List(int BranchCode,string ObjectName = null)
        {
            try
            {
                IList<vw_code_sharh> Result = null;
                HttpClient client_users = new HttpClient();
                string url = "";
                if (ObjectName == null)
                    url = Static_Loading.api_url() + "Objects/ObjectsList BranchCode=" + BranchCode ;
                else
                    url = Static_Loading.api_url() + "Objects/ObjectsList BranchCode=" + BranchCode + " ObjectName='" + ObjectName + "'";

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


        public static async Task<IList<vw_seller_list>> Seller_List(long code_karbar, int code_shobe)
        {
            try
            {
                IList<vw_seller_list> Result = null;
                HttpClient client_users = new HttpClient();
                string url = Static_Loading.api_url() + "List/seller code_karbar=" + Static_Loading.central_user_id + ",code_shobe=" + Static_Loading.central_BranchCode;
                var Response = client_users.GetAsync(url);
                var Mystring = Response.GetAwaiter().GetResult();
                Response.Wait();
                using (HttpContent content = Mystring.Content)
                {
                    var Json = content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<List<vw_seller_list>>(Json.Result);
                }
                return Result;
            }
            catch (System.Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <param name="HeaderCode">sp_GetLatestAvailableSefareshHeaderCode_HeaderCode</param>
        /// <param name="TarikhBarge"></param>
        /// <param name="CodeMoshtari"></param>
        /// <param name="CodeForooshande"></param>
        /// <param name="CodeMosavabe"></param>
        /// <param name="NoeTasvie"></param>
        /// <param name="ModdateTasvie"></param>
        /// <param name="CustomerJob">sp_GetAvailableCustomerJob</param>
        /// <param name="HeaderSerial">sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial</param>
        /// <param name="Supervisor">Supervisor is fix=5</param>
        /// <param name="CodeSupervisor"></param>
        /// <param name="CodeKarbar"></param>
        /// <param name="TarikheRooz"></param>
        /// <returns></returns>
        public static async Task<IList<vw_result>> Insert_Order_Header(int BranchCode,long HeaderCode,string TarikhBarge,int CodeMoshtari,int CodeForooshande,int CodeMosavabe,int NoeTasvie,int ModdateTasvie,int CustomerJob,long HeaderSerial,int Supervisor,int CodeSupervisor,long CodeKarbar,string TarikheRooz)
        {
            try
            {
                IList<vw_result> Result = null;
                HttpClient client_users = new HttpClient();

                TarikhBarge = TarikhBarge.Replace("/", "D");
                TarikheRooz = TarikheRooz.Replace("/", "D");

                string url = Static_Loading.api_url() + "SefareshSeller/InsertHeader CodeShobe=" + BranchCode + "," +
                                                        "HeaderCode=" + HeaderCode + "," +
                                                        "TarikhBarge=" + TarikhBarge + "," +
                                                        "CodeMoshtari=" + CodeMoshtari + "," +
                                                        "CodeForooshande=" + CodeForooshande + "," +
                                                        "CodeMosavabe=" + CodeMosavabe + "," +
                                                        "NoeTasvie=" + NoeTasvie + "," +
                                                        "ModdateTasvie=" + ModdateTasvie + "," +
                                                        "CustomerJob=" + CustomerJob + "," +
                                                        "HeaderSerial=" + HeaderSerial + "," +
                                                        "Supervisor=5,CodeSupervisor=" + CodeSupervisor + "," +
                                                        "CodeKarbar=" + CodeKarbar + "," +
                                                        "TarikheRooz=" + TarikheRooz ;
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


        public static async Task<IList<vw_result>> Insert_Order_Detail(int BranchCode, long ShomareBarge_Header, int ShomareRadif, int CodeAnbaar, string CodeKala, decimal Meghdar, float Nerkh, decimal Mablagh, int NoeBaste, decimal TedadBaste, decimal TedadDarHarBaste, long CodeKarbar, string TarikhRooz,string MoshtariCode)
        {
            try
            {
                List<vw_result> Result = null;
                HttpClient client_users = new HttpClient();
                TarikhRooz = TarikhRooz.Replace("/", "D");
                string url = Static_Loading.api_url() + "SefareshSeller/InsertDetail CodeShobe=" + BranchCode + "," +
                                                                                    "ShomareBarge_Header=" + ShomareBarge_Header + "," +
                                                                                    "ShomareRadif=" + ShomareRadif + "," +
                                                                                    "CodeAnbaar=" + CodeAnbaar + "," +
                                                                                    "CodeKala=" + CodeKala + "," +
                                                                                    "Meghdar=" + Meghdar + "," +
                                                                                    "Nerkh=" + Nerkh + "," +
                                                                                    "Mablagh=" + Mablagh + "," +
                                                                                    "NoeBaste=" + NoeBaste + "," +
                                                                                    "TedadBaste=" + TedadBaste + "," +
                                                                                    "TedadDarHarBaste=" + TedadDarHarBaste + "," +
                                                                                    "CodeKarbar=" + CodeKarbar + "," +
                                                                                    "TarikhRooz=" + TarikhRooz + "," +
                                                                                    "BranchCode=" + BranchCode + "," +
                                                                                    "MoshtariCode=" + MoshtariCode;
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


    }
}