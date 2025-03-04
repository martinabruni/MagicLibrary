﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class SqldbMagiclibraryCoreDevContext : DbContext
{
    public SqldbMagiclibraryCoreDevContext()
    {
    }

    public SqldbMagiclibraryCoreDevContext(DbContextOptions<SqldbMagiclibraryCoreDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthorEntity> Authors { get; set; }

    public virtual DbSet<BookEntity> Books { get; set; }

    public virtual DbSet<BookLoanEntity> BookLoans { get; set; }

    public virtual DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__70DAFC34B92360EE");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<BookEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3DE0C2079D717010");

            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Author");
        });

        modelBuilder.Entity<BookLoanEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookLoan__4F5AD457E4A6F9F0");

            entity.HasOne(d => d.Book).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Loan_Book");

            entity.HasOne(d => d.User).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Loan_User");
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__1788CC4C99E810F0");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053484A71766").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.MembershipDate).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
