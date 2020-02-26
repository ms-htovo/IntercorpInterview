using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Intercop.Web.UITests.Views.Common
{
    public class Common
    {
        public TestUser WebUser { get; set; }
        public IDriver Browser => WebUser.Driver;

        protected Common(TestUser webUser)
        {
            WebUser = webUser;
        }

        public void ExplicitWait(By locator)
        {
            var wait = new WebDriverWait(WebUser.Driver.WebDriver.WrappedDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            Assert.IsTrue(element.Displayed, $"Locator {locator} is not displayed");
        }
    }
}
