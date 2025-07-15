namespace Core.Models;

/// <summary>
/// Boarding passes
/// </summary>
public partial class BoardingPass
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
    /// Boarding pass number
    /// </summary>
    public int BoardingNo { get; }

    /// <summary>
    /// Seat number
    /// </summary>
    public string SeatNo { get; } = null!;

    public virtual TicketFlight TicketFlight { get; } = null!;
}
