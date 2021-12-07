using System;
using System.Collections.Generic;
using System.Text;
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

        public static bool Save_Header()
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public static bool Save_Details()
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
