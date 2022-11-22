namespace ridalot2._0.Data
{
    public static class Payment
    {
        const float avgFuelPrice = 1.9f;
        const float avgFuelConsumption = 7.9f;
        const float baseFloorPay = 1.5f;
        const float basePay = 5.0f;
        static float fuelPriceKM { get { return (avgFuelConsumption * avgFuelPrice) / 100; } }
        static public double CalculatePay(float distance, int floor)
        {
            floor = Math.Abs(floor);
            return Math.Round((distance * fuelPriceKM) + (floor * baseFloorPay) + basePay, 1);
        }
    }
}
