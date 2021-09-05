using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Milkman.End2end.Tests.Helpers
{
    public class WaitHelper
    {

        private readonly WebDriverWait _wait;

        public WaitHelper(IWebDriver driver, int timeout = 20)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        }

        public IEnumerable<T> WaitForAllElements<T>(Func<IWebDriver, IEnumerable<T>> expectedConditions) where T : IWebElement
        {
            try
            {
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return _wait.Until(expectedConditions);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public T WaitForElement<T>(Func<IWebDriver, T> expectedConditions) where T : IWebElement
        {
            try
            {
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return _wait.Until(expectedConditions);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IWebElement FindWithWait(By by)
        {
            try
            {
                return _wait.Until(d => d.FindElement(by));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
