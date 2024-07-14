using CommunityToolkit.Maui.Views;
using SplitOurGroceries.Common.BaseModels;
using SplitOurGroceries.Common.Models;
using SplitOurGroceries.Content.ItemAddition.Views;

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
            Model.Items.Add(new SplitItemModel("Test", 1.23f, 1));

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
                Model.Items.Add(itemAdditionPopup.Data.Data);
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