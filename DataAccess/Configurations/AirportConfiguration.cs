using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class AirportConfiguration : IEntityTypeConfiguration<AirportEntity>
{
    public void Configure(EntityTypeBuilder<AirportEntity> builder)
    {
        builder
            .HasNoKey()
            .ToView("airports", "bookings");

        builder.Property(e => e.AirportCode)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Airport code")
            .HasColumnName("airport_code");
        builder.Property(e => e.AirportName)
            .HasComment("Airport name")
            .HasColumnName("airport_name");
        builder.Property(e => e.City)
            .HasComment("City")
            .HasColumnName("city");
        builder.Property(e => e.Coordinates)
            .HasComment("Airport coordinates (longitude and latitude)")
            .HasColumnName("coordinates");
        builder.Property(e => e.Timezone)
            .HasComment("Airport time zone")
            .HasColumnName("timezone");
    }
}