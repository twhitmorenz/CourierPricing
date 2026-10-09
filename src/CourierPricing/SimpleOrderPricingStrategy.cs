namespace CourierPricing;

public record SimpleOrderPricingStrategy (IParcelPricingStrategy ItemPricing): IOrderPricingStrategy {
    
    public OrderPrice Price (Order order)
    {
        List<ItemPrice> prices = [];
        foreach (var item in order.Items)
        {
            var price = ItemPricing.Price(item);
            prices.Add(price);
        }
        return new OrderPrice(prices);
    }
    
}
