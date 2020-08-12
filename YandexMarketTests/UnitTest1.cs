using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using YandexMarketTests.Pages;

namespace YandexMarketTests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            //Положить .env файл в корень директории сборки
            DotNetEnv.Env.Load();
            //Либо указать полный путь
            //DotNetEnv.Env.Load(@"C:\Users\user9\source\repos\YandexMarketTests\YandexMarketTests\.env");
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var laptopsPage = new LaptopsPage(_driver);
            laptopsPage.Open();
            laptopsPage.FilterBrand(Environment.GetEnvironmentVariable("Brand"));
            laptopsPage.FilterPriceFrom(Int32.Parse(Environment.GetEnvironmentVariable("PriceFrom")));
            laptopsPage.FilterPriceTo(Int32.Parse(Environment.GetEnvironmentVariable("PriceTo")));
            laptopsPage.ValidateResults();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}