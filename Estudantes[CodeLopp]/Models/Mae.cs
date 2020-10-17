using System;
using System.ComponentModel.DataAnnotations;

namespace Estudantes_CodeLopp_.Models
{
    public class Mae
    {
                
        public int Id { get; set; }

        [Required (ErrorMessage ="Este campo deve ser preenchido!")]
        [Display(Name = "Nome Completo")]
        [StringLength(100)]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [StringLength(12,MinimumLength =12,ErrorMessage ="O CPF tem de ter no mínimo 11 e no máximo 11 sem o traço")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Preferencial Pag. Mensalidade")]
        public DateTime? DataPreferencialPagamento { get; set; }
    }

    
}