using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sl.GrupoAPI.Models;

namespace Sl.GrupoAPI.Data
{

    public class GrupoContext : DbContext
    {
        public GrupoContext(DbContextOptions<GrupoContext> opts)
            : base(opts)
        {

        }

        public DbSet<Grupo> Grupos { get; set; }
    }
}