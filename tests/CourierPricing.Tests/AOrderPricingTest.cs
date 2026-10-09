namespace CourierPricing.Tests;

public class AOrderPricingTest
{

    protected int ParcelId;




    // create Parcel by Size only;  zero weight
    protected Parcel CreateParcel (int SizeW, int SizeH, int SizeD)
    {
        return new Parcel(ParcelId++, SizeW, SizeH, SizeD, 0);
    }


    // create Parcel with Size and Weight
    protected Parcel CreateParcelLW (int LargestSize, int Weight)
    {
        return new Parcel(ParcelId++, LargestSize, LargestSize, LargestSize, Weight);
    }


}
