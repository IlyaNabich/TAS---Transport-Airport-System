using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class AirportsDatumConfiguration : IEntityTypeConfiguration<AirportsDatumEntity>
{
    public void Configure(EntityTypeBuilder<AirportsDatumEntity> builder)
    {
        builder.HasKey(e => e.AirportCode).HasName("airports_data_pkey");

        builder.ToTable("airports_data", "bookings", tb => tb.HasComment("Airports (internal data)"));

        builder.Property(e => e.AirportCode)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Airport code")
            .HasColumnName("airport_code");
        builder.Property(e => e.AirportName)
            .HasComment("Airport name")
            .HasColumnType("jsonb")
            .HasColumnName("airport_name");
        builder.Property(e => e.City)
            .HasComment("City")
            .HasColumnType("jsonb")
            .HasColumnName("city");
        builder.Property(e => e.Coordinates)
            .HasComment("Airport coordinates (longitude and latitude)")
            .HasColumnName("coordinates");
        builder.Property(e => e.Timezone)
            .HasComment("Airport time zone")
            .HasColumnName("timezone");
    }
}