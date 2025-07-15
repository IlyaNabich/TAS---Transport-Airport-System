namespace DataAccess.Entities;

/// <summary>
/// Flight segment
/// </summary>
public class TicketFlightEntity
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
    /// Travel class
    /// </summary>
    public string FareConditions { get; set; } = null!;

    /// <summary>
    /// Travel cost
    /// </summary>
    public decimal Amount { get; set; }

    public virtual BoardingPassEntity? BoardingPass { get; set; }

    public virtual FlightEntity FlightEntity { get; set; } = null!;

    public virtual TicketEntity TicketEntityNoNavigation { get; set; } = null!;
}
