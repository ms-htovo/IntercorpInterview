using Intercop.Web.UITests.Views.Home;

namespace Intercop.Web.UITests.Views.Common
{
    public class TestUser
    {
        public IDriver Driver { get; private set; }
        
        public TestUser()
        {
            Driver = new WebManage().Start(); 
            
        }

        public HomePage GoToHomePage() => new HomePage(this);

    }
}
