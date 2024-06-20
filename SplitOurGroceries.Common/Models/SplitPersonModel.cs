namespace SplitOurGroceries.Common.Models;

public class SplitPersonModel
{
    #region Fields

    private int count;

    #endregion

    #region Constructor

    public SplitPersonModel()
    {
        count = 1;
    }

    #endregion

    #region Properties

    public int Count
    {
        get => count;
    }

    #endregion

    #region Methods

    public void DecreasePersonCount()
    {
        if (count == 1)
        {
            return;
        }

        count -= 1;
    }

    public void IncreasePersonCount()
    {
        count += 1;
    }

    #endregion
}
