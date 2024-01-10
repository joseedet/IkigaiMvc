using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ikigai.Models;

namespace Ikigai.Data
{

    public class IkigaiDbContext : IdentityDbContext
    {
        public IkigaiDbContext(DbContextOptions<IkigaiDbContext> options)
            : base(options)
        {
        }

        public DbSet <Cliente> Cliente {get;set;}
        public DbSet <DetalleCliente> DetalleCliente {get;set;}
        public DbSet <Planin> Planin {get;set;}
        public DbSet <Categoria> Categoria {get;set;}
        public DbSet <SubCategoria> SubCategoria{get;set;}
        public DbSet <TipoDocumento> TipoDocumento { get; set; }
    }
}
