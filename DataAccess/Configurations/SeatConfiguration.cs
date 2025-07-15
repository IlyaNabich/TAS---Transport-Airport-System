using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<SeatEntity>
{
    public void Configure(EntityTypeBuilder<SeatEntity> builder)
    {
        builder.HasKey(e => new { e.AircraftCode, e.SeatNo }).HasName("seats_pkey");

        builder.ToTable("seats", "bookings", tb => tb.HasComment("Seats"));

        builder.Property(e => e.AircraftCode)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Aircraft code, IATA")
            .HasColumnName("aircraft_code");
        builder.Property(e => e.SeatNo)
            .HasMaxLength(4)
            .HasComment("Seat number")
            .HasColumnName("seat_no");
        builder.Property(e => e.FareConditions)
            .HasMaxLength(10)
            .HasComment("Travel class")
            .HasColumnName("fare_conditions");

        builder.HasOne(d => d.AircraftCodeNavigation).WithMany(p => p.Seats)
            .HasForeignKey(d => d.AircraftCode)
            .HasConstraintName("seats_aircraft_code_fkey");
    }
}