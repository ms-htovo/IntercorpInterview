using Intercop.Views.Common;
using Protractor;

namespace Intercop.Web.UITests.Views.Common
{
    public interface IDriver
    {
        DriverType BrowserType { get; }        
        NgWebDriver WebDriver { get; }
        void Kill();
    }
}
