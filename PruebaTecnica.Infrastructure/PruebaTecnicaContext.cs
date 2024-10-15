using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Infrastructure;

public partial class PruebaTecnicaContext : DbContext
{
    public PruebaTecnicaContext()
    {
    }

    public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDepartment> Departments { get; set; }

    public virtual DbSet<TblEmployee> Employees { get; set; }

    public virtual DbSet<TblPositionHistory> PositionHistories { get; set; }

    public virtual DbSet<TblProject> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.DepartmentId, "departmentId");

            entity.HasIndex(e => e.ProjectId, "projectId");

            entity.Property(e => e.DocumentId)
                .ValueGeneratedNever()
                .HasColumnName("documentId");
            entity.Property(e => e.CurrentPosition)
                .HasMaxLength(50)
                .HasColumnName("currentPosition");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.Salary)
                .HasPrecision(10)
                .HasColumnName("salary");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_ibfk_2");

            entity.HasOne(d => d.Project).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("employees_ibfk_1");
        });

        modelBuilder.Entity<TblPositionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("positionHistory");

            entity.HasIndex(e => e.DocumentId, "documentId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DocumentId).HasColumnName("documentId");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
        });

        modelBuilder.Entity<TblProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("projects");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
