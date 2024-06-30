using SplitOurGroceries.Common.Models;
using System.ComponentModel;

namespace SplitOurGroceries.Content.ItemAddition.Data;

public class ItemAdditionModel(string name, float price) : INotifyPropertyChanged
{
    #region Fields

    private string name = name;

    #endregion
    #region Constructor

    #endregion

    #region Properties

    public string Name
    {
        get => name;
        set
        {
            name = value;

            if(value != null)
            {
                NameHasError = false;
                NameErrorText = null;

                RaisePropertyChanged(nameof(NameHasError));
                RaisePropertyChanged(nameof(NameErrorText));
            }
        }
    }

    public float Price { get; set; } = price;

    public int Quantity { get; set; } = 1;

    public bool NameHasError { get; set; } = false;

    public string? NameErrorText { get; set; } = null;

    #endregion

    #region Methods

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    #endregion

    public SplitItemModel ToItemModel()
    {
        return new SplitItemModel(Name, Price, Quantity);
    }

    #endregion
}