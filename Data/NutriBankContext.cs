using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriBank.Models;

namespace NutriBank.Data
{
    public class NutriBankContext : IdentityDbContext<Usuario,IdentityRole<Guid>,Guid>
    {
        public NutriBankContext(DbContextOptions<NutriBankContext> options) : base(options)
        {
        }

        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ContaBancaria>()
                .HasOne(c => c.Usuario)
                .WithOne(c => c.ContaBancaria);
            builder.Entity<Usuario>()
                .HasOne(c => c.ContaBancaria)
                .WithOne(c => c.Usuario)
                .HasPrincipalKey<Usuario>(c=>c.Id);
            builder.Entity<IdentityUserLogin<Guid>>()
                .HasKey(c => c.UserId);
            builder.Entity<IdentityUserRole<Guid>>()
                .HasKey(c => c.RoleId);
            builder.Entity<IdentityUserToken<Guid>>()
                .HasKey(c=>c.UserId);
        }
    }
}
