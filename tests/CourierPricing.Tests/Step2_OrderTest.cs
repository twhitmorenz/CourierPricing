namespace CourierPricing.Tests;

public class Step2_OrderTest : AOrderPricingTest
{


    [Fact]
    public void TestOrderPricing_TwoMixed_Normal()
    {
        var strategy = Step2Config.CreateOrderPricingStrategy();

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

    [Fact]
    public void TestOrderPricing_TwoMixed_Speedy()
    {
        var strategy = Step2Config.CreateOrderPricingStrategy();

        var order = new Order([
            CreateParcel(5, 5, 5),
            CreateParcel(60, 60, 60),
        ]);
        order.Shipping = ShippingType.SPEEDY;

        var result = strategy.Price(order);
        Assert.Equal(3, result.Items.Count);
        Assert.Equal(3.00m, result.Items[0].Price);
        Assert.Equal(15.00m, result.Items[1].Price);
        Assert.Equal(18.00m, result.Items[2].Price);
        Assert.Equal(36.00m, result.Total);
    }


}
