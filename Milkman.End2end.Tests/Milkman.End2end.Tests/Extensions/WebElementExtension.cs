using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System.Drawing;
using System.Threading;

namespace Milkman.End2end.Tests.Extensions
{
    public static class WebElementExtension
    {

        public static bool IsChecked(this IWebElement element)
        {

            string flag = element?.GetAttribute("checked");
            if (flag == null)
            {
                return false;
            }
            else
            {
                return flag.Equals("true") || flag.Equals("checked");
            }

        }

        public static bool RetryClick(this IWebElement element)
        {
            bool result = false;
            int attempts = 0;
            Thread.Sleep(2000);
            while (attempts < 3)
            {
                try
                {
                    element.JSClick();
                    result = true;
                    break;
                }
                catch (StaleElementReferenceException)
                {
                }
                attempts++;
            }
            return result;
        }


        public static IWebElement JSClick(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
            return element;
        }

        public static IWebElement SendKeys(this IWebElement element, string text, int interval)
        {
            foreach (var @char in text)
            {
                element.SendKeys($"{@char}");
                Thread.Sleep(interval);
            }
            return element;
        }

        public static Actions Actions(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            return new Actions(driver);

        }


        public static void ScrollToElement(this IWebElement element)
        {
            Point p = element.Location;
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.scrollTo(" + p.X + "," + (p.Y + 150) + ");");
        }
    }
}