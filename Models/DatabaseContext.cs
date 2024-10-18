using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kursovaya1.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\database;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("Test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("DATE")
                .HasColumnName("date");
            entity.Property(e => e.Discipline)
                .HasColumnType("VARCHAR (100)")
                .HasColumnName("discipline");
            entity.Property(e => e.FirstName)
                .HasColumnType("VARCHAR (100)")
                .HasColumnName("first_name");
            entity.Property(e => e.Group)
                .HasColumnType("VARCHAR (100)")
                .HasColumnName("group");
            entity.Property(e => e.LastName)
                .HasColumnType("VARCHAR (100)")
                .HasColumnName("last_name");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.SecondName)
                .HasColumnType("VARCHAR (100)")
                .HasColumnName("second_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
