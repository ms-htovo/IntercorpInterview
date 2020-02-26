using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading;
using NUnit.Framework;
using Protractor;

namespace Intercop.Web.UITests.Views.Home
{
    public class HomePageChecker
    {
        public HomePage View { get; }

        public HomePageChecker(HomePage view)
        {
            View = view;
        }

        public HomePage IsHomePage()
        {
            View.ExplicitWait(View.Locate.EbayIcon);
            Assert.IsTrue(View.Locate.EbayIconElement.Displayed);
            Assert.AreEqual(View.WebUser.Driver.WebDriver.Url, ConfigurationManager.AppSettings["url"]);
            return View;
        }
        /*
        public HomePage HomePageIsFullyLoaded()
        {
            View.ExplicitWaitElementNotPresent(View.Locate.NoMatters);
            View.ExplicitWaitElementIsVisible(View.Locate.MatterList);
            ReadOnlyCollection<NgWebElement> matterListWEB = View.Locate.MatterListElement;
            Assert.IsTrue(matterListWEB.Count > 0, "Matters List displayed");
            View.ExplicitWaitUntilToBeClickable(View.Locate.MyMatters);
            return View;
        }

        public HomePage VerifyVersions()
        {
            string apiVersion = DataSourceFromAPI.GetApiVersion();
            View.ExplicitWait(View.Locate.productVersion);
            ReadOnlyCollection<NgWebElement> element = View.Locate.productVersionElement;
            Assert.IsTrue(element[0].Text.Contains("qa"), "QA version is not displayed");
            TestContext.WriteLine($"QA Version is {element[0].Text}");
            Assert.IsTrue(element[1].Text.Contains("qa"), "Engine Version is not displayed");
            TestContext.WriteLine($"Engine Version is {element[1].Text}");
            Assert.IsTrue(element[2].Text.Contains("qa"), "Integration API version is not displayed");
            TestContext.WriteLine($"Integration API Version is {element[2].Text}");
            return View;
        }

        public HomePage NewMatterIsPresentOnLeftMenuBar(string name)
        {
            bool exist = false;
            View.ExplicitWait(View.Locate.MatterTitleLeftMenuBar);
            ReadOnlyCollection<NgWebElement> matterList = View.Locate.MatterTitleLeftMenuBarElements;
            for (int i = 0; i < matterList.Count; i++)
            {
                View.ScrollUntilElement(matterList[i]);
                Thread.Sleep(1000);
                if (matterList[i].Text.Contains(name))
                {
                    exist = true;
                    break;
                }
            }
            Assert.True(exist, $"Matter {name} does not exist on Left Menu Bar.");
            return View;
        }


    */
    }
}