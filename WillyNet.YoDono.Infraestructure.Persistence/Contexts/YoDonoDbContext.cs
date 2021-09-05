using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.Interfaces;
using WillyNet.YoDono.Core.Domain.Common;
using WillyNet.YoDono.Core.Domain.Entities;

namespace WillyNet.YoDono.Infraestructure.Persistence.Contexts
{
    public class YoDonoDbContext : IdentityDbContext<AppUser>
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;
        public YoDonoDbContext(DbContextOptions<YoDonoDbContext> options, 
            IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

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
