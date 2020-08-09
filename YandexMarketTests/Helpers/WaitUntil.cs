using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace YandexMarketTests
{
    public static class WaitUntil
    {
        public static void AtPage(IWebDriver driver, string url)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.UrlContains(url));
            }
            catch (WebDriverException ex)
            {
                throw new NotFoundException($"Cannot find out that app in specific location {url}", ex);
            }
        }

        public static void WaitSomeInterval(int seconds = 10)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static void IsVisibleAndClickable(IWebDriver webDriver, By locator, int seconds = 20)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                ExpectedConditions.ElementToBeClickable(locator));
        }
        
        public static void IsVisible(IWebDriver webDriver, By locator, int seconds = 20)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                ExpectedConditions.ElementIsVisible(locator));
        }
    }
}