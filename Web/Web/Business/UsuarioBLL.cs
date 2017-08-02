using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Messages;
using Web.Models;

namespace Web.Business
{
    public class UsuarioBLL
    {
       // public List<Usuario> ListofUser(string TxtNomePessoa = null, decimal? Status = null, string TxtLogin = null)
       // {
            //using (SmartBagEntities entities = new SmartBagEntities())
            //{
            //    bool blStatus = Status == 1 ? true : false;

            //    var query = (from tbtu in entities.TBT_USUARIO.Where(x => x.Login != "ADMIN")
            //                 join tbtp in entities.TBT_PESSOA on tbtu.CodPessoa equals tbtp.CodPessoa
            //                 select new Usuario
            //                 {
            //                     CodUsuario = tbtu.CodUsuario,
            //                     Login = tbtu.Login,
            //                     Ativo= tbtu.IndAtivo == 1 ? true : false,
            //                     NomePessoa = tbtp.Nome
            //                 });

            //    if (!string.IsNullOrEmpty(TxtLogin))
            //    {
            //        query = query.Where(x => x.Login.Contains(TxtLogin));
            //    }

            //    if (Status != null)
            //    {
            //        query = query.Where(x => x.Ativo == blStatus);
            //    }

            //    if (!string.IsNullOrEmpty(TxtNomePessoa))
            //    {
            //        query = query.Where(x => x.NomePessoa.Contains(TxtNomePessoa));
            //    }
            //    return query.OrderBy(x => x.NomePessoa).ToList();
            //}
      //  }

        //public Usuario GetUser(decimal CodUsuario)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {

        //        var query = (from tbtu in entities.TBT_USUARIO.Where(x => x.CodUsuario == CodUsuario)
        //                     join tbtp in entities.TBT_PESSOA on tbtu.CodPessoa equals tbtp.CodPessoa
        //                     select new Usuario
        //                     {
        //                         CodUsuario = tbtu.CodUsuario,
        //                         Login = tbtu.Login,
        //                         Ativo = tbtu.IndAtivo == 1 ? true : false,
        //                         NomePessoa = tbtp.Nome,
        //                         CodPessoa = tbtp.CodPessoa
        //                     }).FirstOrDefault();
        //        return query;
        //    }
        //}

        //public decimal? UserCreate(Usuario usr) 
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        try
        //        {
        //            TBT_USUARIO newUser = new TBT_USUARIO();
        //            newUser.IndAtivo = 1;
        //            newUser.CodPessoa = usr.CodPessoa;
        //            newUser.Login = usr.Login;
        //            newUser.Senha = usr.Senha;

        //            entities.TBT_USUARIO.Add(newUser);
        //            entities.SaveChanges();
        //            return newUser.CodUsuario;
        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //        }
        //    }

        //}


        //public bool UserEdit(Usuario usr) 
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        try
        //        {
        //            TBT_USUARIO editedUser = entities.TBT_USUARIO.Where(x => x.CodUsuario == usr.CodUsuario).Select(x => x).FirstOrDefault();
        //            editedUser.IndAtivo = usr.Ativo ? 1 : 0;
        //            editedUser.CodPessoa = usr.CodPessoa;
        //            editedUser.Login = usr.Login;
        //            if (!string.IsNullOrEmpty(usr.Senha))
        //                editedUser.Senha = usr.Senha;
        //            entities.Entry(editedUser).State = EntityState.Modified;
        //            entities.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }

        //}

        //public List<Usuario> SearchInfo(string txtLogin, string UserType)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {

        //        var query = from tbtu in entities.TBT_USER
        //                    join tbtut in entities.TBT_USER_TYPE
        //                    on tbtu.UserTypeCode equals tbtut.UserTypeCode
        //                    join tbtc in entities.TBT_CLIENT
        //                    on tbtu.ClientCode equals tbtc.ClientCode into _a
        //                    from tbtc in _a.DefaultIfEmpty()
        //                    join tbti in entities.TBT_INSPECTOR
        //                    on tbtu.InspectorCode equals tbti.InspectorCode
        //                    into _t
        //                    from tbti in _a.DefaultIfEmpty()
        //                    select new Usuario
        //                    {
        //                        Login = tbtu.Login,
        //                        Active = tbtu.Active == 1 ? true : false,
        //                        UserTypeCode = tbtu.UserTypeCode,
        //                        UserType = tbtut.Description,
        //                        ClientName = tbtc.Name,
        //                        InspectorName = tbti.Name
        //                    };

        //        if (!string.IsNullOrEmpty(txtLogin))
        //            query = query.Where(x => x.Login.Contains(txtLogin));

        //        if (!string.IsNullOrEmpty(UserType))
        //        {
        //            int code = Convert.ToInt32(UserType);
        //            query = query.Where(x => x.UserTypeCode == code);
        //        }
        //        return query.ToList();
        //    }
        //}
        //public Collection<SelectListItem> UserTypeList()
        //{
        //    try
        //    {
        //        Collection<SelectListItem> lista = new Collection<SelectListItem>();

        //        using (SmartBagEntities entities = new SmartBagEntities())
        //        {
        //            var ListaCinema = from tbti in entities.TBT_USER_TYPE
        //                              select tbti;

        //            lista.Add(new SelectListItem { Text = "", Selected = true });

        //            foreach (var item in ListaCinema)
        //            {
        //                lista.Add(new SelectListItem { Value = item.UserTypeCode.ToString(), Text = item.Description });
        //            }
        //        }

        //        return lista;
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Erro: " + HttpStatusCode.BadRequest);
        //    }
        //}

        public static Usuario AutenticaUsuario(String login, String senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                throw new Exception("User/Password incorrect");
                return null;
            }

            using (SmartBagEntities entities = new SmartBagEntities())
            {
                var query = (from u in entities.TBT_USUARIO
                             where u.Login.ToUpper().Equals(login.ToUpper())
                             && u.Senha.ToUpper().Equals(senha.ToUpper())
                             && u.Ativo == "1"
                             select new Usuario()
                             {
                                // CodUsuario = u.CodUsuario,
                                // CodPessoa = u.CodPessoa,
                                 Login = u.Login,
                                 Ativo = u.Ativo =="1" ? true : false,
                                 ID = u.ID,
                                 CreationDate = u.DtCadastro.Value
                             });

                Usuario usuario = query.FirstOrDefault();

                if (usuario == null)
                    throw new Exception("User/Password incorrect");

                return usuario;
            }
        }
    }
}