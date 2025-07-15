namespace DataAccess.Entities;

/// <summary>
/// Seats
/// </summary>
public class SeatEntity
{
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; set; } = null!;

    /// <summary>
    /// Seat number
    /// </summary>
    public string SeatNo { get; set; } = null!;

    /// <summary>
    /// Travel class
    /// </summary>
    public string FareConditions { get; set; } = null!;

    public virtual AircraftsDatumEntity AircraftCodeNavigation { get; set; } = null!;
}
