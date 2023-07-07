namespace UC14.WebApp.Models
{
    public class UnitsService : IUnitsService
    {
        public IMeasurementUnitsSet GetUnitsSet(bool isMetric)
        {
            return isMetric ? new MetricMeasurementUnitsSet() : new NonMetricMeasurementUnitsSet();
        }
    }
}
