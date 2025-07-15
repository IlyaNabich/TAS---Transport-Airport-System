namespace DataAccess.Entities;

public class AircraftEntity
{
    public string? AircraftCode { get; set; }

    /// <summary>
    /// Aircraft model
    /// </summary>
    /// 
    public string? Model { get; set; }

    /// <summary>
    /// Maximal flying distance, km
    /// </summary>
    public int? Range { get; set; }
}