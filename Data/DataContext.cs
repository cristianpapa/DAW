using DAW2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace DAW2._0.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext>options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-L383BD9;Initial Catalog=DAW2.0;Integrated Security=True");
        }
        public DbSet<Achizitie> Achizitii { get; set; }
        public DbSet<User> Useri { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Plata> Plati { get; set; }
        public DbSet<Livrare> Livrari { get; set; }
        public DbSet<Adresa> Adrese { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achizitie>()
                .HasKey(a => new { a.IdUser, a.IdProdus, a.IdComanda });
            modelBuilder.Entity<Achizitie>()
                .HasOne(u => u.User)
                .WithMany(a => a.Achizitii)
                .HasForeignKey(u => u.IdUser);
            modelBuilder.Entity<Achizitie>()
                .HasOne(p => p.Produs)
                .WithMany(a => a.Achizitii)
                .HasForeignKey(p => p.IdProdus);
            modelBuilder.Entity<Achizitie>()
               .HasOne(p => p.Comanda)
               .WithMany(a => a.Achizitii)
               .HasForeignKey(p => p.IdComanda);


            modelBuilder.Entity<Comanda>()
                .HasOne(p => p.Plata)
                .WithOne(c => c.Comanda)
                .HasForeignKey<Plata>(c => c.Id);

            modelBuilder.Entity<Comanda>()
               .HasOne(p => p.Livrare)
               .WithOne(c => c.Comanda)
               .HasForeignKey<Livrare>(c => c.Id);

            modelBuilder.Entity<Livrare>()
               .HasOne(p => p.Adresa)
               .WithMany(c => c.Livrari)
               .HasForeignKey(c => c.IdAdresa);


        }
    }
}
