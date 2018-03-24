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


            return View(Pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
