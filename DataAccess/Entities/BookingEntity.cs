namespace DataAccess.Entities;

/// <summary>
/// Bookings
/// </summary>
public class BookingEntity
{
    /// <summary>
    /// Booking number
    /// </summary>
    public string BookRef { get; set; } = null!;

    /// <summary>
    /// Booking date
    /// </summary>
    public DateTime BookDate { get; set; }

    /// <summary>
    /// Total booking cost
    /// </summary>
    public decimal TotalAmount { get; set; }

    public virtual ICollection<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
}
