using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GueessPlayer> GueessPlayers { get; set; }
        public DbSet<XOImagesColmns> XOImagesColmns { get; set; }
        public DbSet <XOImagesRows> XOImagesRows { get; set; }
        public DbSet<PassWord> PassWords { get; set; }
        public DbSet<Risk> Risks { get; set; }
        public DbSet<Acting> Acting { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
