namespace ridalot2._0.Data
{
    public class Payment
    {
        const float avgFuelPrice = 1.9f;
        const float avgFuelConsumption = 7.9f;
        float fuelPriceKM {get { return (avgFuelConsumption*avgFuelPrice)/100; } }
        float baseFloorPay { get; set; } = 1.5f;
        float basePay { get; set; } = 5.0f;
        public double CalculatePay(float distance, int floor)
        {
            return Math.Round((distance*fuelPriceKM) + (floor*baseFloorPay) + basePay, 1);
        
        }
    }
}
