using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace aspent.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) :

        base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Fisica> Fisica { get; set; }


        public DbSet<Juridica> Juridica { get; set; }

        public DbSet<ReservaHotel> ReservaHotel { get; set; }

        public DbSet<Parceiro> Parceiro { get; set; }

    }

}
