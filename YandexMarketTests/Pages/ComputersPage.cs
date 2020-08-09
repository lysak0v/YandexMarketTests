using NUnit.Framework;
using OpenQA.Selenium;

namespace YandexMarketTests.Pages
{
    public class ComputersPage
    {
        private readonly IWebDriver _driver;
        private readonly By _computersPageHeaderLocator = By.XPath("//h1[text()='Компьютерная техника']");
        private readonly By _laptopsButtonLocator = By.XPath("//a[text()='Ноутбуки']");
        
        public ComputersPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            var mainPage = new MainPage(_driver);
            mainPage.Open();
            mainPage.SubmitRegion();
            mainPage.ClickComputersButton();
            WaitUntil.IsVisible(_driver, _computersPageHeaderLocator);
            Assert.AreEqual(_driver.Title, "Компьютерная техника — купить на Яндекс.Маркете");
        }

        public void ClickLaptopsButton()
        {
            WaitUntil.IsVisibleAndClickable(_driver,_laptopsButtonLocator);
            _driver.FindElement(_laptopsButtonLocator).Click();
        }
    }
}