using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStoreApplicationLibrary
{
    public partial class Project1PizzaApplicationContext : DbContext
    {
        public Project1PizzaApplicationContext()
        {
        }

        public Project1PizzaApplicationContext(DbContextOptions<Project1PizzaApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PizzaVariation> PizzaVariation { get; set; }
        public virtual DbSet<StoreLocation> StoreLocation { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Orders", "PizzaApp");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrderTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreLocation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalCost)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.PizzaNum1Navigation)
                    .WithMany(p => p.OrdersPizzaNum1Navigation)
                    .HasForeignKey(d => d.PizzaNum1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_ID_Num");

                entity.HasOne(d => d.PizzaNum10Navigation)
                    .WithMany(p => p.OrdersPizzaNum10Navigation)
                    .HasForeignKey(d => d.PizzaNum10)
                    .HasConstraintName("FK_Pizza_ID_Num10");

                entity.HasOne(d => d.PizzaNum11Navigation)
                    .WithMany(p => p.OrdersPizzaNum11Navigation)
                    .HasForeignKey(d => d.PizzaNum11)
                    .HasConstraintName("FK_Pizza_ID_Num11");

                entity.HasOne(d => d.PizzaNum12Navigation)
                    .WithMany(p => p.OrdersPizzaNum12Navigation)
                    .HasForeignKey(d => d.PizzaNum12)
                    .HasConstraintName("FK_Pizza_ID_Num12");

                entity.HasOne(d => d.PizzaNum2Navigation)
                    .WithMany(p => p.OrdersPizzaNum2Navigation)
                    .HasForeignKey(d => d.PizzaNum2)
                    .HasConstraintName("FK_Pizza_ID_Num2");

                entity.HasOne(d => d.PizzaNum3Navigation)
                    .WithMany(p => p.OrdersPizzaNum3Navigation)
                    .HasForeignKey(d => d.PizzaNum3)
                    .HasConstraintName("FK_Pizza_ID_Num3");

                entity.HasOne(d => d.PizzaNum4Navigation)
                    .WithMany(p => p.OrdersPizzaNum4Navigation)
                    .HasForeignKey(d => d.PizzaNum4)
                    .HasConstraintName("FK_Pizza_ID_Num4");

                entity.HasOne(d => d.PizzaNum5Navigation)
                    .WithMany(p => p.OrdersPizzaNum5Navigation)
                    .HasForeignKey(d => d.PizzaNum5)
                    .HasConstraintName("FK_Pizza_ID_Num5");

                entity.HasOne(d => d.PizzaNum6Navigation)
                    .WithMany(p => p.OrdersPizzaNum6Navigation)
                    .HasForeignKey(d => d.PizzaNum6)
                    .HasConstraintName("FK_Pizza_ID_Num6");

                entity.HasOne(d => d.PizzaNum7Navigation)
                    .WithMany(p => p.OrdersPizzaNum7Navigation)
                    .HasForeignKey(d => d.PizzaNum7)
                    .HasConstraintName("FK_Pizza_ID_Num7");

                entity.HasOne(d => d.PizzaNum8Navigation)
                    .WithMany(p => p.OrdersPizzaNum8Navigation)
                    .HasForeignKey(d => d.PizzaNum8)
                    .HasConstraintName("FK_Pizza_ID_Num8");

                entity.HasOne(d => d.PizzaNum9Navigation)
                    .WithMany(p => p.OrdersPizzaNum9Navigation)
                    .HasForeignKey(d => d.PizzaNum9)
                    .HasConstraintName("FK_Pizza_ID_Num9");

                entity.HasOne(d => d.StoreLocationNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Location");
            });

            modelBuilder.Entity<PizzaVariation>(entity =>
            {
                entity.HasKey(e => e.PizzaId);

                entity.ToTable("PizzaVariation", "PizzaApp");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.PizzaSize)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PizzaType)
                    .IsRequired()
                    .HasMaxLength(9);
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.HasKey(e => e.CityName);

                entity.ToTable("StoreLocation", "PizzaApp");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.EmailAddress);

                entity.ToTable("Users", "PizzaApp");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E4FBA269BB")
                    .IsUnique();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.DefaultLocation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumCheeseOrdered).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumMeatOrdered).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumPepperoniOrdered).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumVeggieOrdered).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.PhysicalAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RecommendedPizza)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasDefaultValueSql("('Cheese')");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.DefaultLocationNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DefaultLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefaultLocation");
            });
        }
    }
}
