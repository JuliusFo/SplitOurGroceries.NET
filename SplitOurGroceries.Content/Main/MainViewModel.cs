using SplitOurGroceries.Content.Main.Data;
using SplitOurGroceries.Resources.Labels;
using System.ComponentModel;

namespace SplitOurGroceries.Content.Main
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields



        #endregion

        #region Constructor

        public MainViewModel()
        {
            Model = new SplitModel();

            #region Commands

            AddPersonCommand = new Command(AddPerson);
            RemovePersonCommand = new Command(RemovePerson);

            #endregion
        }

        #endregion

        #region Properties

        #region Commands

        public Command AddPersonCommand { get; }

        public Command RemovePersonCommand { get; }

        public SplitModel Model { get; }

        #endregion

        public int PersonCounter { get; set; } = 2;

        public string PersonCounterTx => string.Format(LabelResources.PersonCount, PersonCounter);

        #endregion

        #region Methods

        private void AddPerson()
        {
            Model.Persons.IncreasePersonCount();
            RaisePropertyChanged(nameof(Model));
        }

        private void RemovePerson()
        {
            Model.Persons.DecreasePersonCount();
            RaisePropertyChanged(nameof(Model));
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #endregion
    }
}