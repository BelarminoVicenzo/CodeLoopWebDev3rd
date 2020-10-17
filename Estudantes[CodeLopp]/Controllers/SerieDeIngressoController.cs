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
    public class SerieDeIngressoController : Controller
    {
        private DAOSerieDeIngresso daoSerie;
        public SerieDeIngressoController()
        {
            daoSerie = new DAOSerieDeIngresso();
        }


        // GET: SerieDeIngresso
        public ActionResult Index()
        {
            var serie = (from s in daoSerie.ObterTudo()
                         orderby s.Serie
                         select s);
            return View(serie.ToList());
        }

        public ActionResult Detalhes(int id)
        {
            var serie = daoSerie.ObterPeloId(new SerieDeIngresso { Id = id });
            if (serie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(serie);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "id,serie")] SerieDeIngresso serie)
        {
            if (ModelState.IsValid)
            {
                var resultado = daoSerie.Inserir(serie);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "SerieDeIngresso");
                }

            }
            return View(serie);

        }


        public ActionResult Editar(int id)
        {
            var mae = daoSerie.ObterPeloId(new SerieDeIngresso { Id = id });
            if (mae == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(mae);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,serie")] SerieDeIngresso serie)
        {

            if (ModelState.IsValid)
            {
                var resultado = daoSerie.Actualizar(serie);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "SerieDeIngresso");
                }
            }
            return View(serie);

        }

        public ActionResult Eliminar(int id)
        {
            var serie = daoSerie.ObterPeloId(new SerieDeIngresso { Id = id });
            if (serie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(serie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(SerieDeIngresso serie)
        {
            var resultado = daoSerie.Eliminar(serie);
            if (resultado > -1)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }

 
}