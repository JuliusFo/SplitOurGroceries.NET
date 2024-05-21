namespace SplitOurGroceries.Common.Extensions
{
    public static class ContentPageExtensions
    {
        public static TViewModel RegisterViewModel<TViewModel>(this ContentPage contentPage)
        {
            if (null == contentPage.Handler?.MauiContext)
            {
                throw new ApplicationException($"A dependency could not be resolved.");
            }

            TViewModel? viewModel = contentPage.Handler.MauiContext.Services.GetService<TViewModel>();

            if (null == viewModel)
            {
                throw new ApplicationException($"A viewmodel of type {typeof(TViewModel)} cannot be found.");
            }

            contentPage.BindingContext = viewModel;
            return viewModel;
        }
    }
}
