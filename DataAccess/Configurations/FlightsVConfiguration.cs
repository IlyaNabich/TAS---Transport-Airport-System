using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class FlightsVConfiguration : IEntityTypeConfiguration<FlightsVEntity>
{
    public void Configure(EntityTypeBuilder<FlightsVEntity> builder)
    {
            builder
                .HasNoKey()
                .ToView("flights_v", "bookings");

            builder.Property(e => e.ActualArrival)
                .HasComment("Actual arrival time")
                .HasColumnName("actual_arrival");
            builder.Property(e => e.ActualArrivalLocal)
                .HasComment("Actual arrival time, local time at the point of destination")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actual_arrival_local");
            builder.Property(e => e.ActualDeparture)
                .HasComment("Actual departure time")
                .HasColumnName("actual_departure");
            builder.Property(e => e.ActualDepartureLocal)
                .HasComment("Actual departure time, local time at the point of departure")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actual_departure_local");
            builder.Property(e => e.ActualDuration)
                .HasComment("Actual flight duration")
                .HasColumnName("actual_duration");
            builder.Property(e => e.AircraftCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Aircraft code, IATA")
                .HasColumnName("aircraft_code");
            builder.Property(e => e.ArrivalAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Arrival airport code")
                .HasColumnName("arrival_airport");
            builder.Property(e => e.ArrivalAirportName)
                .HasComment("Arrival airport name")
                .HasColumnName("arrival_airport_name");
            builder.Property(e => e.ArrivalCity)
                .HasComment("City of arrival")
                .HasColumnName("arrival_city");
            builder.Property(e => e.DepartureAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Deprature airport code")
                .HasColumnName("departure_airport");
            builder.Property(e => e.DepartureAirportName)
                .HasComment("Departure airport name")
                .HasColumnName("departure_airport_name");
            builder.Property(e => e.DepartureCity)
                .HasComment("City of departure")
                .HasColumnName("departure_city");
            builder.Property(e => e.FlightId)
                .HasComment("Flight ID")
                .HasColumnName("flight_id");
            builder.Property(e => e.FlightNo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Flight number")
                .HasColumnName("flight_no");
            builder.Property(e => e.ScheduledArrival)
                .HasComment("Scheduled arrival time")
                .HasColumnName("scheduled_arrival");
            builder.Property(e => e.ScheduledArrivalLocal)
                .HasComment("Scheduled arrival time, local time at the point of destination")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_arrival_local");
            builder.Property(e => e.ScheduledDeparture)
                .HasComment("Scheduled departure time")
                .HasColumnName("scheduled_departure");
            builder.Property(e => e.ScheduledDepartureLocal)
                .HasComment("Scheduled departure time, local time at the point of departure")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_departure_local");
            builder.Property(e => e.ScheduledDuration)
                .HasComment("Scheduled flight duration")
                .HasColumnName("scheduled_duration");
            builder.Property(e => e.Status)
                .HasMaxLength(20)
                .HasComment("Flight status")
                .HasColumnName("status");
    }
}