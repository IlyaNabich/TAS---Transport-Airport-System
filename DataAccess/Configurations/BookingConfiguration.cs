using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.HasKey(e => e.BookRef).HasName("bookings_pkey");

        builder.ToTable("bookings", "bookings", tb => tb.HasComment("Bookings"));

        builder.Property(e => e.BookRef)
            .HasMaxLength(6)
            .IsFixedLength()
            .HasComment("Booking number")
            .HasColumnName("book_ref");
        builder.Property(e => e.BookDate)
            .HasComment("Booking date")
            .HasColumnName("book_date");
        builder.Property(e => e.TotalAmount)
            .HasPrecision(10, 2)
            .HasComment("Total booking cost")
            .HasColumnName("total_amount");
    }
}