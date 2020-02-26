using Intercop.Web.UITests.Views.Common;

namespace Intercop.Views.Common
{
    public class DriverFactory
    {
        public static IDriver Get(DriverType driver)
        {
            switch (driver)
            {
                case DriverType.CHROME:
                default:
                    return new ChromeDriver();
            }
        }


    }
}
