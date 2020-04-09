using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace PeekCloppenburg_tests
{
    class Header : BasePage
    {
        public Header(IWebDriver driver) : base(driver) { }

        IWebElement header;
        ReadOnlyCollection<IWebElement> navigationBar;

        public IWebElement GetUserBar(string button)
        {
            header = Driver.FindElement(By.XPath("//*[@class='pageHeader has-primaryNav has-secondaryNav cf']"));
            navigationBar = header.FindElements(By.XPath("//*[@class='userNav-link']"));

            switch (button)
            {
                case "login":
                    return navigationBar[0];
                case "wish list":
                    return navigationBar[1];
                case "cart":
                    return navigationBar[2];
                default:
                    throw new NoSuchElementException("No such item exists in this collection");
            }
        }
    }
}
