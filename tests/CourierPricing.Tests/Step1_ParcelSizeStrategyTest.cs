namespace CourierPricing.Tests;

public class Step1_ParcelSizeStrategyTest : AParcelPricingTest
{



    [Fact]
    public void TestPriceLookups()
    {
        ParcelSizeStrategy strategy = Step1Config.CreateParcelSizeStrategy();

        VerifyPriceAndType(3.00m, "Size >= 0", strategy, CreateParcel(0, 0, 0));
        VerifyPriceAndType(3.00m, "Size >= 0", strategy, CreateParcel(5, 5, 9));
        VerifyPriceAndType(8.00m, "Size >= 10", strategy, CreateParcel(1, 1, 10));
        VerifyPriceAndType(8.00m, "Size >= 10", strategy, CreateParcel(10, 40, 10));
        VerifyPriceAndType(15.00m, "Size >= 50", strategy, CreateParcel(50, 10, 10));
        VerifyPriceAndType(15.00m, "Size >= 50", strategy, CreateParcel(99, 10, 50));
        VerifyPriceAndType(25.00m, "Size >= 100", strategy, CreateParcel(100, 10, 50));
        VerifyPriceAndType(25.00m, "Size >= 100", strategy, CreateParcel(200, 200, 200));
    }


}
