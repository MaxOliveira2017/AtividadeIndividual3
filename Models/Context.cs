using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AtvidadeModuloTres.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> Options) : base(Options)
        {

        }
        public DbSet<ClienteCadastro> Clientecadastro { get; set; }
        public DbSet<ClienteReserva> Clientereserva { get; set; }
    }
}
