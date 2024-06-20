using SplitOurGroceries.Common.Models;
using SplitOurGroceries.Content.ItemAddition.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitOurGroceries.Content.ItemAddition.ViewModels;

public class ItemAdditionViewModel
{
    #region Fields



    #endregion

    #region Constructor

    public ItemAdditionViewModel()
    {
        Model = new SplitItemModel(string.Empty, 0f);
    }

    #endregion

    #region Properties

    internal ItemAdditionResult? Data { get; set; }

    public SplitItemModel Model { get; set; }

    #endregion

    #region Methods



    #endregion
}