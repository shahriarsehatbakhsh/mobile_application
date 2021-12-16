using System;
using System.Text;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using mobile_application.Models;
using Newtonsoft.Json;
using mobile_application.Helper;

namespace mobile_application.Services
{
    public static class Service
    {

        private static string _api_url;
        public static void set_api_url(string ip, string port)
        {
            _api_url = "http://" + ip + ":" + port + "/";
        }
        
        public static string api_url => _api_url;
        

        public static async Task<IList<vw_result>> Check_User_Name_Password(string Username, string Password)
        {
            try
            {
                IList<vw_result> Result = null;
                HttpClient client = new HttpClient();
                string url = _api_url + "Users/CentralLogin/" + Username + "/" + Password;
                var Response = client.GetAsync(url);
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
                IList<vw_customer_cart_result> Result = null;
                HttpClient client_users = new HttpClient();
                var url = _api_url + "Customers/Customer_Cart_New/" + BranchCode + "/" + CustomerCode + "/" + UserCode;
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
                IList<vw_result> Result = null;
                HttpClient client_users = new HttpClient();
                BargeDate = BargeDate.Replace("/", "D");
                var url = _api_url + "Customers/customer_state/" + BranchCode + "/" + CustomerCode + "/" + BargeDate;
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
                string url = _api_url + "List/ObjectCodeName/" + object_name;
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

        public static async Task<IList<vw_code_sharh>> Objects_List(int BranchCode, string ObjectName = null)
        {
            try
            {
                IList<vw_code_sharh> Result = null;
                HttpClient client_users = new HttpClient();
                string url = "";
                if (ObjectName == null)
                    url = _api_url + "Objects/ObjectsList/" + BranchCode;
                else
                    url = _api_url + "Objects/ObjectsList/" + BranchCode + "/" + ObjectName ;

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
                string url = _api_url + "Objects/ObjectNerkh/" + BranchCode + "/" + MosavabeCode + "/" + ObjectCode;
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
                string url = _api_url + "SefareshSeller/HeaderCodeSerial/" + BranchCode;
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
                string url = _api_url + "Customers/GetAvailableCustomerJob/" + BranchCode + "/" + CustomerCode + "/" + SefareshDate;
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
                string url = _api_url + "List/seller/" + Static_Loading.central_user_id + "/" + Static_Loading.central_BranchCode;
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

        public static async Task<IList<vw_result>> Insert_Order_Header(int BranchCode, long HeaderCode, string TarikhBarge, int CodeMoshtari, int CodeForooshande, int CodeMosavabe, int NoeTasvie, int ModdateTasvie, int CustomerJob, long HeaderSerial, int Supervisor, int CodeSupervisor, long CodeKarbar, string TarikheRooz)
        {
            try
            {
                IList<vw_result> Result = null;
                HttpClient client_users = new HttpClient();

                TarikhBarge = TarikhBarge.Replace("/", "D");
                TarikheRooz = TarikheRooz.Replace("/", "D");

                string url = _api_url + "SefareshSeller/InsertHeader/" + BranchCode + 
                                                        "/" + HeaderCode + 
                                                        "/" + TarikhBarge + 
                                                        "/" + CodeMoshtari + 
                                                        "/" + CodeForooshande + 
                                                        "/" + CodeMosavabe + 
                                                        "/" + NoeTasvie + 
                                                        "/" + ModdateTasvie + 
                                                        "/" + CustomerJob + 
                                                        "/" + HeaderSerial + 
                                                        "/5/" + CodeSupervisor + 
                                                        "/" + CodeKarbar + 
                                                        "/" + TarikheRooz;
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

        public static async Task<IList<vw_result>> Insert_Order_Detail(int BranchCode, long ShomareBarge_Header, int ShomareRadif, int CodeAnbaar, string CodeKala, decimal Meghdar, float Nerkh, decimal Mablagh, int NoeBaste, decimal TedadBaste, decimal TedadDarHarBaste, long CodeKarbar, string TarikhRooz, string MoshtariCode)
        {
            try
            {
                List<vw_result> Result = null;
                HttpClient client_users = new HttpClient();
                TarikhRooz = TarikhRooz.Replace("/", "D");
                string url = _api_url + "SefareshSeller/InsertDetail/" + BranchCode + "/" + ShomareBarge_Header + 
                                                                                    "/" + ShomareRadif + 
                                                                                    "/" + CodeAnbaar + 
                                                                                    "/" + CodeKala + 
                                                                                    "/" + Meghdar + 
                                                                                    "/" + Nerkh + 
                                                                                    "/" + Mablagh + 
                                                                                    "/" + NoeBaste + 
                                                                                    "/" + TedadBaste + 
                                                                                    "/" + TedadDarHarBaste + 
                                                                                    "/" + CodeKarbar + 
                                                                                    "/" + TarikhRooz + 
                                                                                    "/" + BranchCode + 
                                                                                    "/" + MoshtariCode;
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

        public static async Task<List<vw_customer_information>> customer_Information(int CustomerCode, int BranchCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = client.GetStringAsync(api_url + "Customers/Customer_Information/" + CustomerCode + "/" + BranchCode);
                List<vw_customer_information> result = JsonConvert.DeserializeObject<List<vw_customer_information>>(json.GetAwaiter().GetResult());
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> List_Shobe(long central_user_id, int central_user_per)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(api_url + "List/Shobe/" + central_user_id + "/" + central_user_per);
                List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> List_Mosavabe(string TarikhBarge, int BranchCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                var strDate = TarikhBarge.Replace("/", "D");
                var json = await client.GetStringAsync(api_url + "List/mosavabe_list/" + strDate + "/" + BranchCode);
                List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_supervizer_list>> Supervizer_List(long central_user_id, int BranchCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(api_url + "List/supervizer/" + central_user_id + "/" + BranchCode);
                List<vw_supervizer_list> result = JsonConvert.DeserializeObject<List<vw_supervizer_list>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Objects_List(string obj)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(api_url + "List/ObjectCodeName/" + obj);
                List<vw_code_sharh> result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_customers_list>> Customers_List(int BranchCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "Customers/CustomersList/" + BranchCode;
                var json = await client.GetStringAsync(url);
                List<vw_customers_list> result = JsonConvert.DeserializeObject<List<vw_customers_list>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_result>> Mojoodi_Anbar(int AnbarCode, string ObjectCode)
        {
            try
            {
                ObjectCode = function_static.Create_Kala_Code(ObjectCode);

                HttpClient client = new HttpClient();
                string url = api_url + "Anbar/Mojoodi_Anbar/" + AnbarCode + "/" + ObjectCode;
                var json = await client.GetStringAsync(url) ;
                List<vw_result> result = JsonConvert.DeserializeObject<List<vw_result>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_result>> Mojoodi_Anbar_BargeDate(string TarikhBarge,int AnbarCode, string ObjectCode)
        {
            try
            {
                ObjectCode = function_static.Create_Kala_Code(ObjectCode);
                TarikhBarge = TarikhBarge.Replace("/", "D");

                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(api_url + "Anbar/Mojoodi_Anbar_BargeDate/" + TarikhBarge + "/" + AnbarCode + "/" + ObjectCode);
                List<vw_result> result = JsonConvert.DeserializeObject<List<vw_result>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Anbar_List(int BranchCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "List/anbar_list/" + BranchCode;
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Masir_List()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "Lists/Masir";
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Mantaghe_List()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "Lists/Masir";
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Shahr_List()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "Lists/Shahr";
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Ostan_List()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "Lists/Ostan";
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Pishe_List()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "Lists/Pishe";
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_code_sharh>> Branch_List(long central_user_id, int central_user_per)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = api_url + "List/Shobe/" + central_user_id + "/" + central_user_per;
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<vw_code_sharh>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<vw_customer_code_serial>> GetLatestAvailableCustomerCode(int BranchCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(api_url + "Customers/GetLatestAvailableCustomerCode/" + BranchCode);
                var result = JsonConvert.DeserializeObject<List<vw_customer_code_serial>>(json);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }

        public static async Task<List<ErrorResult>> Customer_Insert(int BranchCode, int sp_GetLatestAvailableCustomerCode_code,string Sharh, int sp_GetLatestAvailableCustomerCode_serial, long CodeKarbareVaredShodeBeSystem, string TairkheRooz, int CodePishe, int CodeOstan, int CodeShahr, int CodeMantaghe, int CodeMasir, string Tel, string Mobile, string Address)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json_insert = await client.GetStringAsync(api_url + "Customers/Insert/" + BranchCode + ",sp_GetLatestAvailableCustomerCode_code=" + sp_GetLatestAvailableCustomerCode_code + ",Sharh=" + Sharh + "," +
                "sp_GetLatestAvailableCustomerCode_serial=" + sp_GetLatestAvailableCustomerCode_serial + "," +
                "CodeKarbareVaredShodeBeSystem=" + CodeKarbareVaredShodeBeSystem + "," +
                "TairkheRooz=" + TairkheRooz + "," +
                "CodePishe=" + CodePishe + "," +
                "CodeOstan=" + CodeOstan + "," +
                "CodeShahr=" + CodeShahr + "," +
                "CodeMantaghe=" + CodeMantaghe + "," +
                "CodeMasir=" + CodeMasir + "," +
                "Tel=" + Tel + "," +
                "Mobile=" + Mobile + ",Address=" + Address + "?CodeShobe=1");
                var result = JsonConvert.DeserializeObject<List<ErrorResult>>(json_insert);
                return result;
            }
            catch (Exception ex)
            {
                Static_Loading.error_message = ex.Message;
                throw;
            }
        }


    }
}
