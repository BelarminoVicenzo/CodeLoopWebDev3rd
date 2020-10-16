using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudantes_CodeLopp_.Models.ViewModels
{
    public class AlunoMaeEnderecoViewModel
    {
        //-- aluno

        public string IdAluno { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [Display(Name = "Nome Completo")]
        [StringLength(100)]
        public string NomeCompletoAluno { get; set; }
        [Display(Name ="Série de Ingresso")]
        public int IdSerieDeIngresso { get; set; }
     
        public int IdMaeFK { get; set; }
        public int IdEnderecoFK { get; set; }

        
                //-- endereco

        public int IdEnderecoPK { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O CEP tem de ter no mínimo {2} e no máximo {1}")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [StringLength(100)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [Display(Name = "Número da Residência")]
        public int NumeroDaResidencia { get; set; }
        [StringLength(50)]

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [StringLength(35)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [StringLength(25)]
        public string Estado { get; set; }


        //-- mae

        public int IdMaePK { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [Display(Name = "Nome Completo")]
        [StringLength(100)]
        public string NomeCompletoMae { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "O CPF tem de ter no mínimo 11 e no máximo 11 sem o traço")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Preferencial Pag. Mensalidade")]
        public DateTime? DataPreferencialPagamento { get; set; }

    }
}