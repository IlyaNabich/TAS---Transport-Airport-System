using NpgsqlTypes;

namespace Core.Models;

public partial class Airport
{
    /// <summary>
    /// Airport code
    /// </summary>
    public string? AirportCode { get; }

    /// <summary>
    /// Airport name
    /// </summary>
    public string? AirportName { get; }

    /// <summary>
    /// City
    /// </summary>
    public string? City { get; }

    /// <summary>
    /// Airport coordinates (longitude and latitude)
    /// </summary>
    public NpgsqlPoint? Coordinates { get; }

    /// <summary>
    /// Airport time zone
    /// </summary>
    public string? Timezone { get; }
}
