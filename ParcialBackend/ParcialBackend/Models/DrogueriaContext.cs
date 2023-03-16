using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParcialBackend.Models;

public partial class DrogueriaContext : DbContext
{
    public DrogueriaContext()
    {
    }

    public DrogueriaContext(DbContextOptions<DrogueriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Farmacium> Farmacia { get; set; }

    public virtual DbSet<Farmaco> Farmacos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MHJ1ERR; Database=drogueria; Trusted_Connection=True; TrustServerCertificate=Yes ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("Id_cliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Farmacium>(entity =>
        {
            entity.HasKey(e => e.IdFarmacia);

            entity.ToTable("farmacia");

            entity.Property(e => e.IdFarmacia)
                .ValueGeneratedNever()
                .HasColumnName("Id_farmacia");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Farmaco>(entity =>
        {
            entity.HasKey(e => e.IdFarmacos);

            entity.ToTable("farmacos");

            entity.Property(e => e.IdFarmacos)
                .ValueGeneratedNever()
                .HasColumnName("Id_farmacos");
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.IdFarmacia).HasColumnName("Id_farmacia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Farmacos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_farmacos_clientes");

            entity.HasOne(d => d.IdFarmaciaNavigation).WithMany(p => p.Farmacos)
                .HasForeignKey(d => d.IdFarmacia)
                .HasConstraintName("FK_farmacos_farmacia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
