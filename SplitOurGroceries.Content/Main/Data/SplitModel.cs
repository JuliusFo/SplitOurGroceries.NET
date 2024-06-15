namespace SplitOurGroceries.Content.Main.Data;

internal class SplitModel
{
    #region Fields



    #endregion

    #region Constructor

    public SplitModel()
    {
        Persons = new SplitPersonModel();
        Items = new List<SplitItemModel>();
    }

    #endregion

    #region Properties

    public SplitPersonModel Persons { get; }

    public ICollection<SplitItemModel> Items { get; }

    #endregion

    #region Methods



    #endregion
}
