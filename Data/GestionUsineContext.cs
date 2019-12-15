using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionUsine.Models;

namespace GestionUsine.Data
{
    public class GestionUsineContext : DbContext
    {
        public GestionUsineContext (DbContextOptions<GestionUsineContext> options)
            : base(options)
        {
        }

        public DbSet<GestionUsine.Models.SuperUser> SuperUser { get; set; }

        public DbSet<GestionUsine.Models.Employe> Employe { get; set; }

        public DbSet<GestionUsine.Models.ChefEquipe> ChefEquipe { get; set; }

        public DbSet<GestionUsine.Models.Role> Role { get; set; }
    }
}
