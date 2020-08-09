using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace YandexMarketTests.Pages
{
    public class LaptopsPage
    {
        private readonly IWebDriver _driver;
        private By _filterBrandCheckBoxLocator;
        private string _filterBrand;
        private int _filterPriceFrom;
        private int _filterPriceTo;
        private readonly By _filterShowAllBrandsButtonLocator = By.XPath("//button[text()='Показать всё']");
        private readonly By _filterBrandInputLocator = By.XPath("//input[@type='text' and @name='Поле поиска']");
        private readonly By _searchBreadcrumbsLaptopsLocator = By.XPath("//span[@itemprop='name' and text()='Ноутбуки']");
        private readonly By _priceFromInputLocator = By.XPath("//input[@name='Цена от']");
        private readonly By _priceToInputLocator = By.XPath("//input[@name='Цена до']");
        private readonly By _catalogItemTitleLocator = By.XPath("//h3[@data-zone-name='title']/a/span");
        private readonly By _catalogItemPrice = By.XPath("//div[@data-zone-name='price']/a/div/span/span");
        
        public LaptopsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            var computersPage = new ComputersPage(_driver);
            computersPage.Open();
            computersPage.ClickLaptopsButton();
            WaitUntil.IsVisible(_driver, _catalogItemTitleLocator);
            Assert.True(_driver.Url.StartsWith("https://market.yandex.ru/catalog--noutbuki-v"));
        }

        public void FilterBrand(string brand)
        {
            _filterBrand = brand;
            _filterBrandCheckBoxLocator = By.XPath($"//span[text()='{brand}']");
            WaitUntil.IsVisibleAndClickable(_driver,_filterShowAllBrandsButtonLocator);
            _driver.FindElement(_filterShowAllBrandsButtonLocator).Click();
            WaitUntil.IsVisibleAndClickable(_driver,_filterBrandInputLocator);
            _driver.FindElement(_filterBrandInputLocator).SendKeys(brand);
            WaitUntil.IsVisibleAndClickable(_driver,_filterBrandCheckBoxLocator);
            _driver.FindElement(_filterBrandCheckBoxLocator).Click();
        }

        public void FilterPriceFrom(int priceFrom)
        {
            _filterPriceFrom = priceFrom;
            WaitUntil.IsVisibleAndClickable(_driver,_priceFromInputLocator);
            _driver.FindElement(_priceFromInputLocator).SendKeys(priceFrom.ToString());
        }
        
        public void FilterPriceTo(int priceTo)
        {
            _filterPriceTo = priceTo;
            WaitUntil.IsVisibleAndClickable(_driver,_priceToInputLocator);
            _driver.FindElement(_priceToInputLocator).SendKeys(priceTo.ToString());
        }

        public void ValidateResults()
        {
            WaitUntil.WaitSomeInterval(5);

            try
            {
                foreach (var item in _driver.FindElements(_catalogItemTitleLocator))
                {
                    Assert.True(item.Text.StartsWith($"Ноутбук {_filterBrand}"));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong while validating titles of search results", e);
            }

            try
            {
                foreach (var item in _driver.FindElements(_catalogItemPrice).Where(x => x.Text.StartsWith("от")))
                {
                    var itemPrice = Convert.ToInt32(item.Text.Substring(3).Replace(" ", ""));
                    Assert.True(itemPrice >= _filterPriceFrom && itemPrice <= _filterPriceTo);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong while validating prices of search results", e);
            }
            
        }
    }
}