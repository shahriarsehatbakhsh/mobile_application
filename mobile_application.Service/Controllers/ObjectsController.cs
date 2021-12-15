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
    public class ObjectsController : ControllerBase
    {
        private readonly MaliDBContext _context;

        public ObjectsController(MaliDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 'https://localhost:44331/Objects/ObjectsList/1/t'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
        [HttpGet("ObjectsList/{BranchCode}/{ObjectName}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectsList(int BranchCode, string ObjectName)
        {
            string StoredProc = "exec sp_object_list @BranchCode=" + BranchCode + ", @ObjectName='" + ObjectName + "'";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Objects/ObjectsList/1'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <returns></returns>
        [HttpGet("ObjectsList/{BranchCode}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectsList(int BranchCode)
        {
            string StoredProc = "exec sp_object_list @BranchCode=" + BranchCode + ", @ObjectName=''";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Objects/Get_KalaPackage/1/1'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <param name="KalaCode"></param>
        /// <returns></returns>
        [HttpGet("Get_KalaPackage/{BranchCode}/{KalaCode}")]
        public async Task<ActionResult<IEnumerable<vw_KalaPackage>>> Get_KalaPackage(short BranchCode,string KalaCode)
        {
            KalaCode = Helper.Static_Function.Create_Kala_Code(KalaCode);
            string StoredProc = "exec sp_Get_KalaPackage @BranchCode=" + BranchCode + ", @KalaCode='" + KalaCode + "'";

            return await _context.vw_KalaPackage.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        [HttpGet("ObjectsSearchList/{objName}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectsSearchList(string objName)
        {
            string StoredProc = "exec sp_object_list_search @object='" + objName + "'";

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Objects/ObjectNerkh/1/1/1'
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <param name="MosavabeCode"></param>
        /// <param name="ObjectCode"></param>
        /// <returns></returns>
        [HttpGet("ObjectNerkh/{BranchCode}/{MosavabeCode}/{ObjectCode}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectNerkh(int BranchCode, int MosavabeCode, int ObjectCode)
        {
            string StoredProc = "exec sp_object_nerkh @BranchCode=" + BranchCode + ",@MosavabeCode=" + MosavabeCode + ",@ObjectCode=" + ObjectCode;

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 'https://localhost:44331/Objects/ObjectVahed/1'
        /// </summary>
        /// <param name="ObjectCode"></param>
        /// <returns></returns>
        [HttpGet("ObjectVahed/{ObjectCode}")]
        public async Task<ActionResult<IEnumerable<vw_code_sharh>>> GetObjectVahed(int ObjectCode)
        {
            string StoredProc = "exec sp_object_vahed @ObjectCode=" + ObjectCode;

            return await _context.vw_code_sharh.FromSqlRaw(StoredProc).ToListAsync();
        }


    }
}
