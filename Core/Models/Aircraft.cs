namespace Core.Models;

public class Aircraft
{
    // ReSharper disable once InconsistentNaming
    private const int MAX_AIRCRAFT_CODE_LENGTH = 3;
    // ReSharper disable once InconsistentNaming
    private const int MAX_MODEL_LENGTH = 40;
    // ReSharper disable once InconsistentNaming
    private const int MAX_RANGE = 20000;
    private Aircraft(string? aircraftCode, string? model, int? range)
    {
        AircraftCode = aircraftCode;
        Model = model;
        Range = range;
    }
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

    public static (Aircraft aircraft, string Error) CreateAircraft(string? aircraftCode, string? model, int? range)
    {
        var error = string.Empty;

        if (string.IsNullOrWhiteSpace(aircraftCode) || aircraftCode.Length > MAX_AIRCRAFT_CODE_LENGTH)
        {
            error = "Aircraft code can not be empty or less than 3 characters.";
        }

        if (string.IsNullOrWhiteSpace(model) || model.Length > MAX_MODEL_LENGTH)
        {
            error = "Model can not be empty or less than 40 characters.";
        }

        if (int.IsNegative((int)range!) || range > MAX_RANGE)
        {
            error = "Range cannot be negative or greater than 20000 kilometers.";
        }
        var aircraft = new Aircraft(aircraftCode, model, range);
        return (aircraft, error);
    }
}
