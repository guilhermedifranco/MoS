using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Web.Utils
{
    public class SessionED
    {
        public static SessionED Current
        {
            get
            {
                if (HttpContext.Current.Session["__SessionED__"] == null)
                    HttpContext.Current.Session["__SessionED__"] = new SessionED();

                return (SessionED)HttpContext.Current.Session["__SessionED__"];
            }
        }

        public SessionED()
        {
            int count;
            Int32.TryParse(WebConfigurationManager.AppSettings["timeOutSession"], out count);
            HttpContext.Current.Session.Timeout = count;
        }
        public decimal CodUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string CodCliente { get; set; }
        public string CodRepresentante { get; set; }
        public string CodInspetor { get; set; }
        public string Perfil { get; set; }
        public bool IsAdmin { get; set; }  
        public string pReferencia { get; set; }
        public string page { get; set; }
        public int ordernacao { get; set; }
        public string DataCriacao { get; set; }
        public int InCdCinema { get; set; }

    }
}