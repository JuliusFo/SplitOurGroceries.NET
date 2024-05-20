using SplitOurGroceries.Resources.Labels;

namespace SplitOurGroceries
{
    public partial class MainPage : ContentPage
    {
        #region Fields

        

        #endregion

        #region Constructor

        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int PersonCounter { get; set; } = 1;

        public string PersonCounterTx => string.Format(LabelResources.PersonCount, PersonCounter);

        #endregion

        #region Methods



        #endregion
    }
}