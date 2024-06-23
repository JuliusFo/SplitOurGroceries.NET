namespace SplitOurGroceries.Common.Models;

public class SplitItemModel
{
    #region Fields



    #endregion

    #region Constructor

    public SplitItemModel(string name, float price)
    {
        Name = name;
        Price = price;
    }

    public SplitItemModel()
    {

    }

    #endregion

    #region Properties

    public string? Name { get; private set; }

    public float? Price { get; private set; }

    #endregion

    #region Methods

    public void SetNewData(string name, float price)
    {
        Name = name;
        Price = price;
    }

    #endregion
}