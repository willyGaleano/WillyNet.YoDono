using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Entities;

namespace WillyNet.YoDono.Infraestructure.Persistence.Contexts
{
    public class YoDonoDbContext : IdentityDbContext<AppUser>
    {
        public YoDonoDbContext(DbContextOptions<YoDonoDbContext> options) : base(options)
        {
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.EstadoId);
                entity.ToTable("Estado");
                entity.Property(e => e.EstadoId).ValueGeneratedNever();
                entity.Property(e => e.EstadoNomb)
                                .IsRequired()
                                .HasMaxLength(20);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.TipoId);
                entity.ToTable("Tipo");
                entity.Property(e => e.TipoId).ValueGeneratedNever();
                entity.Property(e => e.TipoNomb)
                                .IsRequired()
                                .HasMaxLength(20);
                entity.Property(e => e.TipoColor)
                                .IsRequired()
                                .HasMaxLength(10);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProducId);
                entity.ToTable("Producto");
                entity.Property(e => e.ProducNomb)
                                   .IsRequired()
                                   .HasMaxLength(20);
                entity.Property(e => e.ProducDescrip)
                                   .IsRequired()
                                   .HasMaxLength(150);
                entity.Property(e => e.ProducImageUrl)                                   
                                   .HasMaxLength(200);

                entity
                    .HasOne(d => d.Estado)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(f => f.EstadoId);
                entity
                    .HasOne(d => d.Tipo)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(f => f.TipoId);
                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(f => f.UserId);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.PedidoId);
                entity.ToTable("Pedido");
                entity.Property(e => e.PedidoId).ValueGeneratedNever();
                entity
                      .HasOne(e => e.UserSolicitante)
                      .WithMany(e => e.Pedidos)
                      .HasForeignKey(e => e.SolicitanteId);
                entity
                      .HasOne(e => e.Producto)
                      .WithMany(e => e.Pedidos)
                      .HasForeignKey(e => e.ProductoId);
            });

        }


    }
}
