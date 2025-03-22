using Microsoft.EntityFrameworkCore;
using Rommanel.Domain.Entities;

namespace Rommanel.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.HasIndex(c => c.CPF_CNPJ).IsUnique();
                cliente.HasIndex(c => c.Email).IsUnique();

                cliente.OwnsOne(c => c.Endereco, endereco =>
                {
                    endereco.Property(e => e.CEP).HasColumnName("CEP").IsRequired();
                    endereco.Property(e => e.Logradouro).HasColumnName("Logradouro").IsRequired();
                    endereco.Property(e => e.Numero).HasColumnName("Numero").IsRequired();
                    endereco.Property(e => e.Bairro).HasColumnName("Bairro").IsRequired();
                    endereco.Property(e => e.Cidade).HasColumnName("Cidade").IsRequired();
                    endereco.Property(e => e.Estado).HasColumnName("Estado").IsRequired();
                });
            });
        }
    }
}
