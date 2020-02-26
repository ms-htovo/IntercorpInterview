
using Intercop.Web.UITests.Views.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Intercop.Web.UITests.Views.Search
{
    public class SearchPage : Common.Common
    {
        List<NgWebElement> _FirstFiveArticlesList;
        Dictionary<string, string> _articlesWithPrices;

        public SearchPage (TestUser webUser) : base(webUser)
        {
            Locate = new SearchPageLocator(webUser);
        }

        public SearchPageLocator Locate { get; }


        public SearchPageChecker Verify()
        {
            return new SearchPageChecker(this);
        }

        public SearchPage SelectFilter(string filterName)
        {
            ExplicitWait(Locate.Brands);
            Assert.IsTrue(Locate.BrandList.ToList().Any(x => x.Text.Contains(filterName)), $"{filterName} is not shown as result");
            foreach (NgWebElement elem in Locate.BrandList)
            {
                if (elem.Text.Contains(filterName))
                {
                    elem.Click();
                    break;
                }
            }
            TestContext.WriteLine($"Filter {filterName} is selected");
            return this;

        }

        public SearchPage ApplyOrder(string order)
        {
            Actions tooltip = new Actions(WebUser.Driver.WebDriver);
            tooltip.MoveToElement(Locate.OrderIconElement).Perform();
            ExplicitWait(Locate.OrderList);
            var orderList = Locate.OrderListElement;
            foreach (NgWebElement element in orderList)
            {
                if (element.Text.Contains(order))
                {
                    element.Click();
                    break;
                }
            }
            TestContext.WriteLine($"Order Applied: {order}");
            return this;

        }

        public SearchPage SaveFirstFiveAriticle()
        {
            List<NgWebElement> articleResults = WebUser.Driver.WebDriver.FindElements(By.CssSelector(".s-item")).ToList();
            _FirstFiveArticlesList = articleResults.GetRange(1, 6);
            TestContext.WriteLine("Article List is saved on a List");
            return this;
        }


        public SearchPage PrintFirstFiveArticleWithPrices()
        {
            _articlesWithPrices = new Dictionary<string, string>();
            foreach (NgWebElement elem in _FirstFiveArticlesList)
            {
               var itemName = elem.FindElement(By.ClassName("s-item__title")).Text;
               var price = elem.FindElement(By.ClassName("s-item__price")).Text;
               _articlesWithPrices.Add(itemName, price);
            }
            foreach (KeyValuePair<string, string> element in _articlesWithPrices)
            {
                TestContext.WriteLine("Article Name = {0}, Article Price = {1}", element.Key, element.Value);
            }
            return this;
        }


        public SearchPage PrintArticlesOrderedByNameAsc()
        {
            TestContext.WriteLine("Articles Ordered By Name Asc:");
            var listOrdered = _articlesWithPrices.OrderBy(x => x.Key);
            foreach (var element in listOrdered)
            {
                TestContext.WriteLine("Article Name = {0}, Article Price = {1}", element.Key, element.Value);
            }
            return this;
        }

        public SearchPage PrintArticlesOrderedByPriceDesc()
        {
            TestContext.WriteLine("Articles Ordered By Price Desc:");
            var listOrdered = _articlesWithPrices.OrderByDescending(x => x.Value);
            foreach (var element in listOrdered)
            {
                TestContext.WriteLine("Article Name = {0}, Article Price = {1}", element.Key, element.Value);
            }
            return this;

        }
    }
}
