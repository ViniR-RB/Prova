using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aspent.Models
{
    public class Fisica : Pessoa
    {
        [Display(Name = "cpf")]
        public string? cpf { get; set; }

        [Display(Name = "rg")]
        public string? rg { get; set; }

        [Display(Name = "data de nascimento")]
        public DateTime? nascimento { get; set; }

        public int? ParceiroId { get; set; }
        public virtual Parceiro? Parceiro { get; set; }


        public virtual ICollection<ReservaHotel>? ReservaHotel { get; set; }
    }
}