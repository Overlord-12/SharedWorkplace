using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SharedWorkplace.Models
{
    public partial class BoardContext : DbContext
    {
        public BoardContext()
        {
        }

        public BoardContext(DbContextOptions<BoardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desk> Desks { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Board;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Desk>(entity =>
            {
                entity.ToTable("Desk");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.NameTable).HasMaxLength(50);

                entity.Property(e => e.TableId).HasMaxLength(50);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Desks)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_Desk_Devices");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Device1)
                    .HasMaxLength(50)
                    .HasColumnName("Device");

                entity.Property(e => e.TableId).HasColumnName("TableID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Role1)
                    .HasMaxLength(50)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("UserTable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.UseTime).HasColumnType("time(1)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTable_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
