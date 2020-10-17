using AutoMapper;
using Estudantes_CodeLopp_.Models;
using Estudantes_CodeLopp_.Models.DAOs;
using Estudantes_CodeLopp_.Models.DTOs;
using Estudantes_CodeLopp_.Models.ViewModels;
using Estudantes_CodeLopp_.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Estudantes_CodeLopp_.Controllers
{
    public class AlunoController : Controller
    {

        DAOAluno daoAluno;
        DAOSerieDeIngresso daoSerie;
        DAOEndereco daoEndereco;
        DAOMae daoMae;


        public AlunoController()
        {
            daoAluno = new DAOAluno();
            daoSerie = new DAOSerieDeIngresso();
            daoMae = new DAOMae();
            daoEndereco = new DAOEndereco();

        }
        // GET: Aluno
        public ActionResult Index()
        {
            var dtoAluno = from a in daoAluno.ObterTudoDTO()
                           orderby a.NomeCompleto
                           select a;
            return View(dtoAluno);
        }

        public ActionResult Cadastrar()
        {
            DAOSerieDeIngresso daoSerie = new DAOSerieDeIngresso();
            ViewBag.idSerieDeIngresso = new SelectList(daoSerie.ObterTudo(), "id", "serie");
            ViewBag.IdMae = new SelectList(daoMae.ObterNomeECPF(), "id", "nomeCompleto");
            ViewBag.IdEndereco = new SelectList(daoEndereco.ObterTudo(), "id", "id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "id,nomeCompleto,idSerieDeIngresso,idMae,idEndereco")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var resultado = daoAluno.Inserir(aluno);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "Aluno");
                }
            }
            return View(aluno);
        }



        public ActionResult CadastrarUnico()
        {
            
            ViewBag.idSerieDeIngresso = new SelectList(daoSerie.ObterTudo(), "id", "serie");
            ViewBag.IdMae = new SelectList(daoMae.ObterNomeECPF(), "id", "nomeCompleto");
            ViewBag.IdEndereco = new SelectList(daoEndereco.ObterTudo(), "id", "id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarUnico(AlunoMaeEnderecoViewModel ame)
        {
            if (ModelState.IsValid)
            {


                if (CpfUtils.IsValidCPF(ame.CPF))
                {

                    var aluno = Mapper.Map<AlunoMaeEnderecoViewModel, Aluno>(ame);
                    daoMae.Inserir(Mapper.Map<AlunoMaeEnderecoViewModel, Mae>(ame));
                    aluno.IdMae = daoAluno.ObterUltimoId();

                    daoEndereco.Inserir(Mapper.Map<AlunoMaeEnderecoViewModel, Endereco>(ame));
                    aluno.IdEndereco = daoAluno.ObterUltimoId();

                    aluno.Id = Guid.NewGuid().ToString();

                    var resultado = daoAluno.Inserir(aluno);
                    if (resultado > -1)
                    {

                        return RedirectToAction("Index", "Aluno");
                    }

                }
                else
                {
                    ViewBag.idSerieDeIngresso = new SelectList(daoSerie.ObterTudo(), "id", "serie");
                    ModelState.AddModelError(nameof(ame.CPF), "CPF incorrecto");
                    return View(ame);

                }

            }
            return View(ame);

        }


        public ActionResult Detalhes(string id)
        {
            var aluno = daoAluno.ObterDTO(new Aluno { Id = id });
            if (aluno == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(aluno);
        }
        public ActionResult Editar(string id)
        {
            var aluno = daoAluno.ObterPeloId(new Aluno { Id = id });
            if (aluno == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DAOSerieDeIngresso daoSerie = new DAOSerieDeIngresso();
            DAOMae daoMae = new DAOMae();
            DAOEndereco daoEndereco = new DAOEndereco();
            ViewBag.idSerieDeIngresso = new SelectList(daoSerie.ObterTudo(), "id", "serie");
            ViewBag.IdMae = new SelectList(daoMae.ObterNomeECPF(), "id", "nomeCompleto");
            ViewBag.IdEndereco = new SelectList(daoEndereco.ObterTudo(), "id", "id");
            return View(aluno);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,nomeCompleto,idSerieDeIngresso,idMae,idEndereco")] Aluno aluno)
        {

            if (ModelState.IsValid)
            {
                var resultado = daoAluno.Actualizar(aluno);
                if (resultado > -1)
                {

                    return RedirectToAction("Index", "Aluno");
                }

            }
            return View(aluno);

        }

        public ActionResult Eliminar(string id)
        {
            var aluno = daoAluno.ObterDTO(new Aluno { Id = id });
            if (aluno == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Aluno aluno)
        {

            var resultado = daoAluno.Eliminar(aluno);
            if (resultado > -1)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}