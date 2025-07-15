namespace Core.Models;

/// <summary>
/// Bookings
/// </summary>
public partial class Booking
{
    /// <summary>
    /// Booking number
    /// </summary>
    public string BookRef { get; } = null!;

    /// <summary>
    /// Booking date
    /// </summary>
    public DateTime BookDate { get;  }

    /// <summary>
    /// Total booking cost
    /// </summary>
    public decimal TotalAmount { get;  }

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
