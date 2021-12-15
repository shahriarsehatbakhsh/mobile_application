
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile_application.Service.Data;
using mobile_application.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobile_application.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnbarController : ControllerBase
    {
        private readonly MaliDBContext _context;
        public AnbarController(MaliDBContext context)
        {
            _context = context;
        }

        [HttpGet("Mojoodi_Anbar/{AnbarCode}/{ObjectCode}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> GetMojoodi_Anbar(int AnbarCode, string ObjectCode)
        {
            string StoredProc = "exec sp_mojoodi_anbar @AnbarCode=" + AnbarCode + ",@ObjectCode='" + ObjectCode + "'";
            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
        }

        [HttpGet("Mojoodi_Anbar_BargeDate/{TarikhBarge}/{AnbarCode}/{ObjectCode}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> GetMojoodi_Anbar_BargeDate(string TarikhBarge,int AnbarCode, string ObjectCode)
        {
            string StoredProc = "exec sp_mojoodi_anbar_BargeDate @TarikhBarge='" + TarikhBarge + "',@AnbarCode=" + AnbarCode + ",@ObjectCode='" + ObjectCode + "'";
            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
        }
    }
}
