
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
    }
}