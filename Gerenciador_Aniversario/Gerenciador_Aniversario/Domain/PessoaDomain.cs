using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gerenciador_Aniversario.Domain
{
    public class PessoaDomain
    {
        public int PessoaID { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo Data de Aniversário é obrigatório.")]
        public DateTime DtAniversario { get; set; }
    }
}