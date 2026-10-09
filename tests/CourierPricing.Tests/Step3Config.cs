using System.Numerics;

namespace CourierPricing.Tests;

public static class Step3Config
{

    
    public static IParcelPricingStrategy CreateParcelSizeAndWeightStrategy()
    {
        return new ParcelSizeAndWeightStrategy([
            new ParcelSizeAndWeightStrategy.SizeAndWeight(0, 10, 1, 3.00m),
            new ParcelSizeAndWeightStrategy.SizeAndWeight(10, 50, 3, 8.00m),
            new ParcelSizeAndWeightStrategy.SizeAndWeight(50, 100, 6, 15.00m),
            new ParcelSizeAndWeightStrategy.SizeAndWeight(100, int.MaxValue, 10, 25.00m)
        ], 2.00m);
    }

    public static IOrderPricingStrategy CreateOrderPricingStrategy()
    {
        return new SpeedyOrderPricingStrategy(
            new SimpleOrderPricingStrategy(CreateParcelSizeAndWeightStrategy())
        );
    }

}
