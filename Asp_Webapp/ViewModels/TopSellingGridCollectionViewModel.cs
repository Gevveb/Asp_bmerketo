namespace Asp_WebApp.ViewModels;

public class TopSellingGridCollectionViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<GridCollectionItemViewModel> GridTopSellingItems { get; set; } = null!;
    public bool LeftRight { get; set; } = true;
}
