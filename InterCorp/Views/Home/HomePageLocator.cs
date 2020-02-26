using OpenQA.Selenium;
using Intercop.Web.UITests.Views.Common;
using Protractor;

namespace Intercop.Web.UITests.Views.Home
{
    public class HomePageLocator 
    {
        public NgWebDriver Web { get; private set; }

        public HomePageLocator(TestUser webUser) 
        {
            Web = webUser.Driver.WebDriver;
        }

        public By EbayIcon => By.Id("gh-logo");

        public NgWebElement EbayIconElement => Web.FindElement(EbayIcon);

        public By Search => By.Id("gh-ac");

        public NgWebElement SearchElement => Web.FindElement(Search);



        
    }
}
