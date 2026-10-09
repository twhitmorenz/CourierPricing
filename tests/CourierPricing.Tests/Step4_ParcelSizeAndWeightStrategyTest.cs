namespace CourierPricing.Tests;

public class Step4_ParcelSizeAndWeightStrategyTest : AParcelPricingTest
{



    [Fact]
    public void TestPriceLookups_BySize()
    {
        IParcelPricingStrategy strategy = Step4Config.CreateParcelSizeAndWeightStrategy();

        VerifyPriceAndType(3.00m, "Small", strategy, CreateParcelLW(0, 0));
        VerifyPriceAndType(3.00m, "Small", strategy, CreateParcelLW(9, 0));
        VerifyPriceAndType(8.00m, "Medium", strategy, CreateParcelLW(10, 0));
        VerifyPriceAndType(8.00m, "Medium", strategy, CreateParcelLW(49, 0));
        VerifyPriceAndType(15.00m, "Large", strategy, CreateParcelLW(50, 0));
        VerifyPriceAndType(15.00m, "Large", strategy, CreateParcelLW(99, 0));
        VerifyPriceAndType(25.00m, "XL", strategy, CreateParcelLW(100, 0));
    }

    [Fact]
    public void TestHeavyParcel()
    {
        IParcelPricingStrategy strategy = Step4Config.CreateParcelSizeAndWeightStrategy();

        VerifyPriceAndType(25.00m, "XL", strategy, CreateParcelLW(100, 0));
        VerifyPriceAndType(50.00m, "Heavy", strategy, CreateParcelLW(100, 30));
        VerifyPriceAndType(50.00m, "Heavy", strategy, CreateParcelLW(100, 50));
        VerifyPriceAndType(60.00m, "Heavy; overweight 10 kg", strategy, CreateParcelLW(100, 60));
    }

    [Fact]
    public void TestPriceLookups_Overage()
    {
        IParcelPricingStrategy strategy = Step4Config.CreateParcelSizeAndWeightStrategy();

        VerifyPriceAndType(3.00m, "Small", strategy, CreateParcelLW(0, 0));
        VerifyPriceAndType(3.00m, "Small", strategy, CreateParcelLW(9, 1));
        VerifyPriceAndType(5.00m, "Small; overweight 1 kg", strategy, CreateParcelLW(9, 2));
        VerifyPriceAndType(7.00m, "Small; overweight 2 kg", strategy, CreateParcelLW(9, 3));

        VerifyPriceAndType(15.00m, "Large", strategy, CreateParcelLW(50, 0));
        VerifyPriceAndType(15.00m, "Large", strategy, CreateParcelLW(50, 6));
        VerifyPriceAndType(17.00m, "Large; overweight 1 kg", strategy, CreateParcelLW(50, 7));
    }

    // at Step 4, 'Heavy' becomes optimal for 'XL' parcels > 22.5 kg.
    [Fact]
    public void TestPriceLookups_HeavyAsOptimal()
    {
        IParcelPricingStrategy strategy = Step4Config.CreateParcelSizeAndWeightStrategy();

        VerifyPriceAndType(45.00m, "XL; overweight 10 kg", strategy, CreateParcelLW(100, 20));
        VerifyPriceAndType(49.00m, "XL; overweight 12 kg", strategy, CreateParcelLW(100, 22));
        VerifyPriceAndType(50.00m, "Heavy", strategy, CreateParcelLW(100, 23));
    }

}
