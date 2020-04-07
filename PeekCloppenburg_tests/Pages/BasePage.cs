using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace PeekCloppenburg_tests
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
