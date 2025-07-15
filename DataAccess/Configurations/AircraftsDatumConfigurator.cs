using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class AircraftsDatumConfigurator : IEntityTypeConfiguration<AircraftsDatumEntity>
{
    public void Configure(EntityTypeBuilder<AircraftsDatumEntity> builder)
    {
        builder.HasKey(e => e.AircraftCode).HasName("aircrafts_pkey");

        builder.ToTable("aircrafts_data", "bookings", tb => tb.HasComment("Aircrafts (internal data)"));

        builder.Property(e => e.AircraftCode)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Aircraft code, IATA")
            .HasColumnName("aircraft_code");
        builder.Property(e => e.Model)
            .HasComment("Aircraft model")
            .HasColumnType("jsonb")
            .HasColumnName("model");
        builder.Property(e => e.Range)
            .HasComment("Maximal flying distance, km")
            .HasColumnName("range");
    }
}