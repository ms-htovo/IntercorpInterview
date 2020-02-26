using NUnit.Framework;
using Intercop.Views.Common;

namespace Intercop.Tests
{
    public class ArticleTests : UITest
    {
        [Test]
        public void TC_OrderByPriceAsc()
        {
            Browser
                .GoToHomePage()
                .Verify().IsHomePage()
                .LookForArticle("Zapatos")
                .Verify().ArticleIsShown("Zapatos")
                .SelectFilter("PUMA")
                .Verify().BrandIsShown("PUMA")
                .SelectFilter("10")
                .Verify().FilterCombinedIsApplied("PUMA", "10")
                .ApplyOrder("Precio + Envío: más bajo primero")
                .Verify().OrderIsApplied("Precio + Envío: más bajo primero")
                .SaveFirstFiveAriticle()
                .PrintFirstFiveArticleWithPrices()
                .PrintArticlesOrderedByNameAsc()
                .PrintArticlesOrderedByPriceDesc();
                
        }

    }  
}
