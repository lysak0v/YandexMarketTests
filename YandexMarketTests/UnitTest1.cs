using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace YandexMarketTests
{
    public class Tests
    {
        private IWebDriver driver;
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
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://market.yandex.ru/");
            
        }

        [Test]
        public void Test1()
        {
            var cityButton = driver.FindElement(_cityButton);
            cityButton.Click();
            Thread.Sleep(2000);
            var computersButton = driver.FindElement(_computersButton);
            computersButton.Click();
            Thread.Sleep(2000);
            var laptopsButton = driver.FindElement(_laptopsButton);                     
            laptopsButton.Click();
            Thread.Sleep(2000);
            var brandShowAllButton = driver.FindElement(_brandShowAllButton);
            brandShowAllButton.Click();
            Thread.Sleep(1000);
            var brandSearchInput = driver.FindElement(_brandSearchInput);
            brandSearchInput.SendKeys("Lenovo");
            Thread.Sleep(1000);
            var brandCheckBox = driver.FindElement(_brandCheckBox);
            brandCheckBox.Click();
            Thread.Sleep(1000);
            var priceFromInput = driver.FindElement(_priceFromInput);
            priceFromInput.SendKeys("25000");
            var priceToInput = driver.FindElement(_priceToInput);
            priceToInput.SendKeys("30000");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}