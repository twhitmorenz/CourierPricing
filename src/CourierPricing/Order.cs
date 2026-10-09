namespace CourierPricing;

public class Order {
    public List<Parcel> Items { get; set; } = [];

    public ShippingType Shipping { get; set; } = ShippingType.NORMAL;

    public Order (List<Parcel> Items) 
    {
        this.Items = Items;
    }

}


public enum ShippingType {NORMAL, SPEEDY};