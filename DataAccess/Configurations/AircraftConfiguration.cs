using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class AircraftConfiguration : IEntityTypeConfiguration<AircraftEntity>
{
    public void Configure(EntityTypeBuilder<AircraftEntity> builder)
    {
        builder
            .HasNoKey()
            .ToView("aircrafts", "bookings");

        builder.Property(e => e.AircraftCode)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Aircraft code, IATA")
            .HasColumnName("aircraft_code");
        builder.Property(e => e.Model)
            .HasComment("Aircraft model")
            .HasColumnName("model");
        builder.Property(e => e.Range)
            .HasComment("Maximal flying distance, km")
            .HasColumnName("range");
    }
}