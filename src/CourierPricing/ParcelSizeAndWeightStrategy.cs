namespace CourierPricing;

/// <summary>
/// Prices parcels by Size (largest dimension) and Weight.
/// 
/// config: List<SizeAndWeight>.
/// note: unlike ParcelSizeStrategy, we need a 'Max Size' for this config not just than a 'Threshold Size'.
/// 
/// chosen option must be where Parcel.LargestSize < SizeAndWeight.SizeMax
/// overage per Kg over SizeAndWeight.WeightMax applies.
/// choose the cheapest option (might not be the smallest-size option)
/// 
/// </summary>
public record ParcelSizeAndWeightStrategy : IParcelPricingStrategy {
    
    public List<SizeAndWeight> PriceTable { get; }
    public decimal OveragePerKg { get; }

    public ParcelSizeAndWeightStrategy (List<SizeAndWeight> PriceTable, decimal OveragePerKg)
    {
        this.PriceTable = PriceTable;
        this.OveragePerKg = OveragePerKg;
    }

    public ItemPrice Price (Parcel parcel)
    {
        // check Price + Overage at multiple sizes, use the minimum
        //      --
        int parcelSize = parcel.LargestSize;
        int parcelWeight = parcel.Weight;
        ItemPrice? best = null;
        foreach (var option in PriceTable)
        {
            if (parcelSize >= option.SizeMax)
                continue;
            int weightOver = Math.Max( parcelWeight-option.WeightMax, 0);
            decimal weightOverage = weightOver * OveragePerKg;
            decimal price = option.Price + weightOverage;
            var desc = $"Size up to {option.SizeMax}" + ((weightOver > 0) ? $"; overweight {weightOver} kg" : "");
            var optionPrice = new ItemPrice(parcel, desc, price);

            // check if it's best
            if (best is null || optionPrice.Price < best?.Price)
            {
                best = optionPrice;
            }
        }

        // ensure we got a shipping option;
        //      -- failure would typically only occur if PriceTable was empty, or there were hard maximum limits on entries
        return best ??
            throw new ArgumentOutOfRangeException($"Parcel not accepted for shipping: {parcel}");
    }


    public record SizeAndWeight (int SizeThreshold, int SizeMax, int WeightMax, decimal Price);

}


