using SplitOurGroceries.Common.Models;
using SplitOurGroceries.Content.ItemAddition.Data;

namespace SplitOurGroceries.Content.ItemAddition.ViewModels;

public class ItemAdditionViewModel
{
    #region Fields



    #endregion

    #region Constructor

    public ItemAdditionViewModel()
    {
        Model = new SplitItemModel();

        #region Commands

        DecreaseQuantityCommand = new Command(DecreaseQuantity);
        IncreaseQuantityCommand = new Command(IncreaseQuantity);
        ScanBarcodeCommand = new Command(ScanBarcode);
        CancelCommand = new Command(Cancel);
        ConfirmCommand = new Command(Confirm);

        #endregion
    }

    #endregion

    #region Properties

    #region Commands

    public Command DecreaseQuantityCommand { get; }

    public Command IncreaseQuantityCommand { get; }

    public Command ScanBarcodeCommand { get; }

    public Command CancelCommand { get; }

    public Command ConfirmCommand { get; }

    #endregion

    internal ItemAdditionResult? Data { get; set; }

    public SplitItemModel Model { get; set; }

    #endregion

    #region Methods

    #region Data manipulation

    private void DecreaseQuantity()
    {

    }

    private void IncreaseQuantity()
    {

    }

    private void ScanBarcode()
    {

    }

    #endregion

    #region Bottom buttons

    private void Cancel()
    {

    }

    private void Confirm()
    {

    }

    #endregion

    #endregion
}