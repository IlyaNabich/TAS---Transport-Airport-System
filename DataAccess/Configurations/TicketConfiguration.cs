using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
{
    public void Configure(EntityTypeBuilder<TicketEntity> builder)
    {
        builder.HasKey(e => e.TicketNo).HasName("tickets_pkey");

        builder.ToTable("tickets", "bookings", tb => tb.HasComment("Tickets"));

        builder.Property(e => e.TicketNo)
            .HasMaxLength(13)
            .IsFixedLength()
            .HasComment("Ticket number")
            .HasColumnName("ticket_no");
        builder.Property(e => e.BookRef)
            .HasMaxLength(6)
            .IsFixedLength()
            .HasComment("Booking number")
            .HasColumnName("book_ref");
        builder.Property(e => e.ContactData)
            .HasComment("Passenger contact information")
            .HasColumnType("jsonb")
            .HasColumnName("contact_data");
        builder.Property(e => e.PassengerId)
            .HasMaxLength(20)
            .HasComment("Passenger ID")
            .HasColumnName("passenger_id");
        builder.Property(e => e.PassengerName)
            .HasComment("Passenger name")
            .HasColumnName("passenger_name");

        builder.HasOne(d => d.BookRefNavigation).WithMany(p => p.Tickets)
            .HasForeignKey(d => d.BookRef)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tickets_book_ref_fkey");
    }
}