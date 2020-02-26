

using Intercop.Web.UITests.Views.Common;
using OpenQA.Selenium;
using Protractor;
using System.Collections.ObjectModel;

namespace Intercop.Web.UITests.Views.Search
{
    public class SearchPageLocator
    {
        public NgWebDriver Web { get; private set; }

        public SearchPageLocator(TestUser webUser)
        {
            Web = webUser.Driver.WebDriver;
        }

        public By Result => By.ClassName("srp-controls__count-heading");

        public NgWebElement ResultElement => Web.FindElement(Result);

        public By Brands => By.CssSelector(".cbx.x-refine__multi-select-cbx");

        public ReadOnlyCollection<NgWebElement> BrandList => Web.FindElements(Brands);

        public By FilterApplied => By.ClassName("srp-carousel-list__item-link");

        public NgWebElement FilterAppliedElement => Web.FindElement(FilterApplied);

        public By MultipleFilters => By.ClassName("srp-multi-aspect__flyout__btn-label");

        public NgWebElement MultipleFiltersElement => Web.FindElement(MultipleFilters);

        public By filterList => By.ClassName("srp-multi-aspect__item--overflow");

        public ReadOnlyCollection<NgWebElement> filterListElement => Web.FindElements(filterList);

        public By CloseMultipleFilter => By.CssSelector("#w21");

        public NgWebElement CloseMultipleFilterElement => Web.FindElement(CloseMultipleFilter);

        public By OrderIcon => By.CssSelector("#w9 .srp-controls--selected-value");

        public NgWebElement OrderIconElement => Web.FindElement(OrderIcon);

        public By OrderList => By.CssSelector(".btn span");

        public ReadOnlyCollection<NgWebElement> OrderListElement => Web.FindElements(OrderList);




    }
}
