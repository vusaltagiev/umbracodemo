using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Data;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbracodemo.Models;

namespace umbracodemo.Controllers
{
    public class ProductsPageController : RenderController
    {
        private readonly IDbConnection _dbConnection;
        private readonly IPublishedValueFallback _publishedValueFallback;

        public ProductsPageController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IDbConnection dbConnection,
            IPublishedValueFallback publishedValueFallback)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _dbConnection = dbConnection;
            _publishedValueFallback = publishedValueFallback;
        }

        public override IActionResult Index()
        {
            string sql = "SELECT * FROM Products ORDER BY ProductName";
            var products = _dbConnection.Query<NorthWindProduct>(sql).ToList();

            var model = new ProductsPageViewModel(CurrentPage, _publishedValueFallback)
            {
                NorthwindProducts = products,
                CreatorName = "Vüsal Tagiev"
            };

            return CurrentTemplate(model);
        }
    }
}