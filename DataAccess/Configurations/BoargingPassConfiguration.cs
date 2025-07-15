using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BoardingPassConfiguration : IEntityTypeConfiguration<BoardingPassEntity>
{
    public void Configure(EntityTypeBuilder<BoardingPassEntity> builder)
    {
        builder.HasKey(e => new { e.TicketNo, e.FlightId }).HasName("boarding_passes_pkey");

        builder.ToTable("boarding_passes", "bookings", tb => tb.HasComment("Boarding passes"));

        builder.HasIndex(e => new { e.FlightId, e.BoardingNo }, "boarding_passes_flight_id_boarding_no_key").IsUnique();

        builder.HasIndex(e => new { e.FlightId, e.SeatNo }, "boarding_passes_flight_id_seat_no_key").IsUnique();

        builder.Property(e => e.TicketNo)
            .HasMaxLength(13)
            .IsFixedLength()
            .HasComment("Ticket number")
            .HasColumnName("ticket_no");
        builder.Property(e => e.FlightId)
            .HasComment("Flight ID")
            .HasColumnName("flight_id");
        builder.Property(e => e.BoardingNo)
            .HasComment("Boarding pass number")
            .HasColumnName("boarding_no");
        builder.Property(e => e.SeatNo)
            .HasMaxLength(4)
            .HasComment("Seat number")
            .HasColumnName("seat_no");

        builder.HasOne(d => d.TicketFlightEntity).WithOne(p => p.BoardingPass)
            .HasForeignKey<BoardingPassEntity>(d => new { d.TicketNo, d.FlightId })
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("boarding_passes_ticket_no_fkey");
    }
}