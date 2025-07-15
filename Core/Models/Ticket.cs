namespace Core.Models;

/// <summary>
/// Tickets
/// </summary>
public partial class Ticket
{
    /// <summary>
    /// Ticket number
    /// </summary>
    public string TicketNo { get; } = null!;

    /// <summary>
    /// Booking number
    /// </summary>
    public string BookRef { get; } = null!;

    /// <summary>
    /// Passenger ID
    /// </summary>
    public string PassengerId { get; } = null!;

    /// <summary>
    /// Passenger name
    /// </summary>
    public string PassengerName { get; } = null!;

    /// <summary>
    /// Passenger contact information
    /// </summary>
    public string? ContactData { get; }

    public virtual Booking BookRefNavigation { get; } = null!;

    public virtual ICollection<TicketFlight> TicketFlights { get; } = new List<TicketFlight>();
}
