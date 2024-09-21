namespace SplitOurGroceries.Content.ItemAddition.Data;

public class OcrNameElement(string name)
{
    public string Name { get; set; } = name;

    public bool IsChecked { get; set; } = false;
}