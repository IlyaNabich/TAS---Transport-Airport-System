namespace DataAccess.Entities;

/// <summary>
/// Boarding passes
/// </summary>
public class BoardingPassEntity
{
    /// <summary>
    /// Ticket number
    /// </summary>
    public string TicketNo { get; set; } = null!;

    /// <summary>
    /// Flight ID
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Boarding pass number
    /// </summary>
    public int BoardingNo { get; set; }

    /// <summary>
    /// Seat number
    /// </summary>
    public string SeatNo { get; set; } = null!;

    public TicketFlightEntity TicketFlightEntity { get; set; } = null!;
}
