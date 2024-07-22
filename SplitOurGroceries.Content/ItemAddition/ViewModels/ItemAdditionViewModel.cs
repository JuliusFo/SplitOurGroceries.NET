﻿using Microsoft.Maui.Controls;
using Plugin.Maui.OCR;
using SplitOurGroceries.Common.BaseModels;
using SplitOurGroceries.Content.ItemAddition.Data;
using SplitOurGroceries.Content.ItemAddition.Services;
using TesseractOcrMaui;
using TesseractOcrMaui.Results;

namespace SplitOurGroceries.Content.ItemAddition.ViewModels;

public class ItemAdditionViewModel : BaseViewModel
{
    #region Fields

    private Action<object?>? closeAction;
    private readonly ITesseract? tesseract;
    private readonly IOcrService? ocrService;

    #endregion

    #region Constructor

    public ItemAdditionViewModel()
    {
        Model = new ItemAdditionModel(string.Empty, 0);

        tesseract = Shell.Current.Handler?.MauiContext?.Services.GetService<ITesseract>();
        ocrService = Shell.Current.Handler?.MauiContext?.Services.GetService<IOcrService>();

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

        if(null == photo)
        {
            return;
        }

        if(null == ocrService)
        {
            return;
        }

        // Open a stream to the photo
        using var sourceStream = await photo.OpenReadAsync();

        // Create a byte array to hold the image data
        var imageData = new byte[sourceStream.Length];

        // Read the stream into the byte array
        await sourceStream.ReadAsync(imageData);

        var a = await ocrService.RecognizeTextAsync(imageData);

        //RecognizionResult result = await tesseract.RecognizeTextAsync(photo.FullPath);

        //if (result.NotSuccess())
        //{
            
        //    return;
        //}

        //Model.Name = result.RecognisedText;
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