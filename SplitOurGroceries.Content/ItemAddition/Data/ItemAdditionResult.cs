using SplitOurGroceries.Common.Models;

namespace SplitOurGroceries.Content.ItemAddition.Data;

public class ItemAdditionResult
{
    #region Constructor

    public ItemAdditionResult(SplitItemModel data)
    {
        Data = data;
    }

    #endregion

    #region Properties

    public SplitItemModel Data { get; }

    #endregion
}