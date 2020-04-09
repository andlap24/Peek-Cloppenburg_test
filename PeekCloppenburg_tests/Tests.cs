using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace PeekCloppenburg_tests
{
    public class Tests
    {
        protected IWebDriver Driver { get; set; }

        [Test]
        [Description("Search and adding 1 item in to bag")]
        [Obsolete]
        public void SearchElementsTest()
        {
            Driver = GetDriver.GetChromeDriver();
            var homePage = new HomePage(Driver);
            var searchResultPage = new SearchResultPage(Driver);
            var productPage = new ProductPage(Driver);

            homePage.Open();
            homePage.GetSearchElement("michael kors monroe trainer".ToUpper());
            searchResultPage.OpenProductPage(1);
            productPage.SelectSize(38).Click();
            productPage.AddToCart();
            Assert.AreEqual("Checkout", Driver.Title);
        }

        [Test]
        [Description("test login page")]
        public void LoginPageTest()
        {
            Driver = GetDriver.GetChromeDriver();
            var homePage = new HomePage(Driver);
            var loginPage = new LoginPage(Driver);
            var header = new Header(Driver);

            homePage.Open();
            header.GetUserBar("login").Click();
            loginPage.SignIn("test@yahoo.com", "123456789");
            Assert.AreEqual("Rejestracja", Driver.Title);
        }
    }
}