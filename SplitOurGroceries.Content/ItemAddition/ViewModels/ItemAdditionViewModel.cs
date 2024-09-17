using System.Collections.ObjectModel;
using Plugin.Maui.OCR;
using SplitOurGroceries.Common.BaseModels;
using SplitOurGroceries.Content.ItemAddition.Data;

namespace SplitOurGroceries.Content.ItemAddition.ViewModels;

public class ItemAdditionViewModel : BaseViewModel
{
    #region Fields

    private Action<object?>? closeAction;
    private readonly IOcrService? ocrService;

    #endregion

    #region Constructor

    public ItemAdditionViewModel()
    {
        Model = new ItemAdditionModel(string.Empty, 0);

        ocrService = Shell.Current.Handler?.MauiContext?.Services.GetService<IOcrService>();

        SelectableOcrNames = [new OcrNameElement("Test")];
        SelectableOcrPrices = [];

        #region Commands

        ScanCommand = new Command(Scan);
        CancelCommand = new Command(Cancel);
        ConfirmCommand = new Command(Confirm);

        #endregion
    }

    #endregion

    #region Properties

    #region Commands

    public Command ScanCommand { get; }

    public Command CancelCommand { get; }

    public Command ConfirmCommand { get; }

    #endregion

    #region XAML

    internal ItemAdditionResult? Data { get; set; }

    public ItemAdditionModel Model { get; set; }

    public ObservableCollection<OcrNameElement> SelectableOcrNames { get; }

    public ObservableCollection<string> SelectableOcrPrices { get; }

    #endregion

    #endregion

    #region Methods

    #region Data manipulation

    private async void Scan()
    {
        if (!MediaPicker.IsCaptureSupported)
        {
            return;
        }

        FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

        if (null == photo)
        {
            return;
        }

        if (null == ocrService)
        {
            return;
        }

        // Open a stream to the photo
        await using var sourceStream = await photo.OpenReadAsync();

        // Create a byte array to hold the image data
        var imageData = new byte[sourceStream.Length];

        // Read the stream into the byte array
        _ = await sourceStream.ReadAsync(imageData);

        OcrResult textResult = await ocrService.RecognizeTextAsync(imageData);
        if (textResult.Success)
        {
            Model.Name = textResult.AllText;
        }
    }

    #endregion

    #region Bottom buttons

    private void Cancel()
    {
        Data = null;
        closeAction?.Invoke(null);
    }

    private void Confirm()
    {
        if (string.IsNullOrEmpty(Model.Name))
        {
            Model.NameHasError = true;
            Model.NameErrorText = "Bitte geben Sie einen Namen ein!";

            RaisePropertyChanged(nameof(Model));

            return;
        }

        Data = new ItemAdditionResult(Model.ToItemModel());
        closeAction?.Invoke(null);
    }

    #endregion

    #region Helper

    public void SetCloseAction(Action<object?> closeAction)
    {
        this.closeAction = closeAction;
    }

    #endregion

    #endregion
}