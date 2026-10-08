using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MonoPraksa.Model;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Footballer> Footballers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clubs_pkey");

            entity.ToTable("clubs");

            entity.HasIndex(e => e.Name, "clubs_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(60)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Footballer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("footballers_pkey");

            entity.ToTable("footballers");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(100)
                .HasColumnName("player_name");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Club).WithMany(p => p.Footballers)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("footballers_club_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
