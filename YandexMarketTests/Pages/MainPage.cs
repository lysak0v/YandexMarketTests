using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace YandexMarketTests.Pages
{
    public class MainPage
    {
        private readonly IWebDriver _driver;
        private readonly string _urlMainPage = "https://market.yandex.ru/";
        private readonly By _submitRegionButtonLocator = By.XPath("//span[text()='Да, спасибо']");
        private readonly By _computersButtonLocator = By.XPath("//span[text()='Компьютеры']");

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_urlMainPage);
            WaitUntil.AtPage(_driver, _urlMainPage);
        }

        public void SubmitRegion()
        {
            if (CheckElement.IsExists(_driver, _submitRegionButtonLocator))
            {
                WaitUntil.IsVisibleAndClickable(_driver,_submitRegionButtonLocator);
                _driver.FindElement(_submitRegionButtonLocator).Click();
                Assert.False(CheckElement.IsExists(_driver,_submitRegionButtonLocator));
            }
        }
        
        public void ClickComputersButton()
        {
            WaitUntil.IsVisibleAndClickable(_driver, _computersButtonLocator);
            _driver.FindElement(_computersButtonLocator).Click();
        }
    }
}