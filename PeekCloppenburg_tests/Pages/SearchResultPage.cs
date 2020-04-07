using OpenQA.Selenium;
using System;

namespace PeekCloppenburg_tests
{
    class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) { }

        public string SearchResult()
        {
            return Driver.FindElement(By.XPath("//*[@class='seo-headline qa-seo-headline']")).TagName;
        }

        public void OpenProductPage(int num)
        {
            var resultPage = Driver.FindElement(By.XPath("//*[@class='productList has-productTileHover qa-product-list']"));
            var resultList = resultPage.FindElements(By.XPath("//*[@class='productTile-brand qa-product-tile-brand']"));

            if (num == 1)
            {
                resultList[0].Click();
            }
            else if (num >= 2 && num <= resultList.Count)
            {
                resultList[num--].Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number is out of range");
            }
        }
    }
}
