using CommunityToolkit.Maui;
using DevExpress.Maui;
using Microsoft.Extensions.Logging;
using SplitOurGroceries.Content.ItemAddition.Services;
using SplitOurGroceries.Content.ItemAddition.ViewModels;
using SplitOurGroceries.Content.ItemAddition.Views;
using SplitOurGroceries.Content.Main.ViewModel;
using TesseractOcrMaui;

namespace SplitOurGroceries
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseDevExpress()
                .UseDevExpressEditors()
                .UseDevExpressCollectionView()
                .UseDevExpressDataGrid()
                .UseDevExpressControls()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            // More services registered here.
            mauiAppBuilder.Services.AddSingleton<ItemAdditionWebService>();

            // Inject library functionality
            mauiAppBuilder.Services.AddTesseractOcr(
                files =>
                {
                    // must have matching files in Resources/Raw folder
                    files.AddFile("deu.traineddata");
                });

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainViewModel>();
            mauiAppBuilder.Services.AddSingleton<ItemAdditionViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPage>();
            mauiAppBuilder.Services.AddSingleton<ItemAdditionView>();

            return mauiAppBuilder;
        }
    }
}
