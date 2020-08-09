﻿using NUnit.Framework;
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
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            var laptopsPage = new LaptopsPage(_driver);
            laptopsPage.Open();
            laptopsPage.FilterBrand("Lenovo");
            laptopsPage.FilterPriceFrom(25000);
            laptopsPage.FilterPriceTo(30000);
            laptopsPage.ValidateResults();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}