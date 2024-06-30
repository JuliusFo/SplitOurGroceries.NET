namespace SplitOurGroceries.Common.Models;

public class SplitItemModel(string name, float price, int? quantity)
{
    #region Properties

    public string Name { get; set; } = name;

    public float Price { get; set; } = price;

    public int Quantity { get; set; } = quantity ?? 1;

    #endregion
}