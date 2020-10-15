using Estudantes_CodeLopp_.Models;
using Estudantes_CodeLopp_.Models.DAOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Estudantes_CodeLopp_.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Endereco

        DAOEndereco daoEndereco;
        public EnderecoController()
        {
            daoEndereco=new DAOEndereco();
        }
        public ActionResult Index()
        {
            
            return View(daoEndereco.ObterTudo());
        }


        public ActionResult Detalhes(int id)
        {
            var end = daoEndereco.Obter(new Endereco { Id = id });
            if (end == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(end);
        }
        public ActionResult Editar(int id)
        {
            var end = daoEndereco.Obter(new Endereco { Id = id });
            if (end == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(end);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,cep,rua,numeroDaResidencia,complemento,bairro,cidade,estado")] Endereco end)
        {

            if (ModelState.IsValid)
            {
                var resultado = daoEndereco.Actualizar(end);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "Endereco");
                }

            }
            return View(end);

        }

        public ActionResult Eliminar(int id)
        {
            var end = daoEndereco.Obter(new Endereco { Id = id });
            if (end == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(end);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Endereco end)
        {
            var resultado = daoEndereco.Eliminar(end);
            if (resultado > -1)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}