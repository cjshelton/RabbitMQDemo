using System;
namespace Producer
{
    public class Journey
    {
        private const double LITRES_PER_GALLON = 4.54;

        public Journey(
            double milesCovered,
            double milesPerGallon,
            double fuelCostPerLitre,
            string notes)
        {
            MilesCovered = milesCovered;
            MilesPerGallon = milesPerGallon;
            FuelCostPerLitre = fuelCostPerLitre;
            Notes = notes;
        }

        public Guid Id => Guid.NewGuid();

        public double MilesCovered { get; }

        public double MilesPerGallon { get; }

        public double FuelCostPerLitre { get; }

        public string Notes { get; }

        public double FuelCostPerGallon => FuelCostPerLitre * LITRES_PER_GALLON;

        public double Cost => (MilesCovered / MilesPerGallon) * FuelCostPerGallon;
    }
}
