using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace YandexMarketTests
{
    public class Tests
    {
        private IWebDriver _webDriver;
        private readonly By _computersButton = By.XPath("//span[text()='Компьютеры']");
        private readonly By _laptopsButton = By.XPath("//a[text()='Ноутбуки']");
        private readonly By _cityButton = By.XPath("//span[text()='Да, спасибо']");
        private readonly By _priceFromInput = By.XPath("//input[@name='Цена от']");
        private readonly By _priceToInput = By.XPath("//input[@name='Цена до']");
        private readonly By _brandShowAllButton = By.XPath("//button[text()='Показать всё']");
        private readonly By _brandSearchInput = By.XPath("//input[@type='text'and@name='Поле поиска']");
        private readonly By _brandCheckBox = By.XPath("//span[text()='Lenovo']");


        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://market.yandex.ru/");
            WaitUntil.ShoudLocate(_webDriver, "https://market.yandex.ru/");
        }

        [Test]
        public void Test1()
        {
            var cityButton = _webDriver.FindElement(_cityButton);
            cityButton.Click();
            WaitUntil.IsVisibleAndClickable(_webDriver,_computersButton);
            var computersButton = _webDriver.FindElement(_computersButton);
            computersButton.Click();
            WaitUntil.IsVisibleAndClickable(_webDriver,_laptopsButton);
            var laptopsButton = _webDriver.FindElement(_laptopsButton);                     
            laptopsButton.Click();
            WaitUntil.IsVisibleAndClickable(_webDriver,_brandShowAllButton);
            var brandShowAllButton = _webDriver.FindElement(_brandShowAllButton);
            brandShowAllButton.Click();
            WaitUntil.IsVisibleAndClickable(_webDriver,_brandSearchInput);
            var brandSearchInput = _webDriver.FindElement(_brandSearchInput);
            brandSearchInput.SendKeys("Lenovo");
            WaitUntil.IsVisibleAndClickable(_webDriver,_brandCheckBox);
            var brandCheckBox = _webDriver.FindElement(_brandCheckBox);
            brandCheckBox.Click();
            var priceFromInput = _webDriver.FindElement(_priceFromInput);
            priceFromInput.SendKeys("25000");
            var priceToInput = _webDriver.FindElement(_priceToInput);
            priceToInput.SendKeys("30000");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}