namespace CourierPricing;

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
