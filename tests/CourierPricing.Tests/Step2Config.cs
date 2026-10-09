namespace CourierPricing.Tests;

public static class Step2Config
{

    
    public static ParcelSizeStrategy CreateParcelSizeStrategy()
    {
        return Step1Config.CreateParcelSizeStrategy();
    }

    public static SpeedyOrderPricingStrategy CreateOrderPricingStrategy()
    {
        return new SpeedyOrderPricingStrategy(Step1Config.CreateOrderPricingStrategy());
    }

}
