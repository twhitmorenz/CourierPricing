namespace CourierPricing.Tests;

public static class Step1Config
{

    
    public static ParcelSizeStrategy CreateParcelSizeStrategy()
    {
        SortedList<int, decimal> priceTable = new()
        {
            { 0, 3.00m },
            { 10, 8.00m },
            { 50, 15.00m },
            { 100, 25.00m }
        };        
        return new ParcelSizeStrategy(priceTable);
    }

    public static SimpleOrderPricingStrategy CreateOrderPricingStrategy()
    {
        return new SimpleOrderPricingStrategy(CreateParcelSizeStrategy());
    }

}
