using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskCode.Models;

namespace TaskCode.Data;

public partial class CarteraDbContext : DbContext
{
    public CarteraDbContext()
    {
    }

    public CarteraDbContext(DbContextOptions<CarteraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaCredito> CategoriaCreditos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaCredito>(entity =>
        {
            entity.ToTable("CategoriaCredito");

            entity.Property(e => e.Categoria)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
