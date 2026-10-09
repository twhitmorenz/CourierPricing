namespace CourierPricing.Tests;

public class AParcelPricingTest
{

    protected int ParcelId;



    protected Parcel CreateParcel (int SizeW, int SizeH, int SizeD)
    {
        return new Parcel(ParcelId++, SizeW, SizeH, SizeD);
    }

    protected void VerifyPrice (decimal expectedPrice, IParcelPricingStrategy strategy, Parcel parcel)
    {
        var result = strategy.Price(parcel);
        Assert.Equal(expectedPrice, result.Price);        
    }
    protected void VerifyPriceAndType (decimal expectedPrice, string expectedType, IParcelPricingStrategy strategy, Parcel parcel)
    {
        var result = strategy.Price(parcel);
        Assert.Equal(expectedPrice, result.Price);
        Assert.Equal(expectedType, result.Type);
    }

}
