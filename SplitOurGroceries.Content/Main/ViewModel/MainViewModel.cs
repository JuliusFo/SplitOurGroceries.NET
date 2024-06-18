using CommunityToolkit.Maui.Views;
using SplitOurGroceries.Common.BaseModels;
using SplitOurGroceries.Content.ItemAddition.Views;
using SplitOurGroceries.Content.Main.Data;
using SplitOurGroceries.Resources.Labels;

namespace SplitOurGroceries.Content.Main.ViewModel
{
    public class MainViewModel : BaseViewModel
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

        private async void AddNewItem()
        {
            if (null == Shell.Current.Handler)
            {
                return;
            }

            ItemAdditionView itemAdditionPopup = new(Shell.Current.Handler);
            _ = await Shell.Current.ShowPopupAsync(itemAdditionPopup);

            if (null != itemAdditionPopup.Data)
            {

            }
        }

        private void RemovePerson()
        {
            Model.Persons.DecreasePersonCount();
            RaisePropertyChanged(nameof(Model));
        }

        #endregion
    }
}