using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace dbtoc.Entity
{
    public partial class OrganizationContext : DbContext
    {
        public OrganizationContext()
        {
        }

        public OrganizationContext(DbContextOptions<OrganizationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Workers1> Workers1s { get; set; }
        public virtual DbSet<Workers2> Workers2s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AAAG9IA\\MSSQLSERVER01;Database=Organization;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__departme__DCA65974C27DDF02");

                entity.ToTable("department");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.Dateofjoining)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dateofjoining");

                entity.Property(e => e.Depart)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("depart");

                entity.Property(e => e.Nameofemployee)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("place");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("UserLogin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("workers");

                entity.Property(e => e.Dateofjoining)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dateofjoining");

                entity.Property(e => e.Depart)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("depart");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("dept_id");

                entity.Property(e => e.Nameofemployee)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Workers1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("workers1");

                entity.Property(e => e.Dateofjoining)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dateofjoining");

                entity.Property(e => e.Depart)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("depart");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("dept_id");

                entity.Property(e => e.Nameofemployee)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Workers2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("workers2");

                entity.Property(e => e.Depart)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("depart");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
