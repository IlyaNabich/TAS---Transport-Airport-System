using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<RouteEntity>
{
    public void Configure(EntityTypeBuilder<RouteEntity> builder)
    {
        builder
            .HasNoKey()
            .ToView("routes", "bookings");

        builder.Property(e => e.AircraftCode)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Aircraft code, IATA")
            .HasColumnName("aircraft_code");
        builder.Property(e => e.ArrivalAirport)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Code of airport of arrival")
            .HasColumnName("arrival_airport");
        builder.Property(e => e.ArrivalAirportName)
            .HasComment("Name of airport of arrival")
            .HasColumnName("arrival_airport_name");
        builder.Property(e => e.ArrivalCity)
            .HasComment("City of arrival")
            .HasColumnName("arrival_city");
        builder.Property(e => e.DaysOfWeek)
            .HasComment("Days of week on which flights are scheduled")
            .HasColumnName("days_of_week");
        builder.Property(e => e.DepartureAirport)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasComment("Code of airport of departure")
            .HasColumnName("departure_airport");
        builder.Property(e => e.DepartureAirportName)
            .HasComment("Name of airport of departure")
            .HasColumnName("departure_airport_name");
        builder.Property(e => e.DepartureCity)
            .HasComment("City of departure")
            .HasColumnName("departure_city");
        builder.Property(e => e.Duration)
            .HasComment("Scheduled duration of flight")
            .HasColumnName("duration");
        builder.Property(e => e.FlightNo)
            .HasMaxLength(6)
            .IsFixedLength()
            .HasComment("Flight number")
            .HasColumnName("flight_no");
    }
}