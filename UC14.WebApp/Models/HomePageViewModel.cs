namespace UC14.WebApp.Models
{
    public class HomePageViewModel
    {
        public List<DateTime> Dates { get; set; } = new List<DateTime>();
        public List<double> Numbers { get; set; } = new List<double>();
        public double Distance { get; internal set; }
        public double Weight { get; internal set; }
        public double Volume { get; internal set; }
        public IMeasurementUnitsSet? MeasurementUnitsSet { get; internal set; }
    }
}