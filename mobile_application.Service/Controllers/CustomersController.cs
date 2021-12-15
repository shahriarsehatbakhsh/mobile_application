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

        /// <summary>
        /// 'https://localhost:44331/Customers/CustomersList/1'
        /// </summary>
        /// <param name="code_shobe"></param>
        /// <returns></returns>
        [HttpGet("CustomersList/{code_shobe}")]
        public async Task<ActionResult<IEnumerable<vw_customers_list>>> GetCustomersList(int code_shobe)
        {
            string StoredProc = "exec sp_customers_list_get_code_shobe @code_shobe=" + code_shobe;
            return await _context.vw_customers_list.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Customers/GetLatestAvailableCustomerCode/1'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <returns></returns>
        [HttpGet("GetLatestAvailableCustomerCode/{BranchCode}")]
        public async Task<ActionResult<IEnumerable<vw_customer_code_serial>>> GetLatestAvailableCustomerCode(int BranchCode)
        {
            string StoredProc = "exec sp_GetLatestAvailableCustomerCode @BranchCode=" + BranchCode;
            return await _context.vw_customer_code_serial.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Customers/GetAvailableCustomerJob/1/1/1400D01D01'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="SefareshDate"></param>
        /// <returns></returns>
        [HttpGet("GetAvailableCustomerJob/{BranchCode}/{CustomerCode}/{SefareshDate}")]
        public async Task<ActionResult<IEnumerable<vw_JobNo>>> GetGetAvailableCustomerJob(int BranchCode, int CustomerCode,string SefareshDate)
        {
            string StoredProc = "exec sp_GetAvailableCustomerJob @BranchCode=" + BranchCode + ",@CustomerCode=" + CustomerCode + ",@SefareshDate='" + SefareshDate + "'";
            return await _context.vw_JobNo.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Customers/Customer_Cart_New/1/1/1'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        [HttpGet("Customer_Cart_New/{BranchCode}/{CustomerCode}/{UserCode}")]
        public async Task<ActionResult<IEnumerable<vw_customer_cart_result>>> Customer_Cart_New(int BranchCode,int CustomerCode, int UserCode)
        {
            string StoredProc = "exec sp_CustomerCart_New @BranchCode=" + BranchCode + ",@CustomerCode=" + CustomerCode + ",@UserCode=" + UserCode;
            return await _context.vw_customer_cart_result.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Customers/customer_state/1/1/1400D01D01'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="BargeDate"></param>
        /// <returns></returns>
        [HttpGet("customer_state/{BranchCode}/{CustomerCode}/{BargeDate}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> Customer_State(int BranchCode, int CustomerCode, string BargeDate)
        {
            string StoredProc = "exec sp_customer_state @BranchCode=" + BranchCode + ",@CustomerCode=" + CustomerCode + ",@BargeDate='" + BargeDate + "'";
            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Customers/Insert/1/1/1/1/1/1400D01D01/1/1/1/1/1/1/1/1'
        /// </summary>
        /// <param name="CodeShobe"></param>
        /// <param name="sp_GetLatestAvailableCustomerCode_code"></param>
        /// <param name="Sharh"></param>
        /// <param name="sp_GetLatestAvailableCustomerCode_serial"></param>
        /// <param name="CodeKarbareVaredShodeBeSystem"></param>
        /// <param name="TairkheRooz"></param>
        /// <param name="CodePishe"></param>
        /// <param name="CodeOstan"></param>
        /// <param name="CodeShahr"></param>
        /// <param name="CodeMantaghe"></param>
        /// <param name="CodeMasir"></param>
        /// <param name="Tel"></param>
        /// <param name="Mobile"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        [HttpGet("Insert/{CodeShobe}/{sp_GetLatestAvailableCustomerCode_code}/{Sharh}/{sp_GetLatestAvailableCustomerCode_serial}/{CodeKarbareVaredShodeBeSystem}/{TairkheRooz}/{CodePishe}/{CodeOstan}/{CodeShahr}/{CodeMantaghe}/{CodeMasir}/{Tel}/{Mobile}/{Address}")]
        public async Task<ActionResult<IEnumerable<ErrorResult>>> Insert(int CodeShobe, int sp_GetLatestAvailableCustomerCode_code, string Sharh, int sp_GetLatestAvailableCustomerCode_serial,int CodeKarbareVaredShodeBeSystem,string TairkheRooz, int CodePishe, int CodeOstan, int CodeShahr, int CodeMantaghe, int CodeMasir,string Tel, string Mobile, string Address)
        {
            string StoredProc = "exec sp_customer_insert @CodeShobe=" + CodeShobe + "," +
                                                                            "@sp_GetLatestAvailableCustomerCode_code=" + sp_GetLatestAvailableCustomerCode_code + "," +
                                                                            "@Sharh=" + Sharh + "," +
                                                                            "@sp_GetLatestAvailableCustomerCode_serial=" + sp_GetLatestAvailableCustomerCode_serial + "," +
                                                                            "@CodeKarbareVaredShodeBeSystem=" + CodeKarbareVaredShodeBeSystem + "," +
                                                                            "@TairkheRooz='" + TairkheRooz + "'," +
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

        /// <summary>
        /// 'https://localhost:44331/Customers/Customer_Information/1/1'
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="BranchCode"></param>
        /// <returns></returns>
        [HttpGet("Customer_Information/{CustomerCode}/{BranchCode}")]
        public async Task<ActionResult<IEnumerable<vw_customer_information>>> GetCustomer_Information(int CustomerCode, int BranchCode)
        {
            string StoredProc = "exec sp_customer_information @CustomerCode=" + CustomerCode + ", @BranchCode=" + BranchCode;
            return await _context.vw_customer_information.FromSqlRaw(StoredProc).ToListAsync();
        }
    }
}
