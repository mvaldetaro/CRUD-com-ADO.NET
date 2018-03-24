using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerenciador_Aniversario.Models
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DtAniversario { get; set; }
    }
}