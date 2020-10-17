using Estudantes_CodeLopp_.Models;
using Estudantes_CodeLopp_.Models.DAOs;
using Estudantes_CodeLopp_.Utilidades;

using System.Net;
using System.Web.Mvc;

namespace Estudantes_CodeLopp_.Controllers
{
    public class MaeController : Controller
    {

        private DAOMae daoMae;

        public MaeController()
        {
            daoMae = new DAOMae();

        }
        // GET: Mae
        public ActionResult Index()
        {
            var m = daoMae.ObterTudo();
            return View(m);
        }


        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "id,nomeCompleto,cpf,dataPreferencialPagamento")] Mae mae)
        {
            if (ModelState.IsValid)
            {
                if (CpfUtils.IsValidCPF(mae.CPF) && !daoMae.VerificarExistenciaCPF(mae.CPF))
                {
                    var resultado = daoMae.Inserir(mae);
                    if (resultado > -1)
                    {
                        return RedirectToAction("Index", "Mae");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(mae.CPF), "CPF incorrecto");
                    return View(mae);
                }

            }
            return View(mae);

        }

        public ActionResult Detalhes(int id)
        {
            var mae = daoMae.ObterPeloId(new Mae { Id = id });
            if (mae == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(mae);
        }
        public ActionResult Editar(int id)
        {
            var mae = daoMae.ObterPeloId(new Mae { Id = id });
            if (mae == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(mae);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,nomeCompleto,cpf,dataPreferencialPagamento")] Mae mae)
        {

            if (ModelState.IsValid)
            {
                var resultado = daoMae.Actualizar(mae);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "Mae");
                }

            }
            return View(mae);

        }

        public ActionResult Eliminar(int id)
        {
            var mae = daoMae.ObterPeloId(new Mae { Id = id });
            if (mae == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(mae);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Mae mae)
        {
            var resultado = daoMae.Eliminar(mae);
            if (resultado > -1)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}