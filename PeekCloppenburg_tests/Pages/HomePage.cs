using OpenQA.Selenium;

namespace PeekCloppenburg_tests
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        IWebElement CookieBar;
        IWebElement searchContainer;
        IWebElement search;

        public void Open()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.peek-cloppenburg.pl/");

            CookieBar = Driver.FindElement(By.XPath("//*[@class='cookieBar qa-cookieBar']"));

            if (CookieBar.Displayed)
            {
                CookieBar.FindElement(By.XPath("//*[@class='button--primary js-cookieBar-accept tlm-cookieBar-accept-button']")).Click();
            }
            else
            {
                throw new NoSuchElementException("Cookie bar is not available");
            }
        }

        public IWebElement GetSearchElement(string searchText)
        {
            searchContainer = Driver.FindElement(By.XPath("//*[@class='qa-socialMediaUser  headerSearchForm']"));
            search = searchContainer.FindElement(By.XPath("//*[@name='topSearchFormTerm']"));
            search.Click();
            search.SendKeys(searchText + Keys.Enter);
            return search;
        }
    }
}