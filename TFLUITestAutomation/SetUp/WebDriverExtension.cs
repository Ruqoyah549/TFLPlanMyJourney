using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TFLUITestAutomation.SetUp
{
    public static class WebDriverExtension
    {
        private static readonly TimeSpan implicitTimeout;
        private static readonly int timeout;

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }


        private static void setImplicitTimeout(this IWebDriver driver, int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        private static void switchOffImplicitWaiting(this IWebDriver driver)
        {
            setImplicitTimeout(driver, 0);
        }

        private static void resetImplicitTimeOut(this IWebDriver driver)
        {
            setImplicitTimeout(driver, timeout);
        }

        internal static void ClearAndSendKeys(this IWebDriver driver, By identifier, string text, int? waitingTime = null)
        {
            driver.FindElement(identifier, 5).Clear();
            driver.FindElement(identifier).SendKeys(text);
            if (waitingTime != null)
            {
                Thread.Sleep(Convert.ToInt16(waitingTime));
            }
            driver.FindElement(identifier).SendKeys(Keys.Tab);
        }

        internal static void Click(this IWebDriver driver, By identifier)
        {
            driver.FindElement(identifier, 5).Click();
        }

        internal static void FocusAndClick(this IWebDriver driver, By identifier)
        {
            IWebElement element = driver.FindElement(identifier, 5);
            Actions act = new Actions(driver);
            act.MoveToElement(element).Click().Build().Perform();
        }

        internal static bool SelectOptionByText(this IWebDriver driver, By identifier, string text)
        {
            bool elementToSelectExist = false;
            try
            {
                SelectElement select = new SelectElement(driver.FindElement(identifier, 5));
                Thread.Sleep(1000);
                select.SelectByText(text);
                elementToSelectExist = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return elementToSelectExist;
        }

        internal static string GetElementText(this IWebDriver driver, By identifier)
        {
            return driver.FindElement(identifier, 5).Text.Trim();
        }


        internal static bool ElementExists(this IWebDriver driver, By identifier)
        {
            return ElementExists(driver, identifier, implicitTimeout);
        }

        internal static bool ElementExists(this IWebDriver driver, By identifier, TimeSpan timeout)
        {
            bool result = false;
            try
            {
                switchOffImplicitWaiting(driver);
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(identifier));
                result = true;
            }
            catch (WebDriverTimeoutException)
            {
                result = false;
            }
            finally
            {
                resetImplicitTimeOut(driver);
            }
            return result;
        }
    }
}
