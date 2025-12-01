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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=JonnaW\\SQLEXPRESS; Database=ManageYourLifeReactDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shoplist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Shoplist");

            entity.Property(e => e.Info).HasMaxLength(50);
            entity.Property(e => e.Product).HasMaxLength(50);
        });

        modelBuilder.Entity<ToDolist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ToDolist");

            entity.Property(e => e.Completed).HasMaxLength(5);
            entity.Property(e => e.Date).HasMaxLength(50);
            entity.Property(e => e.Info).HasMaxLength(100);
            entity.Property(e => e.Task).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
