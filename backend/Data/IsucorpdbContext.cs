using System;
using System.Collections.Generic;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Task = backend.Models.Task;

namespace backend.Data;

public partial class IsucorpdbContext : DbContext
{
    public IsucorpdbContext()
    {
    }

    public IsucorpdbContext(DbContextOptions<IsucorpdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949B15DC4D136");

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC078FC45011");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E445D98CB3").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
