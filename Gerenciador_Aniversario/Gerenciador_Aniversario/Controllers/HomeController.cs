using Gerenciador_Aniversario.Domain;
using Gerenciador_Aniversario.Models;
using Gerenciador_Aniversario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gerenciador_Aniversario.Controllers
{
    public class HomeController : Controller
    {
        private PessoaRepository repository = new PessoaRepository();
        // GET: Home
        public ActionResult Index()
        {
            var Pessoas = repository.GetAll();
            DateTime dt = DateTime.Now;

            // Próximos Aniversariantes

            var ordered = from pessoa in Pessoas
                          orderby IsBeforeNow(dt, pessoa.DtAniversario), pessoa.DtAniversario.Month, pessoa.DtAniversario.Day
                          select pessoa;

            List<PessoaDomain> OrderedList = new List<PessoaDomain>();

            foreach (var p in ordered)
            {
                OrderedList.Add(p);
            }

            bool IsBeforeNow(DateTime now, DateTime dateTime)
            {
                return dateTime.Month < now.Month
                    || (dateTime.Month == now.Month && dateTime.Day < now.Day);
            }

            ViewBag.PessoasByDate = OrderedList.Select(a => new Pessoa
            {
                PessoaID = a.PessoaID,
                Nome = a.Nome,
                Sobrenome = a.Sobrenome,
                DtAniversario = a.DtAniversario
            });

            
            // Aniversariantes do Dia

            List<PessoaDomain> NewList = new List<PessoaDomain>();
            var AllPessoas = repository.GetAll();

            foreach (PessoaDomain p in AllPessoas)
            {
                if (p.DtAniversario.Day == dt.Day && p.DtAniversario.Month == dt.Month)
                    NewList.Add(p);
            }

            ViewBag.PessoasToday = NewList.Select(a => new Pessoa
            {
                PessoaID = a.PessoaID,
                Nome = a.Nome,
                Sobrenome = a.Sobrenome,
                DtAniversario = a.DtAniversario
            });


            return View();
        }
    }
}