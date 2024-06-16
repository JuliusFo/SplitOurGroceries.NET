using SplitOurGroceries.Common.Extensions;
using SplitOurGroceries.Content.Main.ViewModel;

namespace SplitOurGroceries
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            HandlerChanged += OnHandlerChanged;
        }

        void OnHandlerChanged(object? sender, EventArgs e)
        {
            this.RegisterViewModel<MainViewModel>();
        }
    }
}