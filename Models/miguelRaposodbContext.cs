using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotNetExercise.Models
{
    public partial class miguelRaposodbContext : DbContext
    {
        public miguelRaposodbContext()
        {
        }

        public miguelRaposodbContext(DbContextOptions<miguelRaposodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;port=3306;database=miguelRaposodb;uid=root;password=admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("claims");

                entity.HasIndex(e => e.VehicleId, "vehicle_Id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_Id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicle_Id");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owners");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phoneNumber");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.IdVehicles)
                    .HasName("PRIMARY");

                entity.ToTable("vehicles");

                entity.HasIndex(e => e.OwnerId, "owner_Id");

                entity.Property(e => e.IdVehicles)
                    .ValueGeneratedNever()
                    .HasColumnName("idVehicles");

                entity.Property(e => e.Brand)
                    .HasMaxLength(45)
                    .HasColumnName("brand");

                entity.Property(e => e.Model)
                    .HasMaxLength(45)
                    .HasColumnName("model");

                entity.Property(e => e.OwnerId).HasColumnName("owner_Id");

                entity.Property(e => e.Vehiclescol)
                    .HasMaxLength(45)
                    .HasColumnName("vehiclescol");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicles_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
