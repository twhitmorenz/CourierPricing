namespace CourierPricing;

public record SpeedyOrderPricingStrategy (IOrderPricingStrategy Delegate): IOrderPricingStrategy {
    
    public OrderPrice Price (Order order)
    {
        var basePrice = Delegate.Price(order);
        var optionalExtra = CalculateExtraCost(order, basePrice);
        if (optionalExtra is ItemPrice definiteExtra)
        {
            List<ItemPrice> newPrices = [..basePrice.Items, definiteExtra];
            return new OrderPrice(newPrices);
        }
        return basePrice;
    }

    protected ItemPrice? CalculateExtraCost (Order order, OrderPrice basePrice)
    {
        if (order.Shipping == ShippingType.SPEEDY)
        {
            // Extra 100%;  gives double
            return new ItemPrice("Speedy Shipping", "Shipping", basePrice.Total);            
        }
        return null;
    }
    
}
