using System.Configuration;
using Intercop.Web.UITests.Views.Common;
using Intercop.Web.UITests.Views.Search;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Intercop.Web.UITests.Views.Home
{
    public class HomePage : Common.Common
    {

        public HomePage(TestUser webUser) : base (webUser)
        {
            WebUser.Driver.WebDriver.IgnoreSynchronization = true;
            WebUser.Driver.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
            Locate = new HomePageLocator(WebUser);

        }

        public HomePageLocator Locate { get; }

        public HomePageChecker Verify()
        {
            return new HomePageChecker(this);
        }
        
        public SearchPage LookForArticle(string name)
        {
            /*This metod Entry a criteria to the main search of Home Page which is given as a param*/
            ExplicitWait(Locate.Search);
            Locate.SearchElement.SendKeys(name);
            Locate.SearchElement.SendKeys(Keys.Enter);
            TestContext.WriteLine($"Look for Articule {name}");
            return new SearchPage(WebUser);
        }

    }
}
