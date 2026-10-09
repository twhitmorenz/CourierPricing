namespace CourierPricing;


/// <summary>
/// Prices parcels by largest dimension, against a 'Price by Size' table.
/// 
/// config: SortedList<int, decimal> of (Threshold Size, Price)
/// note that 'Threshold Size' is not the limit; it's the smallest size where this option applies, ie. the limit of the lower band.
/// 
/// </summary>
/// <param name="PriceBySize">SortedList of (threshold size, price) where price applies for size >= threshold.</param>

public record ParcelSizeStrategy (SortedList<int, decimal> PriceBySize): IParcelPricingStrategy {
    
    public ItemPrice Price (Parcel parcel)
    {
        var i = FloorIndex(parcel.LargestSize, PriceBySize);
        var floor = PriceBySize.GetKeyAtIndex(i);
        var price = PriceBySize.GetValueAtIndex(i);
        return new ItemPrice(parcel, "Size >= "+floor, price);
    }

    protected static int FloorIndex (int tgt, SortedList<int, decimal> priceBySize)
    {
        int  i = 0, j = priceBySize.Count;
        while (i < j) {
            var midI = (i + j) >> 1;
            var midKey = priceBySize.GetKeyAtIndex(midI);
            if (midKey == tgt) {                
                return midI;    // Found Exact
            } else if (midKey > tgt) {
                j = midI;
            } else {
                if (j == i+1)
                    return midI;    // Found Floor(Tgt)
                i = midI;
            }
        }
        return i;
    }
    
}
