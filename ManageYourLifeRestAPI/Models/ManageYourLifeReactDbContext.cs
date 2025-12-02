using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManageYourLifeRestAPI.Models;

public partial class ManageYourLifeReactDbContext : DbContext
{
    public ManageYourLifeReactDbContext()
    {
    }

    public ManageYourLifeReactDbContext(DbContextOptions<ManageYourLifeReactDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Shoplist> Shoplists { get; set; }

    public virtual DbSet<ToDolist> ToDolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            return;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shoplist>(entity =>
        {
            entity
                .ToTable("Shoplist");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Info).HasMaxLength(50);
            entity.Property(e => e.Product).HasMaxLength(50);
        });

        modelBuilder.Entity<ToDolist>(entity =>
        {
            entity
                .ToTable("ToDolist");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Completed).HasMaxLength(5);
            entity.Property(e => e.Date).HasMaxLength(50);
            entity.Property(e => e.Info).HasMaxLength(100);
            entity.Property(e => e.Task).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
