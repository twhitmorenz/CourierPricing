namespace CourierPricing;

public record struct Parcel(int Id, int SizeW, int SizeH, int SizeD) 
{
    public readonly string Desc => "Parcel "+Id;
    public readonly int LargestSize => Math.Max(SizeW, Math.Max(SizeH, SizeD));

}
