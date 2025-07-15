using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public partial class DbContext(DbContextOptions<DbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    private partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
    }
    public virtual DbSet<AircraftEntity> Aircrafts { get; set; }

    public virtual DbSet<AircraftsDatumEntity> AircraftsData { get; set; }

    public virtual DbSet<AirportEntity> Airports { get; set; }

    public virtual DbSet<AirportsDatumEntity> AirportsData { get; set; }

    public virtual DbSet<BoardingPassEntity> BoardingPasses { get; set; }

    public virtual DbSet<BookingEntity> Bookings { get; set; }

    public virtual DbSet<FlightEntity> Flights { get; set; }

    public virtual DbSet<FlightsVEntity> FlightsVs { get; set; }

    public virtual DbSet<RouteEntity> Routes { get; set; }

    public virtual DbSet<SeatEntity> Seats { get; set; }

    public virtual DbSet<TicketEntity> Tickets { get; set; }

    public virtual DbSet<TicketFlightEntity> TicketFlights { get; set; }


}
