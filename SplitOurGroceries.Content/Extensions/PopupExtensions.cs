using CommunityToolkit.Maui.Views;

namespace SplitOurGroceries.Content.Extensions;

internal static class PopupExtensions
{
    public static TViewModel RegisterViewModel<TViewModel>(this Popup popup, IElementHandler handler)
    {
        if (null == handler.MauiContext)
        {
            throw new ApplicationException($"A dependency could not be resolved.");
        }

        TViewModel? viewModel = handler.MauiContext.Services.GetService<TViewModel>();

        if (null == viewModel)
        {
            throw new ApplicationException($"A viewmodel of type {typeof(TViewModel)} cannot be found.");
        }

        popup.BindingContext = viewModel;
        return viewModel;
    }
}