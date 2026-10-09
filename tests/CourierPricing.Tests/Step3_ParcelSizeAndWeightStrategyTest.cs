namespace CourierPricing.Tests;

public class Step3_ParcelSizeAndWeightStrategyTest : AParcelPricingTest
{



    [Fact]
    public void TestPriceLookups_BySize()
    {
        IParcelPricingStrategy strategy = Step3Config.CreateParcelSizeAndWeightStrategy();

        VerifyPriceAndType(3.00m, "Size up to 10", strategy, CreateParcelLW(0, 0));
        VerifyPriceAndType(3.00m, "Size up to 10", strategy, CreateParcelLW(9, 0));
        VerifyPriceAndType(8.00m, "Size up to 50", strategy, CreateParcelLW(10, 0));
        VerifyPriceAndType(8.00m, "Size up to 50", strategy, CreateParcelLW(49, 0));
        VerifyPriceAndType(15.00m, "Size up to 100", strategy, CreateParcelLW(50, 0));
        VerifyPriceAndType(15.00m, "Size up to 100", strategy, CreateParcelLW(99, 0));
        VerifyPriceAndType(25.00m, "Size up to 2147483647", strategy, CreateParcelLW(100, 0));      // TODO -- ugly message
    }

    [Fact]
    public void TestPriceLookups_Overage()
    {
        IParcelPricingStrategy strategy = Step3Config.CreateParcelSizeAndWeightStrategy();

        VerifyPriceAndType(3.00m, "Size up to 10", strategy, CreateParcelLW(0, 0));
        VerifyPriceAndType(3.00m, "Size up to 10", strategy, CreateParcelLW(9, 1));
        VerifyPriceAndType(5.00m, "Size up to 10; overweight 1 kg", strategy, CreateParcelLW(9, 2));
        VerifyPriceAndType(7.00m, "Size up to 10; overweight 2 kg", strategy, CreateParcelLW(9, 3));

        VerifyPriceAndType(15.00m, "Size up to 100", strategy, CreateParcelLW(50, 0));
        VerifyPriceAndType(15.00m, "Size up to 100", strategy, CreateParcelLW(50, 6));
        VerifyPriceAndType(17.00m, "Size up to 100; overweight 1 kg", strategy, CreateParcelLW(50, 7));
        VerifyPriceAndType(55.00m, "Size up to 100; overweight 20 kg", strategy, CreateParcelLW(50, 26));
    }

    // at Step 3, there is no optimization from choosing a larger parcel size since extra weight allowance is more expensive/$ than the $2.00/kg overage.
    [Fact]
    public void TestPriceLookups_OverageIsOptimal()
    {
        IParcelPricingStrategy strategy = Step3Config.CreateParcelSizeAndWeightStrategy();

        VerifyPriceAndType(7.00m, "Size up to 10; overweight 2 kg", strategy, CreateParcelLW(9, 3));
        VerifyPriceAndType(9.00m, "Size up to 10; overweight 3 kg", strategy, CreateParcelLW(9, 4));
        VerifyPriceAndType(11.00m, "Size up to 10; overweight 4 kg", strategy, CreateParcelLW(9, 5));
        VerifyPriceAndType(13.00m, "Size up to 10; overweight 5 kg", strategy, CreateParcelLW(9, 6));
        VerifyPriceAndType(15.00m, "Size up to 10; overweight 6 kg", strategy, CreateParcelLW(9, 7));
        VerifyPriceAndType(17.00m, "Size up to 10; overweight 7 kg", strategy, CreateParcelLW(9, 8));
        VerifyPriceAndType(19.00m, "Size up to 10; overweight 8 kg", strategy, CreateParcelLW(9, 9));
        VerifyPriceAndType(21.00m, "Size up to 10; overweight 9 kg", strategy, CreateParcelLW(9, 10));
    }

}
