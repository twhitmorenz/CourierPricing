namespace CourierPricing;

public record struct ItemPrice(Parcel? Parcel, string Title, string Type, decimal Price) 
{
    public ItemPrice(Parcel Parcel, string Type, decimal Price) : this(Parcel, Parcel.Desc, Type, Price)
    {        
    }
    public ItemPrice(string Title, string Type, decimal Price) : this(null, Title, Type, Price)
    {        
    }


}
