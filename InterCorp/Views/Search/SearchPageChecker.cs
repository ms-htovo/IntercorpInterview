

using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Intercop.Web.UITests.Views.Search
{
    public class SearchPageChecker
    {
        public SearchPageChecker(SearchPage view)
        {
            View = view;
        }

        public SearchPage View { get; }

        public SearchPage ArticleIsShown(string name)
        {
            View.ExplicitWait(View.Locate.Result);
            var results = View.Locate.ResultElement.FindElements(By.ClassName("BOLD")).ToList();
            Assert.IsTrue(results.Any(x => x.Text.Contains(name)), $"{name} is not shown as result");
            TestContext.WriteLine($"Amoumt of items for {name} is {results.First().Text}");
            return View;
        }

        public SearchPage BrandIsShown(string brand)
        {
            View.ExplicitWait(View.Locate.FilterApplied);
            Assert.IsTrue(View.Locate.FilterAppliedElement.Displayed, $"Filter by {brand} is not Displayed");
            Assert.IsTrue(View.Locate.FilterAppliedElement.Text.Contains(brand), $"{brand} is not displayed as a filter");
            return View;
        }

        public SearchPage FilterCombinedIsApplied(string filter1, string filter2)
        {
            View.ExplicitWait(View.Locate.MultipleFilters);
            Assert.IsTrue(View.Locate.MultipleFiltersElement.Displayed, "Multiple Filter is not displayed");
            View.Locate.MultipleFiltersElement.Click();
            var filters = View.Locate.filterListElement.ToList();
            Assert.IsTrue(filters.Any(x => x.Text.Contains(filter1)), $"{filter1} is not shown as result");
            Assert.IsTrue(filters.Any(x => x.Text.Contains(filter2)), $"{filter2} is not shown as result");
            TestContext.WriteLine($"Amoumt if items for {filter1} and {filter2} Filters is {View.Locate.ResultElement.FindElements(By.ClassName("BOLD")).ToList().First().Text}");
            View.Locate.CloseMultipleFilterElement.Click();
            return View;
        }

        public SearchPage OrderIsApplied(string order)
        {
            Assert.AreEqual(View.Locate.OrderIconElement.Text, order);
            return View;
        }


    }
}
