namespace CourierPricing.Tests;

public class Step1Test : AOrderPricingTest
{


    [Fact]
    public void TestOrderPricing_Empty()
    {
        var strategy = Step1Config.CreateOrderPricingStrategy();

        var order = new Order([]);
        var result = strategy.Price(order);
        Assert.Equal(0, result.Items.Count);
        Assert.Equal(0m, result.Total);
    }

    [Fact]
    public void TestOrderPricing_OneSmall()
    {
        var strategy = Step1Config.CreateOrderPricingStrategy();

        var order = new Order([
            CreateParcel(5, 5, 5)
        ]);
        var result = strategy.Price(order);
        Assert.Equal(1, result.Items.Count);
        Assert.Equal(3.00m, result.Total);
    }

    [Fact]
    public void TestOrderPricing_TwoMixed()
    {
        var strategy = Step1Config.CreateOrderPricingStrategy();

        var order = new Order([
            CreateParcel(5, 5, 5),
            CreateParcel(60, 60, 60),
        ]);
        var result = strategy.Price(order);
        Assert.Equal(2, result.Items.Count);
        Assert.Equal(3.00m, result.Items[0].Price);
        Assert.Equal(15.00m, result.Items[1].Price);
        Assert.Equal(18.00m, result.Total);
    }


}
