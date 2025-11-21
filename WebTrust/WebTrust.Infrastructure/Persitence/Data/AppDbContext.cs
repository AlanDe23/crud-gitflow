using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrust.Domain.Entities;

namespace WebTrust.Infrastructure.Persitence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }




        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Analisis> Analisis { get; set; }

        public DbSet<HistorialAnalisis> HistorialAnalisis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🧩 USUARIO
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.IdUsuario);

                entity.Property(u => u.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.HasIndex(u => u.Email)
                      .IsUnique();

                entity.Property(u => u.PasswordHash)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(u => u.FechaRegistro)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(u => u.Activo)
                      .HasDefaultValue(true);
            });

            // 🧩 ANALISIS
            modelBuilder.Entity<Analisis>(entity =>
            {
                entity.ToTable("Analisis");
                entity.HasKey(a => a.IdAnalisis);

                entity.Property(a => a.Url)
                      .IsRequired()
                      .HasMaxLength(300);

                entity.Property(a => a.Titulo)
                      .HasMaxLength(200);

                entity.Property(a => a.PorcentajeConfianza)
                      .HasColumnType("decimal(5,2)")
                      .IsRequired();

                entity.Property(a => a.Detalles)
                      .IsRequired(false);

                entity.Property(a => a.FechaAnalisis)
                      .HasDefaultValueSql("GETDATE()");

                // 🔗 Relación: Usuario → Analisis
                entity.HasOne(a => a.Usuario)
                      .WithMany(u => u.Analisis)
                      .HasForeignKey(a => a.IdUsuario)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // 🧩 HISTORIAL DE ANALISIS
            modelBuilder.Entity<HistorialAnalisis>(entity =>
            {
                entity.ToTable("HistorialAnalisis");
                entity.HasKey(h => h.IdHistorial);

                entity.Property(h => h.ResultadoAnterior)
                      .HasColumnType("decimal(5,2)")
                      .IsRequired();

                entity.Property(h => h.ResultadoNuevo)
                      .HasColumnType("decimal(5,2)")
                      .IsRequired();

                entity.Property(h => h.Observacion)
                      .HasMaxLength(300)
                      .IsRequired(false);

                entity.Property(h => h.FechaRegistro)
                      .HasDefaultValueSql("GETDATE()");

                // 🔗 Relación: Analisis → HistorialAnalisis
                entity.HasOne(h => h.Analisis)
                      .WithMany(a => a.Historiales)
                      .HasForeignKey(h => h.IdAnalisis)
                      .OnDelete(DeleteBehavior.Cascade);
            });



        }
    }
}