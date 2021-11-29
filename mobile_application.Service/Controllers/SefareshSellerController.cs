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
    public class SefareshSellerController : ControllerBase
    {
        private readonly MaliDBContext _context;

        public SefareshSellerController(MaliDBContext context)
        {
            _context = context;
        }

        [HttpGet("InsertHeader CodeShobe={CodeShobe},sp_GetLatestAvailableSefareshHeaderCode_HeaderCode{sp_GetLatestAvailableSefareshHeaderCode_HeaderCode},TarikhBarge={TarikhBarge},CodeMoshtari={CodeMoshtari},CodeForooshande={CodeForooshande},CodeMosavabe={CodeMosavabe},NoeTasvie={NoeTasvie},ModdateTasvie={ModdateTasvie},sp_GetAvailableCustomerJob={sp_GetAvailableCustomerJob},sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial={sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial},Supervisor={Supervisor},CodeSupervisor={CodeSupervisor},CodeKarbar={CodeKarbar},TarikheRooz={TarikheRooz}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> GetInsertHeader(int CodeShobe,int sp_GetLatestAvailableSefareshHeaderCode_HeaderCode,string TarikhBarge,int CodeMoshtari,int CodeForooshande,int CodeMosavabe,int NoeTasvie,int ModdateTasvie,int sp_GetAvailableCustomerJob,int sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial,int Supervisor,int CodeSupervisor,int CodeKarbar,string TarikheRooz)
        {
            string StoredProc = "exec sp_insert_F_hSefareshSeller @CodeShobe=" + CodeShobe + "," +
                                                                 "@sp_GetLatestAvailableSefareshHeaderCode_HeaderCode = " + sp_GetLatestAvailableSefareshHeaderCode_HeaderCode + "," +
                                                                 "@TarikhBarge = " + TarikhBarge + "," +
                                                                 "@CodeMoshtari = " + CodeMoshtari + "," +
                                                                 "@CodeForooshande = " + CodeForooshande + "," +
                                                                 "@CodeMosavabe = " + CodeMosavabe + "," +
                                                                 "@NoeTasvie = " + NoeTasvie + "," +
                                                                 "@ModdateTasvie = " + ModdateTasvie + "," +
                                                                 "@sp_GetAvailableCustomerJob = " + sp_GetAvailableCustomerJob + "," +
                                                                 "@sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial = " + sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial + "," +
                                                                 "@Supervisor = " + Supervisor + "," +
                                                                 "@CodeSupervisor = " + CodeSupervisor + "," +
                                                                 "@CodeKarbar = " + CodeKarbar + "," +
                                                                 "@TarikheRooz = " + TarikheRooz;

            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
        }

        [HttpGet("InsertDetail CodeShobe={CodeShobe},ShomareBarge_Header={ShomareBarge_Header},ShomareRadif={ShomareRadif},CodeAnbaar={CodeAnbaar},CodeKala={CodeKala},Meghdar={Meghdar},Nerkh={Nerkh},Mablagh={Mablagh},NoeBaste={NoeBaste},TedadBaste={TedadBaste},TedadDarHarBaste={TedadDarHarBaste},CodeKarbar={CodeKarbar},TarikhRooz={TarikhRooz},BranchCode={BranchCode},MoshtariCode={MoshtariCode}")]
        public async Task<ActionResult<IEnumerable<vw_result>>> GetInsertDetail(int CodeShobe,int ShomareBarge_Header,int ShomareRadif,int CodeAnbaar,string CodeKala,int Meghdar,float Nerkh,decimal Mablagh,int NoeBaste,decimal TedadBaste,decimal TedadDarHarBaste,int CodeKarbar,string TarikhRooz,int BranchCode,string MoshtariCode)
        {
            string StoredProc = "exec sp_insert_F_dSefareshSeller @CodeShobe=" + CodeShobe + "," +
                                                                 "@ShomareBarge_Header = " + ShomareBarge_Header + "," +
                                                                 "@ShomareRadif = " + ShomareRadif + "," +
                                                                 "@CodeAnbaar = " + CodeAnbaar + "," +
                                                                 "@CodeKala = " + CodeKala + "," +
                                                                 "@Meghdar = " + Meghdar + "," +
                                                                 "@Nerkh = " + Nerkh + "," +
                                                                 "@Mablagh = " + Mablagh + "," +
                                                                 "@NoeBaste = " + NoeBaste + "," +
                                                                 "@TedadBaste = " + TedadBaste + "," +
                                                                 "@TedadDarHarBaste = " + TedadDarHarBaste + "," +
                                                                 "@CodeKarbar = " + CodeKarbar + "," +
                                                                 "@TarikhRooz = " + TarikhRooz + "," +
                                                                 "@BranchCode = " + BranchCode + "," +
                                                                 "@MoshtariCode = " + MoshtariCode;

            return await _context.vw_result.FromSqlRaw(StoredProc).ToListAsync();
        }
    }
}