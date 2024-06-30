using SplitOurGroceries.Common.Models;
using SplitOurGroceries.Content.ItemAddition.Data;
using SplitOurGroceries.Content.ItemAddition.Services;

namespace SplitOurGroceries.Content.ItemAddition.ViewModels;

public class ItemAdditionViewModel
{
    #region Fields

    private readonly ItemAdditionWebService webService;
    private Action<object?>? closeAction;

    #endregion

    #region Constructor

    public ItemAdditionViewModel(ItemAdditionWebService webService)
    {
        Model = new SplitItemModel();

        this.webService = webService;

        #region Commands

        ScanCommand = new Command(Scan);
        CancelCommand = new Command(Cancel);
        ConfirmCommand = new Command(Confirm);

        #endregion
    }

    #endregion

    #region Properties

    #region Commands

    public Command ScanCommand { get; }

    public Command CancelCommand { get; }

    public Command ConfirmCommand { get; }

    #endregion

    internal ItemAdditionResult? Data { get; set; }

    public SplitItemModel Model { get; set; }

    #endregion

    #region Methods

    #region Data manipulation

    private void Scan()
    {

    }

    #endregion

    #region Bottom buttons

    private void Cancel()
    {
        Data = null;
        closeAction?.Invoke(null);
    }

    private void Confirm()
    {
        Data = new ItemAdditionResult(Model);
        closeAction?.Invoke(null);
    }

    #endregion

    #region Helper

    public void SetCloseAction(Action<object?> closeAction)
    {
        this.closeAction = closeAction;
    }

    #endregion

    #endregion
}