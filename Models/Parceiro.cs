using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aspent.Models
{
    public class Parceiro
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Tipo de Pessoa")]
        public string? TipoDePessoa { get; set; }

        [Display(Name = "Atividade")]
        public string? Atividade { get; set; }

        public virtual ICollection<Juridica>? Juridica { get; set;}
        public virtual ICollection<Fisica>? Fisica { get; set;}

    }
}