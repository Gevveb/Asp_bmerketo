namespace Asp_WebApp.ViewModels
{
    public class ProductsIndexViewModel
    {
        public string Title { get; set; } = "Products";
        public GridCollectionViewModel All { get; set; } = null!;
    }
}
