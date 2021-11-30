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
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class ObjectsController : ControllerBase
    {
        private readonly MaliDBContext _context;

        public ObjectsController(MaliDBContext context)
        {
            _context = context;
        }

        [HttpGet("ObjectsList")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectsList()
        {
            string StoredProc = "exec sp_object_list ";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("ObjectsSearchList objName={objName}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectsSearchList(string objName)
        {
            string StoredProc = "exec sp_object_list_search @object='" + objName + "'";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("ObjectNerkh BranchCode={BranchCode},MosavabeCode={MosavabeCode},ObjectCode={ObjectCode}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectNerkh(int BranchCode, int MosavabeCode, int ObjectCode)
        {
            string StoredProc = "exec sp_object_nerkh @BranchCode=" + BranchCode + ",@MosavabeCode=" + MosavabeCode + ",@ObjectCode=" + ObjectCode;

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


        [HttpGet("ObjectVahed ObjectCode={ObjectCode}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectVahed(int ObjectCode)
        {
            string StoredProc = "exec sp_object_vahed @ObjectCode=" + ObjectCode;

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


    }
}
