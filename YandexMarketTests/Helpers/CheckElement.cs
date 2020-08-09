using OpenQA.Selenium;

namespace YandexMarketTests
{
    public static class CheckElement
    {
        public static bool IsExists(IWebDriver driver, By element)
        {
            try
            {
                driver.FindElement(element);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
    }
}