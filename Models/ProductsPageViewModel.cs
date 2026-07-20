using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
namespace umbracodemo.Models
{
    public class ProductsPageViewModel : ProductsPage
    {
        public ProductsPageViewModel(IPublishedContent? content, IPublishedValueFallback publishedValueFallback)
            : base(content, publishedValueFallback)
        {
        }
        public List<NorthWindProduct> NorthwindProducts { get; set; } = new();
        public string CreatorName { get; set; } = "Kalle Anka";
    }
}
