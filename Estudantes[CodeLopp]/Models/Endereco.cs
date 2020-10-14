using System;
using System.ComponentModel.DataAnnotations;

namespace Estudantes_CodeLopp_.Models
{
    public class Endereco
    {

        public int Id { get; set; }

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

    }
     

}