using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PeekCloppenburg_tests
{
    internal class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        [Obsolete]
        internal WebDriverWait Wait(int sec)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(sec));
        }

        internal IWebElement SelectSize(char size)
        {
            var selectSizePattern = Driver.FindElement(By.XPath("//*[@class='formDropdown-toggle product-selectedSize']"));
            var dropDownButton = selectSizePattern.FindElement(By.XPath("//*[@class='formDropdown-toggleIcon icon-arrow-down']"));
            dropDownButton.Click();
            var sizeVariantsList = Driver.FindElement(By.XPath("//*[@class='product - sizeVariantsList qa - pdp - size - list'][@id='pdpSizeList']"));
            var sizeSML = sizeVariantsList.FindElements(By.XPath("//*[@class='product - sizeLabel']"));

            switch (size)
            {
                case 's':
                    return sizeSML[0];
                case 'm':
                    return sizeSML[1];
                case 'l':
                    return sizeSML[2];
                default:
                    throw new ArgumentOutOfRangeException("No such item exists in this collection");
            }
        }

        internal IWebElement SelectSize(int size)
        {
            var selectSizePattern = Driver.FindElement(By.XPath("//*[@class='formDropdown-toggle product-selectedSize']"));
            var dropDownButton = selectSizePattern.FindElement(By.XPath("//*[@class='formDropdown-toggleIcon icon-arrow-down']"));
            dropDownButton.Click();
            var sizeVariantsList = Driver.FindElement(By.XPath("//*[@class='formDropdown-collapsibleArea']"));
            var sizeNumbers = sizeVariantsList.FindElements(By.XPath("//*[@class='product-sizeLabel']"));
            
            int sizeListCount = sizeNumbers.Count;
            int counter;
            var sizeList = new List<int>();

            for (counter = 0; counter < sizeListCount; counter++)
            {
                sizeList.Add(int.Parse(sizeNumbers[counter].Text));
            }

            if(sizeList.Contains(size))
            {
                var index = sizeList.IndexOf(size);
                return sizeNumbers[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("No such item exists in this collection");
            }
        }

        [Obsolete]
        internal void AddToCart()
        {
            WebDriverWait waitSizeAdvizor = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            waitSizeAdvizor.Until(ExpectedConditions.ElementToBeClickable
                (By.XPath("//*[@class='button--naked qa-fitanalytics-size-advisor tlm-fitanalytics-size-advisor']")));

            var addButton = Driver.FindElement(By.CssSelector(".qa-add-to-cart"));
            Wait(3);
            addButton.Click();

            WebDriverWait waitDialogContainer = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            waitDialogContainer.Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//*[@class='dialog-container qa-dialog-container']")));

            var addToCart = Driver.FindElement(By.CssSelector(".qa-pdp-to-cart"));
            Wait(3);
            addToCart.Click();
        }
    }
}