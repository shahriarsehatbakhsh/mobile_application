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
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly MaliDBContext _context;

        public ListController(MaliDBContext context)
        {
            _context = context;
        }


        [HttpGet("Ostan")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetOstan()
        {
            string StoredProc = "exec sp_ostan_list ";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Pishe")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetPishe()
        {
            string StoredProc = "exec sp_pishe_list ";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Shahr")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetShahr()
        {
            string StoredProc = "exec sp_shahr_list ";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Mantaghe")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetMantaghe()
        {
            string StoredProc = "exec sp_mantaghe_list ";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Masir")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetMasir()
        {
            string StoredProc = "exec sp_masir_list ";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("Shobe code_karbar={code_karbar},code_karbar_per={code_karbar_per}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetShobe(int code_karbar ,int code_karbar_per)
        {
            string StoredProc = "exec sp_shobe_list @code_karbar=" + code_karbar + ",@code_karbar_per=" + code_karbar_per;

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("seller code_karbar={code_karbar},code_shobe={code_shobe}")]
        public async Task<ActionResult<IEnumerable<vw_seller_list>>> GetSeller(int code_karbar,int code_shobe)
        {
            string StoredProc = "exec sp_seller_list @code_karbar=" + code_karbar + ",@code_shobe=" + code_shobe;

            return await _context.vw_seller_list.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("supervizer code_karbar={code_karbar},code_shobe={code_shobe}")]
        public async Task<ActionResult<IEnumerable<vw_seller_list>>> GetSupervizer(int code_karbar, int code_shobe)
        {
            string StoredProc = "exec sp_supervizer_list @code_karbar=" + code_karbar + ",@code_shobe=" + code_shobe;
            return await _context.vw_seller_list.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("customer code_shobe={code_shobe}")]
        public async Task<ActionResult<IEnumerable<vw_customers_list>>> GetCustomers(int code_shobe)
        {
            string StoredProc = "exec sp_customers_list_get_code_shobe @code_shobe=" + code_shobe;
            return await _context.vw_customers_list.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("ObjectCodeName object_name={object_name}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectCodeName(string object_name)
        {
            string StoredProc = "exec sp_objects_list_get_object_name @object_name=" + object_name;
            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tarikh barge"></param>
        /// <param name="code shobe"></param>
        /// <returns></returns>
        [HttpGet("mosavabe_list Fhmo05={Fhmo05},Fdmb02={Fdmb02}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectCodeName(string Fhmo05,short Fdmb02)
        {
            string StoredProc = "exec sp_mosavabe_list @Fhmo05='" + Fhmo05 + "',@Fdmb02=" + Fdmb02;

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }



    }
}