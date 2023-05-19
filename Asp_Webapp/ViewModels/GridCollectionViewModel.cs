using Asp_Webapp.Models.Entities;

namespace Asp_WebApp.ViewModels;

public class GridCollectionViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<ProductEntity> GridItems { get; set; } = null!;
    public bool LoadMore { get; set; } = false;
}
