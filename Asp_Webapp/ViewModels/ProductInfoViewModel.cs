using Asp_Webapp.Models.Entities;

namespace Asp_WebApp.ViewModels
{
    public class ProductInfoViewModel
    {

        public IEnumerable<ProductEntity> Products { get; set; } = null!;

    }
}
