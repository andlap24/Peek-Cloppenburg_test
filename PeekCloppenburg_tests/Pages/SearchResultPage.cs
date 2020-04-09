using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace PeekCloppenburg_tests
{
    class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) { }

        IWebElement resultPage;
        ReadOnlyCollection<IWebElement> resultList;

        public void OpenProductPage(int num)
        {
            resultPage = Driver.FindElement(By.XPath("//*[@class='productList has-productTileHover qa-product-list']"));
            resultList = resultPage.FindElements(By.XPath("//*[@class='productTile-brand qa-product-tile-brand']"));

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
