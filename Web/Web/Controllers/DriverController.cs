using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Business;
using Web.Messages;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    public class DriverController : Controller
    {
        private SmartBagEntities db = new SmartBagEntities();

        #region private Helpers
        private void ComboStatus(bool? active = null)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem { Value = "1", Text = "Ativo" });
            lista.Add(new SelectListItem { Value = "0", Text = "Inativo" });
            if (active == null)
                ViewBag.Status = new SelectList(lista, "Value", "Text");
            else
            {
                if (active.Value)
                    ViewBag.Status = new SelectList(lista, "Value", "Text", "1");
                else
                    ViewBag.Status = new SelectList(lista, "Value", "Text", "0");
            }
        }
        private string GetTipoArquivo(string formato)
        {
            string tipo = "";
            switch (formato.ToUpper())
            {
                case ".MP4":
                case ".AVI":
                case ".MPEG":
                case ".MPG":
                    tipo = "VID";
                    break;
                case ".JPG":
                case ".JPEG":
                case ".PNG":
                case ".BMP":
                    tipo = "IMG";
                    break;
                case ".PDF":
                    tipo = "PDF";
                    break;
                default:
                    tipo = "DIF";
                    break;
            }
            return tipo;
        }

        #endregion

        #region Index/Pesquisa
        public ActionResult Index()
        {
            ComboStatus(true);
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
            ComboStatus();
            //   ViewBag.TipoMarketing = new SelectList(db.TBT_TIPO_MARKETING, "CodTipoMarketing", "Descricao");

            MarketingBLL BLL = new MarketingBLL();

            var ListaConsulta = BLL.SearchMarketing(ID, OAmin, OAmax, CONmin, CONmax, TALmin, TALmax, AGGmin, AGGmax, EXPmin, EXPmax, TEImin, TEImax, STAmin, STAmax, MOTmin, MOTmax);

            return PartialView("_PartialMarketing", ListaConsulta);
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
            return PartialView("_PartialDriver", tBT_Marketing);
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
