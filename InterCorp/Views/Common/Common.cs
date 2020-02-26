using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
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
            try
            {

                var wait = new WebDriverWait(WebUser.Driver.WebDriver.WrappedDriver, new TimeSpan(0, 0, 30));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                Assert.IsTrue(element.Displayed, $"Locator {locator} is not displayed");
            }
            catch
            {
                var name = $"ElementNotFound{DateTime.Now.Minute}.png";
                WebUser.Driver.WebDriver.WrappedDriver.TakeScreenshot().SaveAsFile(name);
                throw new Exception($"Element is not present {locator}. See image {name}");
            }
        }

        public void ExplicitWaitElementClickable(By locator)
        {
            var wait = new WebDriverWait(WebUser.Driver.WebDriver.WrappedDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            Assert.IsTrue(element.Displayed, $"Locator {locator} is not displayed");
        }

    }
}
