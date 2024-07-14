using System.Collections.ObjectModel;

namespace SplitOurGroceries.Common.Models;

public class SplitModel
{
    #region Fields



    #endregion

    #region Constructor

    public SplitModel()
    {
        Persons = new SplitPersonModel();
        Items = new ObservableCollection<SplitItemModel>();
    }

    #endregion

    #region Properties

    public SplitPersonModel Persons { get; }

    public ObservableCollection<SplitItemModel> Items { get; }

    #endregion

    #region Methods



    #endregion
}
