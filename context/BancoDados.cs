using In_MemoryDataBaseApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace In_MemoryDataBaseApi.context
{
    public class BancoDados : DbContext
    {
        public DbSet<Usuarios> Usuario { get; set; }

        public BancoDados(DbContextOptions options) : base(options) { }

        public BancoDados()
        {
            this.Database.EnsureCreated();

        }
        /* MOSTRAS QUEM E  MINHA DATA BASE E DEFINIR QUE ELA ESTA EM MEMORIA 
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("minhadatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasKey(c => c.id);
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios()
            {
                id = 1,
                nome = "jose",
                email = "jose@gmail.com.br",
                endereço = "santa cruz rio de janeiro guandu "
                
            }) ;





        }
    }
}
