using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace aspent.Models
{
    public class ReservaHotel
    {
        public int Id { get; set; }
        [Display(Name = "Numero Da Reserva")]
        public string? NumeroReserva { get; set; }
        [Display(Name = "Valor Da Reserva")]
        public double Valor { get; set; }

        [Display(Name = "Data da Reserva")]
        public DateTime DataReserva { get; set; }
        public virtual ICollection<Fisica>? Fisica { get; set; }
    }
}