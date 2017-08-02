using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Messages
{
    public class Usuario
    {

        public decimal CodUsuario { get; set; }
        public String CodPessoa { get; set; }
        public String NomePessoa { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public bool Ativo { get; set; }
        public decimal ID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}