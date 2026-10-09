namespace CourierPricing;

public interface IOrderPricingStrategy {
    
    public OrderPrice Price (Order order);
    
}
