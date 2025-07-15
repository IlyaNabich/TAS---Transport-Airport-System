using NpgsqlTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Airports (internal data)
/// </summary>
public class AirportsDatumEntity
{
    /// <summary>
    /// Airport code
    /// </summary>
    public string AirportCode { get; set; } = null!;

    /// <summary>
    /// Airport name
    /// </summary>
    public string AirportName { get; set; } = null!;

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// Airport coordinates (longitude and latitude)
    /// </summary>
    public NpgsqlPoint Coordinates { get; set; }

    /// <summary>
    /// Airport time zone
    /// </summary>
    public string Timezone { get; set; } = null!;
    
    // [ForeignKey(nameof(FlightEntity.ArrivalAirport))] 
    public virtual ICollection<FlightEntity> FlightArrivalAirportNavigations { get; set; } = new List<FlightEntity>();
    // [ForeignKey(nameof(FlightEntity.DepartureAirport))]
    public virtual ICollection<FlightEntity> FlightDepartureAirportNavigations { get; set; } = new List<FlightEntity>();
}
