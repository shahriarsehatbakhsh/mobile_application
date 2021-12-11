using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mobile_application.Helper;
using mobile_application.Models;
using mobile_application.ServiceResponse;

namespace mobile_application
{
    public static class Header_Function
    {

        public static List<F_hSefareshSeller> temp_header = new List<F_hSefareshSeller>();
        public static List<F_dSefareshSeller> temp_details = new List<F_dSefareshSeller>();

        public static bool Add_Header_Temp(int CodeForooshande, int CodeMosavabe, int CodeMoshtari, short CodeShobe, int CodeSupervisor, int ModdateTasvie, int NoeTasvie, string TarikhBarge, string TarikheRooz)
        {
            try
            {
                var HeaderCodeSerial = Client.Header_Code_Serial(Convert.ToInt32(CodeShobe)).GetAwaiter().GetResult();
                var Customer_JobNo = Client.Customer_Job_No(Convert.ToInt32(CodeShobe), Convert.ToInt32(CodeMoshtari), TarikhBarge).GetAwaiter().GetResult();

                temp_header.Clear();
                temp_header.Add(new F_hSefareshSeller
                {
                    CodeForooshande = CodeForooshande,
                    CodeKarbar = Static_Loading.central_user_id,
                    CodeMosavabe = CodeMosavabe,
                    CodeMoshtari = CodeMoshtari,
                    CodeShobe = CodeShobe,
                    CodeSupervisor = CodeSupervisor,
                    ModdateTasvie = ModdateTasvie,
                    NoeTasvie = NoeTasvie,
                    Supervisor = 5,
                    TarikhBarge = TarikhBarge,
                    TarikheRooz = TarikheRooz,
                    sp_GetAvailableCustomerJob = Customer_JobNo[0].JobNo,
                    sp_GetLatestAvailableSefareshHeaderCode_HeaderCode = HeaderCodeSerial[0].HeaderCode,
                    sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial = HeaderCodeSerial[0].HeaderSerial
                });
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public static bool Add_Detail_Temp(int BranchCode, int CodeAnbaar, string CodeKala, string NameKala, long CodeKarbar, short CodeShobe, 
            decimal Mablagh, decimal Meghdar, string MoshtariCode, float Nerkh)
        {
            try
            {
                temp_details.Add(new F_dSefareshSeller
                {
                    BranchCode = BranchCode,
                    CodeAnbaar = CodeAnbaar,
                    CodeKala = CodeKala,
                    NameKala = NameKala,
                    CodeKarbar = CodeKarbar,
                    CodeShobe = CodeShobe,
                    Mablagh = Mablagh,
                    Meghdar = Meghdar,
                    MoshtariCode = MoshtariCode,
                    Nerkh = Nerkh,
                    ShomareRadif = Header_Function.temp_details.Count + 1,
                    NoeBaste = 1,
                    TarikhRooz = Static_Loading.today_date,
                    TedadBaste = 1,
                    ShomareBarge_Header = Header_Function.temp_header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderCode,
                    TedadDarHarBaste = 1
                });
                return true;
                
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public static string Save_Header()
        {
            try
            {
                var rHeader = Client.Insert_Order_Header(Static_Loading.central_BranchCode,
                                    Header_Function.temp_header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderCode,
                                    Header_Function.temp_header[0].TarikhBarge,
                                    Header_Function.temp_header[0].CodeMoshtari,
                                    Header_Function.temp_header[0].CodeForooshande,
                                    Header_Function.temp_header[0].CodeMosavabe,
                                    Header_Function.temp_header[0].NoeTasvie,
                                    Header_Function.temp_header[0].ModdateTasvie,
                                    Header_Function.temp_header[0].sp_GetAvailableCustomerJob,
                                    Header_Function.temp_header[0].sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial,
                                    5,
                                    Header_Function.temp_header[0].CodeSupervisor,
                                    Static_Loading.central_user_id,
                                    Header_Function.temp_header[0].TarikheRooz).GetAwaiter().GetResult();
                return rHeader[0].result;
            }
            catch (Exception ex)
            {
                return "Error" + ex.Message;
                throw;
            }
        }

        
    }
}
