namespace CourierPricing;

public interface IParcelPricingStrategy {
    
    public ItemPrice Price (Parcel parcel);
    
}
