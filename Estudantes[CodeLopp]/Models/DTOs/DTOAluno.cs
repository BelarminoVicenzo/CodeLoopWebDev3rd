using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudantes_CodeLopp_.Models.DTOs
{
    public class DTOAluno
    {


        public string Id { get; set; }
        public string IdMae { get; set; }
        public string IdEndereco { get; set; }
        

        [Display(Name = "Nome do Aluno")]
        public string NomeCompleto { get; set; }

        [Display(Name = "Série de Ingresso")]
        public string Serie { get; set; }
        
        [Display(Name = "Nome da Mãe")]
        public string NomeCompletoMae { get; set; }

        public string CEP { get; set; }
        public string Rua { get; set; }
        [Display(Name = "Número da Residência")]
        public int NumeroDaResidencia { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}