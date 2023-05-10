namespace Asp_WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public GridCollectionViewModel SummerCollection { get; set; } = null!;
        public TopSellingGridCollectionViewModel TopSellingCollection { get; set;} = null!;
    }
}
