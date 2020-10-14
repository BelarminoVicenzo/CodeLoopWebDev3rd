using System;
using System.ComponentModel.DataAnnotations;

namespace Estudantes_CodeLopp_.Models
{
    public class SerieDeIngresso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [Display(Name = "Série de Ingresso")]
        public string Serie { get; set; }
    }

}