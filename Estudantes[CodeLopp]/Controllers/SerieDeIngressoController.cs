using Estudantes_CodeLopp_.Models;
using Estudantes_CodeLopp_.Models.DAOs;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Estudantes_CodeLopp_.Controllers
{
    public class SerieDeIngressoController : Controller
    {

        DAOSerieDeIngresso daoSerie;
        public SerieDeIngressoController()
        {
        daoSerie=new DAOSerieDeIngresso();

        }
        public ActionResult Index()
        {

            return View(daoSerie.ObterTudo());
        }




        public ActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(/*[Bind(Include = "serie")]*/ [Bind(Include = "id,serie")] SerieDeIngresso serie)
        {
            if (ModelState.IsValid)
            {
                //var x = new SerieDeIngresso { Serie = serie };
                //var resultado = daoSerie.Inserir(x);
                var resultado = daoSerie.Inserir(serie);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "SerieDeIngresso");
                }

            }
            return View(serie);

        }

        public ActionResult Detalhes(int id)
        {
            var serie = daoSerie.Obter(new SerieDeIngresso { Id = id });
            if (serie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(serie);

        }


        public ActionResult Editar(int id)
        {

            var serie = daoSerie.Obter(new SerieDeIngresso { Id = id });
            if (serie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(serie);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,nome")]SerieDeIngresso serie)
        {
            
            //serie.Serie = "2";
            //if (ModelState.IsValid)
            //{
                var resultado = daoSerie.Actualizar(serie);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "SerieDeIngresso");
                }

            //}
            return View(serie);

            
        }


        public ActionResult Eliminar(int id)
        {
            var serie = daoSerie.Obter(new SerieDeIngresso { Id = id });
            if (serie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(serie);
        }


        [HttpPost]
        public ActionResult Eliminar(SerieDeIngresso serie)
        {
            var resultado = daoSerie.Eliminar(serie);
            if (resultado >-1)
            {
            return RedirectToAction("Index");
            }
            return View();



        }
    }
}
