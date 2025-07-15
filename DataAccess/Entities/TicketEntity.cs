namespace DataAccess.Entities;

/// <summary>
/// Tickets
/// </summary>
public class TicketEntity
{
    /// <summary>
    /// Ticket number
    /// </summary>
    public string TicketNo { get; set; } = null!;

    /// <summary>
    /// Booking number
    /// </summary>
    public string BookRef { get; set; } = null!;

    /// <summary>
    /// Passenger ID
    /// </summary>
    public string PassengerId { get; set; } = null!;

    /// <summary>
    /// Passenger name
    /// </summary>
    public string PassengerName { get; set; } = null!;

    /// <summary>
    /// Passenger contact information
    /// </summary>
    public string? ContactData { get; set; }

    public virtual BookingEntity BookRefNavigation { get; set; } = null!;

    public virtual ICollection<TicketFlightEntity> TicketFlights { get; set; } = new List<TicketFlightEntity>();
}
