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
    public class UsersController : ControllerBase
    {
        private readonly CentralDBContext _context;

        public UsersController(CentralDBContext context)
        {
            _context = context;
        }

        [HttpGet("CentralLogin Username={Username},Password={Password}")]
        public async Task<ActionResult<IEnumerable<vw_Resault>>> GetCentralLogin(string Username,string Password)
        {
            string StoredProc = "exec sp_login @Username=" + Username + ",@Password=" + Password;

            return await _context.vw_Resault.FromSqlRaw(StoredProc).ToListAsync();
        }
    }
}