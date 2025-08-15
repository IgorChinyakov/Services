using Domain.Constants;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("positions");

            builder.HasKey(p => p.Id).HasName("pk_positions");

            builder.Property(vr => vr.Id).HasConversion(
                positionId => positionId.Value,
                stringId => PositionId.Create(stringId))
                .HasColumnName("position_id");

            builder.OwnsOne(p => p.Description, db =>
            {
                db.Property(p => p.Value)
                    .HasColumnName("description")
                    .IsRequired(false);
            });

            builder.ComplexProperty(p => p.IsActive, ib =>
            {
                ib.Property(i => i.Value)
                    .HasColumnName("is_active")
                    .IsRequired();
            });

            builder.ComplexProperty(p => p.CreatedAt, cb =>
            {
                cb.Property(i => i.Value)
                    .HasColumnName("created_at")
                    .IsRequired();
            });

            builder.ComplexProperty(p => p.UpdatedAt, ub =>
            {
                ub.Property(i => i.Value)
                    .HasColumnName("updated_at")
                    .IsRequired();
            });

            builder.ComplexProperty(p => p.Name, nb =>
            {
                nb.Property(i => i.Value)
                    .HasMaxLength(PositionConstants.NAME_MAX_LENGTH)
                    .HasColumnName("name")
                    .IsRequired();
            });
        }
    }
}
