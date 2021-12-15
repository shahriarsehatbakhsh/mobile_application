using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile_application.Service.Data;
using mobile_application.Models;
using mobile_application.Service.Helper;

namespace mobile_application.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SefareshSellerController : ControllerBase
    {
        private readonly MaliDBContext _context;

        public SefareshSellerController(MaliDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeShobe"></param>
        /// <param name="HeaderCode"></param>
        /// <param name="TarikhBarge"></param>
        /// <param name="CodeMoshtari"></param>
        /// <param name="CodeForooshande"></param>
        /// <param name="CodeMosavabe"></param>
        /// <param name="NoeTasvie"></param>
        /// <param name="ModdateTasvie"></param>
        /// <param name="CustomerJob"></param>
        /// <param name="HeaderSerial"></param>
        /// <param name="Supervisor"></param>
        /// <param name="CodeSupervisor"></param>
        /// <param name="CodeKarbar"></param>
        /// <param name="TarikheRooz"></param>
        /// <returns></returns>
        [HttpGet("InsertHeader/{CodeShobe}/{HeaderCode}/{TarikhBarge}/{CodeMoshtari}/{CodeForooshande}/{CodeMosavabe}/{NoeTasvie}/{ModdateTasvie}/{CustomerJob}/{HeaderSerial}/{Supervisor}/{CodeSupervisor}/{CodeKarbar}/{TarikheRooz}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> GetInsertHeader(int CodeShobe,int HeaderCode,string TarikhBarge,int CodeMoshtari,int CodeForooshande,int CodeMosavabe,int NoeTasvie,int ModdateTasvie,int CustomerJob,int HeaderSerial,int Supervisor,int CodeSupervisor,int CodeKarbar,string TarikheRooz)
        {
            string StoredProc = "exec sp_insert_F_hSefareshSeller @CodeShobe=" + CodeShobe + "," +
                                                                 "@sp_GetLatestAvailableSefareshHeaderCode_HeaderCode = " + HeaderCode + "," +
                                                                 "@TarikhBarge = '" + TarikhBarge + "'," +
                                                                 "@CodeMoshtari = " + CodeMoshtari + "," +
                                                                 "@CodeForooshande = " + CodeForooshande + "," +
                                                                 "@CodeMosavabe = " + CodeMosavabe + "," +
                                                                 "@NoeTasvie = " + NoeTasvie + "," +
                                                                 "@ModdateTasvie = " + ModdateTasvie + "," +
                                                                 "@sp_GetAvailableCustomerJob = " + CustomerJob + "," +
                                                                 "@sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial = " + HeaderSerial + "," +
                                                                 "@Supervisor = " + Supervisor + "," +
                                                                 "@CodeSupervisor = " + CodeSupervisor + "," +
                                                                 "@CodeKarbar = " + CodeKarbar + "," +
                                                                 "@TarikheRooz = '" + TarikheRooz + "'";

            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeShobe"></param>
        /// <param name="ShomareBarge_Header"></param>
        /// <param name="ShomareRadif"></param>
        /// <param name="CodeAnbaar"></param>
        /// <param name="CodeKala"></param>
        /// <param name="Meghdar"></param>
        /// <param name="Nerkh"></param>
        /// <param name="Mablagh"></param>
        /// <param name="NoeBaste"></param>
        /// <param name="TedadBaste"></param>
        /// <param name="TedadDarHarBaste"></param>
        /// <param name="CodeKarbar"></param>
        /// <param name="TarikhRooz"></param>
        /// <param name="BranchCode"></param>
        /// <param name="MoshtariCode"></param>
        /// <returns></returns>
        [HttpGet("InsertDetail/{CodeShobe}/{ShomareBarge_Header}/{ShomareRadif}/{CodeAnbaar}/{CodeKala}/{Meghdar}/{Nerkh}/{Mablagh}/{NoeBaste}/{TedadBaste}/{TedadDarHarBaste}/{CodeKarbar}/{TarikhRooz}/{BranchCode}/{MoshtariCode}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> GetInsertDetail(int CodeShobe,int ShomareBarge_Header,int ShomareRadif,int CodeAnbaar,string CodeKala,int Meghdar,float Nerkh,decimal Mablagh,int NoeBaste,decimal TedadBaste,decimal TedadDarHarBaste,int CodeKarbar,string TarikhRooz,int BranchCode,string MoshtariCode)
        {
            //CodeKala = Static_Function.Create_Kala_Code(CodeKala);
            string StoredProc = "exec sp_insert_F_dSefareshSeller @CodeShobe=" + CodeShobe + "," +
                                                                 "@ShomareBarge_Header = " + ShomareBarge_Header + "," +
                                                                 "@ShomareRadif = " + ShomareRadif + "," +
                                                                 "@CodeAnbaar = " + CodeAnbaar + "," +
                                                                 "@CodeKala = '" + CodeKala + "'," +
                                                                 "@Meghdar = " + Meghdar + "," +
                                                                 "@Nerkh = " + Nerkh + "," +
                                                                 "@Mablagh = " + Mablagh + "," +
                                                                 "@NoeBaste = " + NoeBaste + "," +
                                                                 "@TedadBaste = " + TedadBaste + "," +
                                                                 "@TedadDarHarBaste = " + TedadDarHarBaste + "," +
                                                                 "@CodeKarbar = " + CodeKarbar + "," +
                                                                 "@TarikhRooz = '" + TarikhRooz + "'," +
                                                                 "@BranchCode = " + BranchCode + "," +
                                                                 "@MoshtariCode = '" + MoshtariCode + "'";

            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BranchCode"></param>
        /// <returns></returns>
        [HttpGet("HeaderCodeSerial/{BranchCode}")]
        public async Task<ActionResult<IEnumerable<vw_header_CodeSerial>>> GetHeaderCodeSerial(int BranchCode)
        {
            string StoredProc = "exec sp_insert_F_hSefareshHeaderCodeSerial @BranchCode=" + BranchCode;
            return await _context.vw_header_CodeSerial.FromSqlRaw(StoredProc).ToListAsync();
        }

    }
}