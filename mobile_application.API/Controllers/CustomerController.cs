using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using mobile_application.API.Models;

using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace mobile_application.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller 
    {

        //private readonly DB_Entities _context;


        private readonly DB_Entities _context;

        public CustomerController(DB_Entities context)
        {
            _context = context;
        }

        [HttpPost("List")]
        public async Task<ActionResult<IEnumerable<vw_api_customer_list>>> CustomersList(int shobe_code)
        {
            string StoredProc = "exec sp_customer_list " +
                    "@code_shobe = " + shobe_code;

            //return await _context.output.ToListAsync();
            return await _context.vw_api_customer_list.FromSqlRaw(StoredProc).ToListAsync();
        }


    }
}
