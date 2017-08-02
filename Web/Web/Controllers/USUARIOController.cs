using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Business;
using Web.Messages;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    public class USUARIOController : Controller
    {
        private SmartBagEntities db = new SmartBagEntities();
        private string[] tipoPessoa = { "1", "2", "3" };

        public ActionResult Index()
        {
            //ComboStatus();
            //UsuarioBLL BLL = new UsuarioBLL();

            //var ListofUser = BLL.ListofUser();

            //return View(ListofUser);
            return View();
        }

        public ActionResult Pesquisa([Bind(Include = "TxtNomePessoa, Status, TxtLogin")] string TxtNomePessoa, decimal? Status, string TxtLogin)
        {
            ComboStatus();
            UsuarioBLL BLL = new UsuarioBLL();

          //  var ListofUser = BLL.ListofUser(TxtNomePessoa, Status, TxtLogin);

           // return PartialView("_PartialUserSearch", ListofUser);
            return PartialView("_PartialUserSearch", "");
        }



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


        public ActionResult Login() 
        {
            Session.Clear();

            ViewData["VersaoSistema"] = "Versão: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            // ViewData["AppName"] = Resources.AppName;

            ViewData["error"] = TempData["error"];
            return View();
        }

        public ActionResult Autenticar(String txtLogin, String txtPassword)
        {

            Usuario usuario = null;
            try
            {
                usuario = UsuarioBLL.AutenticaUsuario(txtLogin, txtPassword);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Login", "USUARIO");
            }


            Session.Clear();

            SessionED.Current.LoginUsuario = usuario.Login;
            SessionED.Current.CodUsuario = usuario.CodUsuario;
            SessionED.Current.DataCriacao = usuario.CreationDate.ToShortDateString();
            SessionED.Current.Perfil = "1";


            return RedirectToAction("Inicio", "Home");
        }


        // GET: USUARIO/Create
        public ActionResult Create()
        {
           // ViewBag.codPessoa = new SelectList(db.TBT_PESSOA.Where(x => tipoPessoa.Contains(x.CodTipoPessoa)).OrderBy(x => x.Nome), "CodPessoa", "Nome");
            return View();
        }

        // POST: TBT_USER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CodPessoa,Login,Senha,")] Usuario usr)
        //{
        //    UsuarioBLL BLL = new UsuarioBLL();
        //    List<Usuario> ListUser = BLL.ListofUser(null, null, usr.Login);
        //    if (ListUser.Count > 0)
        //    {
        //        TempData["Usuario"] = "Failure";
        //        TempData["Message"] = "Já existe um usuário com esse login!";
        //        ViewBag.codPessoa = new SelectList(db.TBT_PESSOA.Where(x => tipoPessoa.Contains(x.CodTipoPessoa)).OrderBy(x => x.Nome), "CodPessoa", "Nome", usr.CodPessoa);
        //        return View("Create", usr);
        //    }

        //    decimal? newID = BLL.UserCreate(usr);
        //    if (newID == null)
        //    {
        //        TempData["Usuario"] = "Failure";
        //        TempData["Message"] = "Ocorreu um erro ao tentar criar o novo usuário!";
        //        ViewBag.codPessoa = new SelectList(db.TBT_PESSOA.Where(x => tipoPessoa.Contains(x.CodTipoPessoa)).OrderBy(x => x.Nome), "CodPessoa", "Nome", usr.CodPessoa);
        //        return View("Create", usr);
        //    }
        //    else
        //    {
        //        TempData["Usuario"] = "Success";
        //        TempData["Message"] = "Usuário criado com sucesso!";
        //        return RedirectToAction("Index");            
        //    }
        //}

        // GET: TBT_USER/Edit/5
        //public ActionResult Edit(decimal id)
        //{
        //    UsuarioBLL BLL = new UsuarioBLL();
        //    Usuario tBT_USER = BLL.GetUser(id);
        //    if (tBT_USER == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ComboStatus(tBT_USER.Ativo);
        //    ViewBag.codPessoa = new SelectList(db.TBT_PESSOA.Where(x => tipoPessoa.Contains(x.CodTipoPessoa)).OrderBy(x => x.Nome), "CodPessoa", "Nome", tBT_USER.CodPessoa);
        //    return View(tBT_USER);
        //}

        //// POST: TBT_USER/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Status, CodUsuario,CodPessoa,Login,Senha")]int Status, Usuario usr)
        //{
        //    UsuarioBLL BLL = new UsuarioBLL();
        //    if (Status == 1)
        //    {
        //        usr.Ativo = true;
        //    }
        //    else
        //    {
        //        usr.Ativo = false;
        //    }

        //    bool LoginOk = true;
        //    var ListofUser = BLL.ListofUser(null, null, usr.Login);

        //    foreach (Usuario u in ListofUser)
        //    {
        //        if (u.CodUsuario != usr.CodUsuario)
        //            LoginOk = false;
        //    }

        //    if (!LoginOk)
        //    {
        //        ViewBag.codPessoa = new SelectList(db.TBT_PESSOA.Where(x => tipoPessoa.Contains(x.CodTipoPessoa)).OrderBy(x => x.Nome), "CodPessoa", "Nome", usr.CodPessoa);
        //        TempData["Usuario"] = "Failure";
        //        TempData["Message"] = "Login novo é inválido, já existe um usuário utilizando-o!";
        //        return View(usr);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        bool EditOk = BLL.UserEdit(usr);
        //        if (EditOk)
        //        {
        //            TempData["Usuario"] = "Success";
        //            TempData["Message"] = "Usuário editado com sucesso!";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["Usuario"] = "Failure";
        //            TempData["Message"] = "Ocorreu um erro ao tentar salvar o usuário!";
        //            ViewBag.codPessoa = new SelectList(db.TBT_PESSOA.Where(x => tipoPessoa.Contains(x.CodTipoPessoa)).OrderBy(x => x.Nome), "CodPessoa", "Nome", usr.CodPessoa);
        //            return View(usr);
        //        }
        //    }
        //    else
        //    {
        //        TempData["Usuario"] = "Failure";
        //        TempData["Message"] = "Ocorreu um erro ao tentar salvar o usuário!";
        //        ViewBag.codPessoa = new SelectList(db.TBT_PESSOA.Where(x => tipoPessoa.Contains(x.CodTipoPessoa)).OrderBy(x => x.Nome), "CodPessoa", "Nome", usr.CodPessoa);
        //        return View(usr);
        //    }
        //}

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
