using SplitOurGroceries.Resources.Labels;

namespace SplitOurGroceries.Content.Main
{
    public class MainViewModel
    {
        #region Fields



        #endregion

        #region Constructor

        public MainViewModel()
        {

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