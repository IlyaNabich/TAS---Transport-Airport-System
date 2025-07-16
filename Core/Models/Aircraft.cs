namespace Core.Models;

public class Aircraft
{
    
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string? AircraftCode { get; }

    /// <summary>
    /// Aircraft model
    /// </summary>
    /// 
    public string? Model { get; }

    /// <summary>
    /// Maximal flying distance, km
    /// </summary>
    public int? Range { get; }
    
}
