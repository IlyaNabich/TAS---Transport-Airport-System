using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<FlightEntity>
{
    public void Configure(EntityTypeBuilder<FlightEntity> builder)
    {
        builder.HasKey(e => e.FlightId).HasName("flights_pkey");

            builder.ToTable("flights", "bookings", tb => tb.HasComment("Flights"));

            builder.HasIndex(e => new { e.FlightNo, e.ScheduledDeparture }, "flights_flight_no_scheduled_departure_key").IsUnique();

            builder.Property(e => e.FlightId)
                .HasDefaultValueSql("nextval('flights_flight_id_seq'::regclass)")
                .HasComment("Flight ID")
                .HasColumnName("flight_id");
            builder.Property(e => e.ActualArrival)
                .HasComment("Actual arrival time")
                .HasColumnName("actual_arrival");
            builder.Property(e => e.ActualDeparture)
                .HasComment("Actual departure time")
                .HasColumnName("actual_departure");
            builder.Property(e => e.AircraftCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Aircraft code, IATA")
                .HasColumnName("aircraft_code");
            builder.Property(e => e.ArrivalAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Airport of arrival")
                .HasColumnName("arrival_airport");
            builder.Property(e => e.DepartureAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Airport of departure")
                .HasColumnName("departure_airport");
            builder.Property(e => e.FlightNo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Flight number")
                .HasColumnName("flight_no");
            builder.Property(e => e.ScheduledArrival)
                .HasComment("Scheduled arrival time")
                .HasColumnName("scheduled_arrival");
            builder.Property(e => e.ScheduledDeparture)
                .HasComment("Scheduled departure time")
                .HasColumnName("scheduled_departure");
            builder.Property(e => e.Status)
                .HasMaxLength(20)
                .HasComment("Flight status")
                .HasColumnName("status");

            builder.HasOne(d => d.AircraftCodeNavigation).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AircraftCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flights_aircraft_code_fkey");

            builder.HasOne(d => d.ArrivalAirportNavigation).WithMany(p => p.FlightArrivalAirportNavigations)
                .HasForeignKey(d => d.ArrivalAirport)
                .HasPrincipalKey(a => a.AirportCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flights_arrival_airport_fkey");

            builder.HasOne(d => d.DepartureAirportNavigation).WithMany(p => p.FlightDepartureAirportNavigations)
                .HasForeignKey(d => d.DepartureAirport)
                .HasPrincipalKey(a => a.AirportCode)    
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flights_departure_airport_fkey");
    }
}