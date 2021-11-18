using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile_application.Service.Data;
using mobile_application.Service.Models;

namespace mobile_application.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MaliDBContext _context;

        public CustomersController(MaliDBContext context)
        {
            _context = context;
        }
                

        
        [HttpGet("List code_shobe={code_shobe}")]
        public async Task<ActionResult<IEnumerable<vw_customers_list>>> GetCustomersList(int code_shobe)
        {
            string StoredProc = "exec sp_customers_list_get_code_shobe @code_shobe=" + code_shobe;

            return await _context.vw_customers_list.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("GetLatestAvailableCustomerCode BranchCode={BranchCode}")]
        public async Task<ActionResult<IEnumerable<vw_customer_code_serial>>> GetLatestAvailableCustomerCode(int BranchCode)
        {
            string StoredProc = "exec GetLatestAvailableCustomerCode @BranchCode=" + BranchCode;

            return await _context.vw_customer_code_serial.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Insert code_shobe={code_shobe},sp_GetLatestAvailableCustomerCode_code={sp_GetLatestAvailableCustomerCode_code},Sharh={Sharh},sp_GetLatestAvailableCustomerCode_serial={sp_GetLatestAvailableCustomerCode_serial},CodeKarbareVaredShodeBeSystem={CodeKarbareVaredShodeBeSystem},TairkheRooz={TairkheRooz},CodePishe={CodePishe},CodeOstan={CodeOstan},CodeShahr={CodeShahr},CodeMantaghe={CodeMantaghe},CodeMasir={CodeMasir},Tel={Tel},Mobile={Mobile},Address={Address}")]
        public async Task<ActionResult<IEnumerable<ErrorResult>>> Insert(int CodeShobe, int sp_GetLatestAvailableCustomerCode_code, string Sharh, int sp_GetLatestAvailableCustomerCode_serial,int CodeKarbareVaredShodeBeSystem,string TairkheRooz, int CodePishe, int CodeOstan, int CodeShahr, int CodeMantaghe, int CodeMasir,string Tel, string Mobile, string Address)
        {
            string StoredProc = "exec sp_customer_insert @CodeShobe=" + CodeShobe + "," +
                                                                            "@sp_GetLatestAvailableCustomerCode_code=" + sp_GetLatestAvailableCustomerCode_code + "," +
                                                                            "@Sharh=" + Sharh + "," +
                                                                            "@sp_GetLatestAvailableCustomerCode_serial=" + sp_GetLatestAvailableCustomerCode_serial + "," +
                                                                            "@CodeKarbareVaredShodeBeSystem=" + CodeKarbareVaredShodeBeSystem + "," +
                                                                            "@TairkheRooz=" + TairkheRooz + "," +
                                                                            "@CodePishe=" + CodePishe + "," +
                                                                            "@CodeOstan=" + CodeOstan + "," +
                                                                            "@CodeShahr=" + CodeShahr + "," +
                                                                            "@CodeMantaghe=" + CodeMantaghe + "," +
                                                                            "@CodeMasir=" + CodeMasir + "," +
                                                                            "@Tel=" + Tel + "," +
                                                                            "@Mobile=" + Mobile + "," +
                                                                            "@Address=" + Address;

            return await _context.ErrorResult.FromSqlRaw(StoredProc).ToListAsync();
        }


    }
}
