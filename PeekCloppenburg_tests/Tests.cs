using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace PeekCloppenburg_tests
{
    public class Tests
    {
        HomePage homePage;
        SearchResultPage searchResultPage;
        ProductPage productPage;
        LoginPage loginPage;

        protected IWebDriver Driver { get; set; }

        public IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [Test]
        [Description("Search and adding 1 item in to bag")]
        [Obsolete]
        public void SearchElementsTest()
        {
            Driver = GetChromeDriver();
            homePage = new HomePage(Driver);
            searchResultPage = new SearchResultPage(Driver);
            productPage = new ProductPage(Driver);

            homePage.Open();
            homePage.Search("michael kors monroe trainer".ToUpper());
            searchResultPage.OpenProductPage(1);
            productPage.SelectSize(38).Click();
            productPage.AddToCart();
            Assert.AreEqual("Checkout", Driver.Title);
        }

        [Test]
        [Description("test login page")]
        public void LoginPageTest()
        {
            Driver = GetChromeDriver();
            homePage = new HomePage(Driver);
            loginPage = new LoginPage(Driver);

            homePage.Open();
            homePage.UserNavigationBar("login").Click();
            loginPage.SignIn();
            Assert.AreEqual("Rejestracja", Driver.Title);
        }
    }
}