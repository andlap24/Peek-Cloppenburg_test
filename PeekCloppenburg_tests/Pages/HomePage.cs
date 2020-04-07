using OpenQA.Selenium;
using System;

namespace PeekCloppenburg_tests
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.peek-cloppenburg.pl/");

            var CookieBar = Driver.FindElement(By.XPath("//*[@class='cookieBar qa-cookieBar']"));

            if (CookieBar.Displayed)
            {
                CookieBar.FindElement(By.XPath("//*[@class='button--primary js-cookieBar-accept tlm-cookieBar-accept-button']")).Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Cookie bar is not available");
            }
        }

        public IWebElement Search(string searchText)
        {
            var searchContainer = Driver.FindElement(By.XPath("//*[@class='qa-socialMediaUser  headerSearchForm']"));
            var search = searchContainer.FindElement(By.XPath("//*[@name='topSearchFormTerm']"));
            search.Click();
            search.SendKeys(searchText + Keys.Enter);
            return search;
        }

        public IWebElement UserNavigationBar(string button)
        {
            var header = Driver.FindElement(By.XPath("//*[@class='pageHeader has-primaryNav has-secondaryNav cf']"));
            var navigationBar = header.FindElements(By.XPath("//*[@class='userNav-link']"));

            switch(button)
            {
                case "login":
                    return navigationBar[0];
                case "wish list":
                    return navigationBar[1];
                case "cart":
                    return navigationBar[2];
                default:
                    throw new ArgumentOutOfRangeException("No such item exists in this collection");
            }
        }
    }
}