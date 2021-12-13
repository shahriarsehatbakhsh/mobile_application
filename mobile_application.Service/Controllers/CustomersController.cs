using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile_application.Service.Data;
using mobile_application.Models;

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



        [HttpGet("CustomersList code_shobe={code_shobe}")]
        public async Task<ActionResult<IEnumerable<vw_customers_list>>> GetCustomersList(int code_shobe)
        {
            string StoredProc = "exec sp_customers_list_get_code_shobe @code_shobe=" + code_shobe;
            return await _context.vw_customers_list.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Customer_Information CustomerCode={CustomerCode},BranchCode={BranchCode}")]
        public async Task<ActionResult<IEnumerable<vw_customer_information>>> GetCustomer_Information(int CustomerCode, int BranchCode)
        {
            string StoredProc = "exec sp_customer_information @CustomerCode=" + CustomerCode + ", @BranchCode=" + BranchCode;
            return await _context.vw_customer_information.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("GetLatestAvailableCustomerCode BranchCode={BranchCode}")]
        public async Task<ActionResult<IEnumerable<vw_customer_code_serial>>> GetLatestAvailableCustomerCode(int BranchCode)
        {
            string StoredProc = "exec GetLatestAvailableCustomerCode @BranchCode=" + BranchCode;
            return await _context.vw_customer_code_serial.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("GetAvailableCustomerJob BranchCode={BranchCode},CustomerCode={CustomerCode},SefareshDate={SefareshDate}")]
        public async Task<ActionResult<IEnumerable<vw_JobNo>>> GetGetAvailableCustomerJob(int BranchCode, int CustomerCode,string SefareshDate)
        {
            string StoredProc = "exec sp_GetAvailableCustomerJob @BranchCode=" + BranchCode + ",@CustomerCode=" + CustomerCode + ",@SefareshDate='" + SefareshDate + "'";
            return await _context.vw_JobNo.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Customer_Cart_New BranchCode={BranchCode},CustomerCode={CustomerCode},UserCode={UserCode}")]
        public async Task<ActionResult<IEnumerable<vw_customer_cart_result>>> Customer_Cart_New(int BranchCode,int CustomerCode, int UserCode)
        {
            string StoredProc = "exec sp_CustomerCart_New @BranchCode=" + BranchCode + ",@CustomerCode=" + CustomerCode + ",@UserCode=" + UserCode;
            return await _context.vw_customer_cart_result.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("customer_state BranchCode={BranchCode},CustomerCode={CustomerCode},BargeDate={BargeDate}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> Customer_State(int BranchCode, int CustomerCode, string BargeDate)
        {
            string StoredProc = "exec sp_customer_state @BranchCode=" + BranchCode + ",@CustomerCode=" + CustomerCode + ",@BargeDate='" + BargeDate + "'";
            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
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
