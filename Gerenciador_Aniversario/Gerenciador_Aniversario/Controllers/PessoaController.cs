using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gerenciador_Aniversario.Domain;
using Gerenciador_Aniversario.Models;
using Gerenciador_Aniversario.Repository;

namespace Gerenciador_Aniversario.Controllers
{
    public class PessoaController : Controller
    {

        private PessoaRepository repository = new PessoaRepository();

        // GET: Pessoa
        public ActionResult Index()
        {
            var Pessoas = repository.GetAll();
            return View(
                Pessoas.Select(a => new Pessoa {
                    PessoaID = a.PessoaID,
                    Nome = a.Nome,
                    Sobrenome = a.Sobrenome,
                    DtAniversario = a.DtAniversario
                }
            ));
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            
            var p = repository.GetById(id);

            Pessoa Pessoa = new Pessoa {
                PessoaID = p.PessoaID,
                Nome = p.Nome,
                Sobrenome = p.Sobrenome,
                DtAniversario = p.DtAniversario
            };

            ViewBag.DiasRestantes = Calculator.DiasRestantesAniversario(Pessoa.DtAniversario);

            return View(Pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            PessoaRepository r = repository;
            PessoaDomain pd = new PessoaDomain
            {
                PessoaID = pessoa.PessoaID,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                DtAniversario = pessoa.DtAniversario
            };

            try
            {
                if (ModelState.IsValid)
                {
                    r.Save(pd);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pessoa);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var p = repository.GetById(id);

            Pessoa Pessoa = new Pessoa
            {
                PessoaID = p.PessoaID,
                Nome = p.Nome,
                Sobrenome = p.Sobrenome,
                DtAniversario = p.DtAniversario
            };
            return View(Pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            PessoaRepository r = repository;
            PessoaDomain pd = new PessoaDomain {
                PessoaID = pessoa.PessoaID,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                DtAniversario = pessoa.DtAniversario
            };
            try
            {
                if (ModelState.IsValid)
                {
                    r.Update(pd);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pessoa);
                }
            }
            catch
            {
                return View(pessoa);
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var p = repository.GetById(id);
            Pessoa Pessoa = new Pessoa
            {
                PessoaID = p.PessoaID,
                Nome = p.Nome,
                Sobrenome = p.Sobrenome,
                DtAniversario = p.DtAniversario
            };

            return View(Pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaRepository r = repository;
            /*PessoaDomain pd = new PessoaDomain
            {
                PessoaID = pessoa.PessoaID,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                DtAniversario = pessoa.DtAniversario
            };*/

            r.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
