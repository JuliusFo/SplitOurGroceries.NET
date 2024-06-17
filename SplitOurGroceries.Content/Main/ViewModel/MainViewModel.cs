using SplitOurGroceries.Content.Main.Data;
using SplitOurGroceries.Resources.Labels;
using System.ComponentModel;

namespace SplitOurGroceries.Content.Main.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields



        #endregion

        #region Constructor

        public MainViewModel()
        {
            Model = new SplitModel();
            Model.Items.Add(new SplitItemModel("Test", 1.23f));

            #region Commands

            AddPersonCommand = new Command(AddPerson);
            AddNewItemCommand = new Command(AddNewItem);
            RemovePersonCommand = new Command(RemovePerson);

            #endregion
        }

        #endregion

        #region Properties

        #region Commands

        public Command AddPersonCommand { get; }

        public Command RemovePersonCommand { get; }

        public Command AddNewItemCommand { get; }

        #endregion

        public SplitModel Model { get; }

        public int PersonCounter { get; set; } = 2;

        public string PersonCounterTx => string.Format(LabelResources.PersonCount, PersonCounter);

        #endregion

        #region Methods

        private void AddPerson()
        {
            Model.Persons.IncreasePersonCount();
            RaisePropertyChanged(nameof(Model));
        }

        private void AddNewItem()
        {
            
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