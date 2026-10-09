namespace CourierPricing;

public record struct OrderPrice(List<ItemPrice> Items) 
{

    public decimal Total => Items.Sum(e => e.Price);

}
