using Asp_Webapp.Models.Entities;

namespace Asp_WebApp.ViewModels;

public class TopSellingGridCollectionViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<ProductEntity> GridTopSellingItems { get; set; } = null!;
    public bool LeftRight { get; set; } = true;
}
