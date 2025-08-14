using Domain.Constants;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");

            builder.HasKey(l => l.Id).HasName("pk_locations");

            builder.Property(vr => vr.Id).HasConversion(
                locationId => locationId.Value,
                stringId => LocationId.Create(stringId))
                .HasColumnName("location_id");

            builder.ComplexProperty(l => l.IsActive, ib =>
            {
                ib.Property(i => i.Value)
                    .HasColumnName("is_active")
                    .IsRequired();
            });

            builder.ComplexProperty(l => l.Address, ab =>
            {
                ab.Property(a => a.Country)
                    .HasColumnName("country")
                    .IsRequired();

                ab.Property(a => a.City)
                    .HasColumnName("city")
                    .IsRequired();

                ab.Property(a => a.Street)
                    .HasColumnName("street")
                    .IsRequired();

                ab.Property(a => a.Apartment)
                    .HasColumnName("apartment")
                    .IsRequired();
            });

            builder.ComplexProperty(l => l.TimeZone, tb =>
            {
                tb.Property(t => t.Value)
                    .HasColumnName("timezone")
                    .IsRequired();
            });

            builder.ComplexProperty(l => l.CreatedAt, cb =>
            {
                cb.Property(i => i.Value)
                    .HasColumnName("created_at")
                    .IsRequired();
            });

            builder.ComplexProperty(l => l.UpdatedAt, ub =>
            {
                ub.Property(i => i.Value)
                    .HasColumnName("updated_at")
                    .IsRequired();
            });

            builder.ComplexProperty(l => l.Name, nb =>
            {
                nb.Property(i => i.Value)
                    .HasMaxLength(LocationConstants.NAME_MAX_LENGTH)
                    .HasColumnName("name")
                    .IsRequired();
            });
        }
    }
}
