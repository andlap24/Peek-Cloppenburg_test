using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PeekCloppenburg_tests
{
    internal class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        IWebElement selectSizePattern;
        IWebElement dropDownButton;
        IWebElement sizeVariantsList;
        IWebElement addButton;
        IWebElement addToCart;
        ReadOnlyCollection<IWebElement> sizeSML;
        ReadOnlyCollection<IWebElement> sizeNumbers;
        WebDriverWait waitSizeAdvizor;
        WebDriverWait waitDialogContainer;


        [Obsolete]
        internal WebDriverWait Wait(int sec)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(sec));
        }

        internal IWebElement SelectSize(char size)
        {
            selectSizePattern = Driver.FindElement(By.XPath("//*[@class='formDropdown-toggle product-selectedSize']"));
            dropDownButton = selectSizePattern.FindElement(By.XPath("//*[@class='formDropdown-toggleIcon icon-arrow-down']"));
            dropDownButton.Click();
            sizeVariantsList = Driver.FindElement(By.XPath("//*[@class='product - sizeVariantsList qa - pdp - size - list'][@id='pdpSizeList']"));
            sizeSML = sizeVariantsList.FindElements(By.XPath("//*[@class='product - sizeLabel']"));

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
            selectSizePattern = Driver.FindElement(By.XPath("//*[@class='formDropdown-toggle product-selectedSize']"));
            dropDownButton = selectSizePattern.FindElement(By.XPath("//*[@class='formDropdown-toggleIcon icon-arrow-down']"));
            dropDownButton.Click();
            sizeVariantsList = Driver.FindElement(By.XPath("//*[@class='formDropdown-collapsibleArea']"));
            sizeNumbers = sizeVariantsList.FindElements(By.XPath("//*[@class='product-sizeLabel']"));

            int sizeListCount = sizeNumbers.Count;
            int counter;
            List<int> sizeList = new List<int>();

            for (counter = 0; counter < sizeListCount; counter++)
            {
                sizeList.Add(int.Parse(sizeNumbers[counter].Text));
            }

            if (sizeList.Contains(size))
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
            waitSizeAdvizor = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            waitSizeAdvizor.Until(ExpectedConditions.ElementToBeClickable
                (By.XPath("//*[@class='button--naked qa-fitanalytics-size-advisor tlm-fitanalytics-size-advisor']")));

            addButton = Driver.FindElement(By.CssSelector(".qa-add-to-cart"));
            Wait(3);
            addButton.Click();

            waitDialogContainer = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            waitDialogContainer.Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//*[@class='dialog-container qa-dialog-container']")));

            addToCart = Driver.FindElement(By.CssSelector(".qa-pdp-to-cart"));
            Wait(3);
            addToCart.Click();
        }
    }
}