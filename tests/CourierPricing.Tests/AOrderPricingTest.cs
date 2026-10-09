namespace CourierPricing.Tests;

public class AOrderPricingTest
{

    protected int ParcelId;




    protected Parcel CreateParcel (int SizeW, int SizeH, int SizeD)
    {
        return new Parcel(ParcelId++, SizeW, SizeH, SizeD);
    }


}
