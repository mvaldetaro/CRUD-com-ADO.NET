using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gerenciador_Aniversario.Models
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Display(Name = "Data de Aniversário")]
        public DateTime DtAniversario { get; set; }
    }
}