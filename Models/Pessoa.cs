using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace aspent.Models
{
    public class Pessoa
    {
        [Display(Name = "Código")]
        public int Id { get; set; }



        public string? Nome { get; set; }

        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
    }
}