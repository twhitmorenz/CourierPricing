using System.Numerics;

namespace CourierPricing.Tests;

public static class Step3Config
{

    
    public static IParcelPricingStrategy CreateParcelSizeAndWeightStrategy()
    {
        var overagePerKg = 2.00m;
        return new ParcelSizeAndWeightStrategy([
            new ParcelSizeAndWeightStrategy.SizeAndWeight("Small", 0, 10, 1, 3.00m, overagePerKg),
            new ParcelSizeAndWeightStrategy.SizeAndWeight("Medium", 10, 50, 3, 8.00m, overagePerKg),
            new ParcelSizeAndWeightStrategy.SizeAndWeight("Large", 50, 100, 6, 15.00m, overagePerKg),
            new ParcelSizeAndWeightStrategy.SizeAndWeight("XL", 100, int.MaxValue, 10, 25.00m, overagePerKg)
        ]);
    }

    public static IOrderPricingStrategy CreateOrderPricingStrategy()
    {
        return new SpeedyOrderPricingStrategy(
            new SimpleOrderPricingStrategy(CreateParcelSizeAndWeightStrategy())
        );
    }

}
