using CommunityToolkit.Maui.Views;
using SplitOurGroceries.Content.Extensions;
using SplitOurGroceries.Content.ItemAddition.Data;
using SplitOurGroceries.Content.ItemAddition.ViewModels;

namespace SplitOurGroceries.Content.ItemAddition.Views;

public partial class ItemAdditionView : Popup
{
    #region Fields

    private readonly ItemAdditionViewModel viewModel;

    #endregion

    #region Constructor

    public ItemAdditionView(IElementHandler elementHandler)
    {
        InitializeComponent();
        baseStackLayout.WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width-((DeviceDisplay.Current.MainDisplayInfo.Width/100)*10);

        viewModel = this.RegisterViewModel<ItemAdditionViewModel>(elementHandler);
        viewModel.SetCloseAction(Close);
        BindingContext = viewModel;
    }

    #endregion

    #region Properties

    public ItemAdditionResult? Data => viewModel.Data;

    #endregion
}