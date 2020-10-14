using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Estudantes_CodeLopp_.Models
{
    public class Aluno
    {

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido!")]
        [Display(Name = "Nome Completo")]
        [StringLength(100)]
        public string NomeCompleto { get; set; }
        public int IdSerieDeIngresso { get; set; }
        public int IdMae { get; set; }
        public int IdEndereco { get; set; }


        [ForeignKey("IdSerieDeIngresso")]
        public virtual SerieDeIngresso SerieDeIngresso { get; set; }

        [ForeignKey("IdMae")]
        public virtual Mae Mae { get; set; }

        [ForeignKey("IdEndereco")]
        public virtual Endereco Endereco { get; set; }

    }
}