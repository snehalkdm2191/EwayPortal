using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Portal.Api.Model
{
    public partial class EwayPortalDbContext : DbContext
    {
        public EwayPortalDbContext()
        {
        }

        public EwayPortalDbContext(DbContextOptions<EwayPortalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContentGroup> ContentGroups { get; set; }
        public virtual DbSet<ContentMaster> ContentMasters { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeContent> EmployeeContents { get; set; }
        public virtual DbSet<EmployeeGroup> EmployeeGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ContentGroup>(entity =>
            {
                entity.ToTable("ContentGroup");

                entity.Property(e => e.ContentGroupId).ValueGeneratedNever();

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.ContentGroups)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_ContentGroup_ContentMaster");

                entity.HasOne(d => d.EmployeeGroup)
                    .WithMany(p => p.ContentGroups)
                    .HasForeignKey(d => d.EmployeeGroupId)
                    .HasConstraintName("FK_ContentGroup_EmployeeGroup");
            });

            modelBuilder.Entity<ContentMaster>(entity =>
            {
                entity.HasKey(e => e.ContentId);

                entity.ToTable("ContentMaster").HasData(
                    new ContentMaster { ContentId = Guid.NewGuid(), ContentHeader = "welcome to organization"},
                    new ContentMaster { ContentId = Guid.NewGuid(), ContentHeader = "Team meet up"},
                    new ContentMaster { ContentId = Guid.NewGuid(), ContentHeader = "Hardware software Access information"},
                    new ContentMaster { ContentId = Guid.NewGuid(), ContentHeader = "On-boarding training"});

                entity.Property(e => e.ContentId).ValueGeneratedNever();

                entity.Property(e => e.ContentHeader).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.HasOne(d => d.EmployeeGroup)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeGroupId)
                    .HasConstraintName("FK_Employee_EmployeeGroup");
            });

            modelBuilder.Entity<EmployeeContent>(entity =>
            {
                entity.ToTable("EmployeeContent");

                entity.Property(e => e.EmployeeContentId).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.Employeeid).HasColumnName("EmployeeIId");

                entity.HasOne(d => d.ContentGroup)
                    .WithMany(p => p.EmployeeContents)
                    .HasForeignKey(d => d.ContentGroupId)
                    .HasConstraintName("FK_EmployeeContent_ContentGroup");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeContents)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("FK_EmployeeContent_Employee");
            });

            modelBuilder.Entity<EmployeeGroup>(entity =>
            {
                entity.ToTable("EmployeeGroup").HasData(
                    new EmployeeGroup { EmployeeGroupId = Guid.NewGuid(), EmployeeGroupName = "Sales" },
                    new EmployeeGroup { EmployeeGroupId = Guid.NewGuid(), EmployeeGroupName = "Marketing" },
                    new EmployeeGroup { EmployeeGroupId = Guid.NewGuid(), EmployeeGroupName = "IT" });

                entity.Property(e => e.EmployeeGroupId).ValueGeneratedNever();

                entity.Property(e => e.EmployeeGroupName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
