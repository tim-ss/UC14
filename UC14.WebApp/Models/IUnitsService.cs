namespace UC14.WebApp.Models
{
    public interface IUnitsService
    {
        IMeasurementUnitsSet GetUnitsSet(bool isMetric);
    }
}
