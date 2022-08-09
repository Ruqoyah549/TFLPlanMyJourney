using System;
using OpenQA.Selenium;
using BoDi;
using TFLUITestAutomation.BrowserFactory;

namespace TFLUITestAutomation.SetUp
{
    public class Context
    {
        ChromeBrowserFactory _chromeBrowserFactory;
        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;
        string baseUrl = EnvironmentData.baseUrl;
        string browser = EnvironmentData.browser;

        public Context(IObjectContainer objectContainer
                      , ChromeBrowserFactory chromeBrowserFactory)
        {
            this.objectContainer = objectContainer;
            _chromeBrowserFactory = chromeBrowserFactory;
        }

        public void LoadTFLApplication()
        {
            driver = _chromeBrowserFactory.Create(objectContainer);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void ShutDownCMSApplication()
        {
            driver?.Quit();
        }

        public void TakeScreenshotAtThePointOfTestFailure(string directory, string scenarioName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = directory + scenarioName + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
            string Screenshot = screenshot.AsBase64EncodedString;
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}
