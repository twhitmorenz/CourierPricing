namespace CourierPricing;

public class Order {
    public List<Parcel> Items { get; set; } = [];


    public Order (List<Parcel> Items) 
    {
        this.Items = Items;
    }

}