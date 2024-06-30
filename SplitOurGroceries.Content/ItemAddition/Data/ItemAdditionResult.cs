using SplitOurGroceries.Common.Models;

namespace SplitOurGroceries.Content.ItemAddition.Data;

public class ItemAdditionResult(SplitItemModel data)
{

    #region Constructor

    #endregion

    #region Properties

    public SplitItemModel Data { get; } = data;

    #endregion
}