using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project_Users_Managers.Models;

namespace Project_Users_Managers.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC076BF278A7");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Executor).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
