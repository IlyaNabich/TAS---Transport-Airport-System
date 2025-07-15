using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class TicketFlightConfiguration : IEntityTypeConfiguration<TicketFlightEntity>
{
    public void Configure(EntityTypeBuilder<TicketFlightEntity> builder)
    {
        builder.HasKey(e => new { e.TicketNo, e.FlightId }).HasName("ticket_flights_pkey");

        builder.ToTable("ticket_flights", "bookings", tb => tb.HasComment("Flight segment"));

        builder.Property(e => e.TicketNo)
            .HasMaxLength(13)
            .IsFixedLength()
            .HasComment("Ticket number")
            .HasColumnName("ticket_no");
        builder.Property(e => e.FlightId)
            .HasComment("Flight ID")
            .HasColumnName("flight_id");
        builder.Property(e => e.Amount)
            .HasPrecision(10, 2)
            .HasComment("Travel cost")
            .HasColumnName("amount");
        builder.Property(e => e.FareConditions)
            .HasMaxLength(10)
            .HasComment("Travel class")
            .HasColumnName("fare_conditions");

        builder.HasOne(d => d.FlightEntity).WithMany(p => p.TicketFlights)
            .HasForeignKey(d => d.FlightId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ticket_flights_flight_id_fkey");

        builder.HasOne(d => d.TicketEntityNoNavigation).WithMany(p => p.TicketFlights)
            .HasForeignKey(d => d.TicketNo)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ticket_flights_ticket_no_fkey");
    }
}