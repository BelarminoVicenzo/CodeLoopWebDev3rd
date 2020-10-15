using AutoMapper;

using Estudantes_CodeLopp_.Models;
using Estudantes_CodeLopp_.Models.DAOs;
using Estudantes_CodeLopp_.Models.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace Estudantes_CodeLopp_.Controllers
{
    public class AlunoMaeEnderecoController : Controller
    {

        DAOSerieDeIngresso daoSerie;
        public AlunoMaeEnderecoController()
        {
            daoSerie = new DAOSerieDeIngresso();
        }
        
        // GET: Aluno
        public ActionResult Index()
        {


            var aluno = new Aluno
            {
                Id=Guid.NewGuid().ToString(),
                NomeCompleto = "Aluno 1",
                IdEndereco = 1,
                IdMae = 2,
                IdSerieDeIngresso = 3
            };
            var mae = new Mae
            {
                Id=2,
                NomeCompleto = "Mae 1",
                CPF = "123456789-01",
                DataPreferencialPagamento = DateTime.Now
            };

            var end = new Endereco
            {
                Id=3,
                CEP = "12345-678",
                Rua = "Rua 1",
                NumeroDaResidencia = 1,
                Complemento = "etc",
                Bairro = "Bairro 1",
                Cidade = "Cidade 1",
                Estado = "Estado 1"
            };

            AlunoMaeEnderecoViewModel ame = Mapper.Map<AlunoMaeEnderecoViewModel>(aluno);
            ame = Mapper.Map<AlunoMaeEnderecoViewModel>(mae);
            ame = Mapper.Map<AlunoMaeEnderecoViewModel>(end);
            //mapper only working on the last map

            ame = new AlunoMaeEnderecoViewModel
            {
                IdAluno = Guid.NewGuid().ToString(),
                NomeCompletoAluno = "Aluno 1",
                IdEnderecoFK = 1,
                IdMaeFK = 1,
                IdSerieDeIngresso = 3,
                
                CEP = "12345-678",
                Rua = "Rua 1",
                NumeroDaResidencia = 1,
                Complemento = "etc",
                Bairro = "Bairro 1",
                Cidade = "Cidade 1",
                Estado = "Estado 1",
                
                NomeCompletoMae = "Mae 1",
                CPF = "123456789-01",
                DataPreferencialPagamento = DateTime.Now
            };

            var listAme = new List<AlunoMaeEnderecoViewModel>();
            listAme.Add(ame);

            return View(listAme);
        }



        public ActionResult Cadastrar()
        {
            ViewBag.idSerieDeIngresso = new SelectList(daoSerie.ObterTudo(), "id", "serie");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(AlunoMaeEnderecoViewModel ame)
        {

            return View();
        }
    }
}