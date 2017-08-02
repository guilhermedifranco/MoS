using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Business;
using Web.Models;

namespace Web.Controllers
{
    public class TDsController : Controller
    {
        private SmartBagEntities db = new SmartBagEntities();

        // GET: TDs
        #region Index/Pesquisa
        public ActionResult Index()
        {
            
            // ViewBag.TipoMarketing = new SelectList(db.TBT_TIPO_MARKETING, "CodTipoMarketing", "Descricao");
            MarketingBLL BLL = new MarketingBLL();
            var ListaConsulta = BLL.SearchMarketing(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            return View(ListaConsulta);
        }
        public ActionResult Pesquisa([Bind(Include = " ID, OAmin, OAmax, CONmin, CONmax, TALmin, TALmax, AGGmin, AGGmax, EXPmin, EXPmax, TEImin, TEImax, STAmin,  STAmax, MOTmin, MOTmax")]
            int? ID, int? OAmin, int? OAmax, int? CONmin, int? CONmax, int? TALmin, int? TALmax, int? AGGmin, int? AGGmax, int? EXPmin, int? EXPmax,
            int? TEImin, int? TEImax, int? STAmin,
            int? STAmax, int? MOTmin, int? MOTmax)
        {
            
            //   ViewBag.TipoMarketing = new SelectList(db.TBT_TIPO_MARKETING, "CodTipoMarketing", "Descricao");

            MarketingBLL BLL = new MarketingBLL();

            var ListaConsulta = BLL.SearchMarketing(ID, OAmin, OAmax, CONmin, CONmax, TALmin, TALmax, AGGmin, AGGmax, EXPmin, EXPmax, TEImin, TEImax, STAmin, STAmax, MOTmin, MOTmax);

            return PartialView("_PartialMarketTD", ListaConsulta);
        }
        #endregion

        #region Edição
        public ActionResult Find()
        {

            //ViewBag.CodTipoMarketing = new SelectList(db.TBT_TIPO_MARKETING, "CodTipoMarketing", "Descricao", tBT_Marketing.CodTipoMarketing);
            // ViewBag.CodMarca = new SelectList(db.TBT_MARCA, "CodMarca", "Descricao", tBT_Marketing.CodMarca);
            return View();
        }

        public ActionResult FindbyID([Bind(Include = " ID")]int? ID)
        {

            //   ViewBag.TipoMarketing = new SelectList(db.TBT_TIPO_MARKETING, "CodTipoMarketing", "Descricao");

            MarketingBLL BLL = new MarketingBLL();

            Drivers tBT_Marketing = BLL.GetDriver(ID.Value);
            return PartialView("_PartialTD", tBT_Marketing);
        }


        #endregion


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
