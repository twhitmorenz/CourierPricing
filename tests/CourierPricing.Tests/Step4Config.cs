using System.Numerics;

namespace CourierPricing.Tests;

public static class Step4Config
{

    
    public static IParcelPricingStrategy CreateParcelSizeAndWeightStrategy()
    {
        return new ParcelSizeAndWeightStrategy([
            new ParcelSizeAndWeightStrategy.SizeAndWeight("Small", 0, 10, 1, 3.00m, 2.00m),
            new ParcelSizeAndWeightStrategy.SizeAndWeight("Medium", 10, 50, 3, 8.00m, 2.00m),
            new ParcelSizeAndWeightStrategy.SizeAndWeight("Large", 50, 100, 6, 15.00m, 2.00m),
            new ParcelSizeAndWeightStrategy.SizeAndWeight("XL", 100, int.MaxValue, 10, 25.00m, 2.00m),
            // Heavy Parcel;  $50 up to 50kg + $1/kg over
            new ParcelSizeAndWeightStrategy.SizeAndWeight("Heavy", 0, int.MaxValue, 50, 50.00m, 1.00m)
        ]);
    }

    public static IOrderPricingStrategy CreateOrderPricingStrategy()
    {
        return new SpeedyOrderPricingStrategy(
            new SimpleOrderPricingStrategy(CreateParcelSizeAndWeightStrategy())
        );
    }

}
