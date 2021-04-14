using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataDBpubs.Models;

#nullable disable

namespace DataDBpubs.Context
{
    public partial class PubsContext : DbContext
    {
        public PubsContext()
        {
        }

        public PubsContext(DbContextOptions<PubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=pubs;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Czech_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_emp_id")
                    .IsClustered(false);

                entity.ToTable("employee");

                entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit }, "employee_ind")
                    .IsClustered();

                entity.Property(e => e.EmpId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("emp_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.HireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("hire_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JobLvl)
                    .HasColumnName("job_lvl")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Minit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("minit")
                    .IsFixedLength(true);

                entity.Property(e => e.PubId)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .HasDefaultValueSql("('9952')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__job_id__47DBAE45");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__pub_id__4AB81AF0");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_desc")
                    .HasDefaultValueSql("('New Position - title not formalized yet')");

                entity.Property(e => e.MaxLvl).HasColumnName("max_lvl");

                entity.Property(e => e.MinLvl).HasColumnName("min_lvl");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.PubName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("pub_name");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
