using Domain.Constants;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");

            builder.HasKey(d => d.Id).HasName("pk_departments");

            builder.Property(vr => vr.Id).HasConversion(
                departmentId => departmentId.Value,
                stringId => DepartmentId.Create(stringId))
                .HasColumnName("department_id");

            builder.ComplexProperty(d => d.IsActive, ib =>
            {
                ib.Property(i => i.Value)
                    .HasColumnName("is_active")
                    .IsRequired();
            });

            builder.ComplexProperty(d => d.Identifier, ib =>
            {
                ib.Property(i => i.Value)
                    .HasMaxLength(DepartmentConstants.IDENTIFIER_MAX_LENGTH)
                    .HasColumnName("identifier")
                    .IsRequired();
            });

            builder.ComplexProperty(d => d.CreatedAt, cb =>
            {
                cb.Property(i => i.Value)
                    .HasColumnName("created_at")
                    .IsRequired();
            });

            builder.ComplexProperty(d => d.UpdatedAt, ub =>
            {
                ub.Property(i => i.Value)
                    .HasColumnName("updated_at")
                    .IsRequired();
            });

            builder.ComplexProperty(d => d.Name, nb =>
            {
                nb.Property(i => i.Value)
                    .HasMaxLength(DepartmentConstants.NAME_MAX_LENGTH)
                    .HasColumnName("name")
                    .IsRequired();
            });

            builder.HasOne(d => d.Parent)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("fr_departments_parent")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(vr => vr.ParentId).HasConversion(
                parentId => parentId == null ? (Guid?)null : parentId.Value,
                stringId => stringId == null ? null : DepartmentId.Create(stringId.Value))
                .HasColumnName("parent_id");

            builder.HasMany(d => d.Locations)
                 .WithMany(l => l.Departments)
                 .UsingEntity(
                    "department_location",
                    r => r
                    .HasOne(typeof(Location))
                    .WithMany()
                    .HasForeignKey("location_id")
                    .HasConstraintName("fk_department_location_location_id")
                    .OnDelete(DeleteBehavior.Restrict),
                    l => l
                    .HasOne(typeof(Department))
                    .WithMany()
                    .HasForeignKey("department_id")
                    .HasConstraintName("fk_department_location_department_id")
                    .OnDelete(DeleteBehavior.Restrict),
                    table => table.HasKey("department_id", "location_id")
                            .HasName("pk_department_location"));

            builder.HasMany(d => d.Positions)
                 .WithMany(p => p.Departments)
                 .UsingEntity(
                    "department_position",
                    r => r.HasOne(typeof(Position))
                    .WithMany()
                    .HasForeignKey("position_id")
                    .HasConstraintName("fk_department_location_position_id")
                    .OnDelete(DeleteBehavior.Restrict),
                    l => l.HasOne(typeof(Department))
                    .WithMany()
                    .HasForeignKey("department_id")
                    .HasConstraintName("fk_department_location_department_id")
                    .OnDelete(DeleteBehavior.Restrict),
                    table => table.HasKey("department_id", "position_id")
                            .HasName("pk_department_position"));
        }
    }
}
