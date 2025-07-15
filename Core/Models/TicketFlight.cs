namespace Core.Models;

/// <summary>
/// Flight segment
/// </summary>
public partial class TicketFlight
{
    /// <summary>
    /// Ticket number
    /// </summary>
    public string TicketNo { get; } = null!;

    /// <summary>
    /// Flight ID
    /// </summary>
    public int FlightId { get; }

    /// <summary>
    /// Travel class
    /// </summary>
    public string FareConditions { get; } = null!;

    /// <summary>
    /// Travel cost
    /// </summary>
    public decimal Amount { get; }

    public virtual BoardingPass? BoardingPass { get; }

    public virtual Flight Flight { get; } = null!;

    public virtual Ticket TicketNoNavigation { get; } = null!;
}
