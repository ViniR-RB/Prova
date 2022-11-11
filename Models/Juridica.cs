using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace aspent.Models
{
    public class Juridica : Pessoa
    {
        [Display(Name = "CNPJ")]
        public string? CNPJ { get; set; }
        [Display(Name = "Inscricao Estadual")]
        public string? InscricaoEstadual { get; set; }

        [Display(Name = "Fundacao")]
        public DateTime? Fundacao { get; set; }

        public virtual ICollection<Parceiro>? Parceiro { get; set; }

    }
}