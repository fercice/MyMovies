using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using MyMovies.Domain.Entities;
using MyMovies.Infra.Data.Mapping;

namespace MyMovies.Infra.Data.Context
{
    public class MyMoviesContext : DbContext
    {
        private static bool dbCreated = false;

        public DbSet<Diretor> Diretor { get; set; }
        public DbSet<Filme> Filme { get; set; }        
        public DbSet<Genero> Genero { get; set; }

        public MyMoviesContext()
        {
            if (!dbCreated)
            {
                dbCreated = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnectionSqlite"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DiretorMap()).Entity<Diretor>();
            modelBuilder.ApplyConfiguration(new FilmeMap()).Entity<Filme>();            
            modelBuilder.ApplyConfiguration(new GenerorMap()).Entity<Genero>();
        }

        public override int SaveChanges()
        {
            foreach (var entidade in ChangeTracker.Entries().Where(a => a.Entity.GetType().GetProperty("DataInclusao") != null))
            {
                if (entidade.State == EntityState.Added)
                {
                    entidade.Property("DataInclusao").CurrentValue = DateTime.Now;
                }

                if (entidade.State == EntityState.Modified)
                {
                    entidade.Property("DataInclusao").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
