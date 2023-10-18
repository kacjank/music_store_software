using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sklep_muzyczny.Models;

namespace Sklep_muzyczny.Data
{
    public class Sklep_muzycznyContext : DbContext
    {
        public Sklep_muzycznyContext (DbContextOptions<Sklep_muzycznyContext> options)
            : base(options)
        {
        }

        public DbSet<Sklep_muzyczny.Models.Produkt> Produkt { get; set; } = default!;

        public DbSet<Sklep_muzyczny.Models.Klient> Klient { get; set; }

        public DbSet<Sklep_muzyczny.Models.Producent> Producent { get; set; }

        public DbSet<Sklep_muzyczny.Models.Kategoria> Kategoria { get; set; }

        public DbSet<Sklep_muzyczny.Models.Podkategoria> Podkategoria { get; set; }

        public DbSet<Sklep_muzyczny.Models.Wojewodztwo> Wojewodztwo { get; set; }
    }
}
