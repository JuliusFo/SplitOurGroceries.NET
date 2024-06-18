using System.ComponentModel;

namespace SplitOurGroceries.Common.BaseModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        public string Title { get; set; } = string.Empty;

        #endregion

        #region Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #endregion
    }
}